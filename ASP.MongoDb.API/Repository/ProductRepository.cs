using ASP.MongoDb.API.Entities;
using ASP.MongoDb.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ASP.MongoDb.API.Repository
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByPriceRange(decimal minPrice, decimal maxPrice);
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IOptions<MongoDbSettings> settings) : base(settings)
        {
        }

        public async Task<IEnumerable<Product>> GetByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return await _collection.Find(p => p.Price >= minPrice && p.Price <= maxPrice).ToListAsync();
        }
    }
}
