using AutoMapper;
using StorageAccounting.Application.Interfaces.Services.Arrival;
using StorageAccounting.Common.Enums.Common;
using StorageAccounting.Contracts.Enums.Common;
using StorageAccounting.Contracts.Filters.Arrival;
using StorageAccounting.Contracts.Models.Arrival;
using StorageAccounting.Contracts.Requests.Arrival;
using StorageAccounting.Domain.Contexts;
using StorageAccounting.Domain.Models.Common;
using StorageAccounting.Domain.Models.Item;
using StorageAccounting.Domain.Models.Storage;

namespace StorageAccounting.Application.Services.Arrival;
public class ArrivalService : IArrivalService
{
    private readonly IMapper _mapper;

    private readonly StorageAccountingContext _context;

    private readonly int[] ArrivalPartnerTypes = [(int)PartnerTypes.MaterialManufacturer];
    private readonly int[] ArrivalPlaceTypes = [(int)PlaceTypes.RawMaterials];

    public ArrivalService(IMapper mapper, StorageAccountingContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public long Create(ArrivalCreateRequest request)
    {
        PartnerType partnerType = _context.PartnerTypes
            .Where(type => type.Partners.Any(partner => partner.Id == request.PartnerId))
            .Single();
        if (!ArrivalPartnerTypes.Contains(partnerType.Id))
        {
            throw new ApplicationException($"Некорректный тип партнёра для поступления: {partnerType.Name}");
        }

        PlaceType placeType = _context.PlaceTypes
            .Where(type => type.Places.Any(place => place.Id == request.PlaceId))
            .Single();
        if (!ArrivalPlaceTypes.Contains(placeType.Id))
        {
            throw new ApplicationException($"Некорректный тип склада для поступления: {placeType.Name}");
        }

        var invalidRows = request.Rows.Where(row => !_context.ProductTypeMarks.Any(ptm => row.ProductTypeId == ptm.ProductTypeId && row.MarkId == ptm.MarkId));
        if (invalidRows.Any())
        {
            throw new ApplicationException($"Не найдено соответствие марки с типом продукции");
        }

        DateTime now = DateTime.Now;

        using var transaction = _context.Database.BeginTransaction();

        List<Item> items = request.Rows
            .Select(row => new Item() { 
                ProductTypeId = row.ProductTypeId,
                PlaceId = request.PlaceId,
                UnitId = row.UnitId,
                Amount = row.Amount,
            })
            .ToList();
        _context.Items.AddRange(items);

        Document document = new()
        {
            DateCreate = now,
            DateFact = request.DateArrival,
            DocumentTypeId = (int)DocTypes.Arrival,
        };
        _context.Documents.Add(document);
        _context.SaveChanges();

        Operation operation = new()
        {
            DateCreate = now,
            DocumentId = document.Id,
            OperationTypeId = (int)OperationTypes.ArrivalCreate,
            StateId = (int)States.New,
        };
        _context.Operations.Add(operation);

        Domain.Models.Storage.Arrival arrival = new()
        {
            DocumentId = document.Id,
            DateArrival = now,
            PartnerId = request.PartnerId,
            PlaceId = request.PlaceId,
        };
        _context.Arrivals.Add(arrival);

        List<Position> positions = items
            .Select(item => new Position() {
                DocumentId = document.Id,
                DateCreate = now,
                ItemId = item.Id,
            })
            .ToList();
        _context.Positions.AddRange(positions);
        _context.SaveChanges();

        List<ArrivalRow> rows = positions
            .Select((position, id) => new ArrivalRow() {
                PositionId = position.Id,
                MarkId = request.Rows[id].MarkId,
                Comment = request.Rows[id].Comment,
            })
            .ToList();
        _context.ArrivalRows.AddRange(rows);
        _context.SaveChanges();

        List<Move> moves = positions
            .Select(position => new Move() {
                PositionId = position.Id,
                OperationId = operation.Id,
                AmountPlan = position.Item.Amount,
                Direction = (int)Directions.In,
            })
            .ToList();
        _context.Moves.AddRange(moves);
        _context.SaveChanges();

        transaction.Commit();

        return arrival.Id;
    }

    public ArrivalDto Get(long id)
    {
        // TODO: project to?
        Domain.Models.Storage.Arrival? arrival = _context.Arrivals
            .Where(arrival => arrival.Id == id)
            .SingleOrDefault()
            ?? throw new ApplicationException("Документ поступления не найден");

        ArrivalDto arrivalDto = _mapper.Map<ArrivalDto>(arrival);

        // TODO: add rows

        return arrivalDto;
    }

    public List<ArrivalDto> Get(ArrivalFilter filter)
    {
        throw new NotImplementedException();
    }
}
