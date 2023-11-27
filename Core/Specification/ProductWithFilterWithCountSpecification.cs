using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithFilterWithCountSpecification:BaseSpecification<Product>
    {
        public ProductWithFilterWithCountSpecification(ProductPrams prams) : base(x =>
                  (string.IsNullOrEmpty(prams.Search) || x.Name.Contains(prams.Search)) &&
                  (!prams.TypeId.HasValue || x.ProductTypeId == prams.TypeId) &&
                  (!prams.BrandId.HasValue || x.ProductBrandId == prams.BrandId))
        {
        }
    }
}
