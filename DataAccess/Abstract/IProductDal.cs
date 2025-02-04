﻿using System.Collections.Generic;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductCategoryDto> GetProductCategory();
        List<ProductSuppliersDto> GetProductSupplier();
    }
}