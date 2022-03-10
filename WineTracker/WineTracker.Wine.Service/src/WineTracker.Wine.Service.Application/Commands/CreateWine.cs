using Convey.CQRS.Commands;
using WineTracker.Wine.Service.Application.Infrastructure;
using WineTracker.Wine.Service.Domain.Wine;

namespace WineTracker.Wine.Service.Application.Commands;

public class CreateWine : ICommand
{
    public string Name { get; init; }
    public string? Producer { get; init; }
    public string? Region { get; init; }
    public string? Country { get; init; }
    public int? Vintage { get; init; }
    public string? Kind { get; init; }
    public int? Price { get; init; }
    public IReadOnlyList<string>? GrapeVarietals { get; init; }
    
    public CreateWine(string name, 
        string? producer, 
        string? region, 
        string? country, 
        int? vintage,
        string? kind,
        int? price,
        IReadOnlyList<string>? grapeVarietals)
    {
        Name = name;
        Producer = producer;
        Region = region;
        Country = country;
        Vintage = vintage;
        Kind = kind;
        Price = price;
        GrapeVarietals = grapeVarietals;
    }
    
    public void Deconstruct(out string name, out string? producer, out string? region, out string? country, out int? vintage, out string? kind, out int? price, out IReadOnlyList<string>? grapeVarietals)
    {
        name = Name;
        producer = Producer;
        region = Region;
        country = Country;
        vintage = Vintage;
        kind = Kind;
        price = Price;
        grapeVarietals = GrapeVarietals;
    }

    public class Handler : ICommandHandler<CreateWine>
    {
        private readonly IWineRepository _wineRepository;

        public Handler(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }
        
        public async Task HandleAsync(CreateWine command, CancellationToken cancellationToken = new CancellationToken())
        {
            command.Deconstruct(
                out string name, 
                out string? producer, 
                out string? region, 
                out string? country, 
                out int? vintage, 
                out string? kind, 
                out int? price, 
                out IReadOnlyList<string>? grapeVarietals);
            
            await _wineRepository.CreateWine(
                name,
                producer,
                region,
                country,
                vintage,
                kind,
                price,
                grapeVarietals);
        }
    }
}