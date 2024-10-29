using AutoMapper;
using LastHope.Application.DTO;
using LastHope.Domain.Entities;
using LastHope.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LastHope.Application.Service
{
    public class ProductService : GenericInterface<ProductDTO>
    {
        private readonly GenericInterface<Product> iproduct;
        private readonly IMapper mapper;
        public ProductService(GenericInterface<Product> _iproduct, IMapper _mapper)
        {
            iproduct = _iproduct;
            mapper = _mapper;
        }
        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            IEnumerable<Product> products = await iproduct.GetProductsAsync();
            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        public async Task<ProductDTO> GetProductAsync(int id)
        {
            Product product = await iproduct.GetProductAsync(id);
            return mapper.Map<ProductDTO>(product);
        }
        public Task CreateProductAsync(ProductDTO product)
        {
            Product nproduct = mapper.Map<Product>(product);
            return iproduct.CreateProductAsync(nproduct);
        }
        public Task UpdateProductAsync(ProductDTO product)
        {
            Product uproduct = mapper.Map<Product>(product);
            return iproduct.UpdateProductAsync(uproduct);
        }
        public Task DeleteProductAsync(int id)
        {
            return iproduct.DeleteProductAsync(id);
        }
    }
}
