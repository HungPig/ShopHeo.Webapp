using ShopHeo.Application.Catalog.Products.Dtos;
using ShopHeo.Application.Dtos;
using ShopHeo.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopHeo.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly HshopDBContext context;
        public ManageProductService(HshopDBContext context) 
        {
            this.context = context;
        }
        public void Create(ProductCreatedRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productId)
        {
            throw new NotImplementedException();
        }

        public PageResult<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PageResult<ProductViewModel> GetAllPaging(string Keyword, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCreatedRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
