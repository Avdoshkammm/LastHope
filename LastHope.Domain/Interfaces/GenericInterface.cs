using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastHope.Domain.Interfaces
{
    public interface GenericInterface<T> where T : class
    {
        Task<IEnumerable<T>> GetProductsAsync();
        Task<T> GetProductAsync(int id);
        Task CreateProductAsync(T product);
        Task UpdateProductAsync(T product);
        Task DeleteProductAsync(int id);
    }
}
