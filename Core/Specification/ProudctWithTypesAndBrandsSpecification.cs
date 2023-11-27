using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
        public ProductWithTypesAndBrandsSpecification(int id):base(p=>p.Id==id)
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }

        public ProductWithTypesAndBrandsSpecification(ProductPrams prams)
            : base(x =>
                  (string.IsNullOrEmpty(prams.Search) || x.Name.Contains(prams.Search)) &&
                  (!prams.TypeId.HasValue || x.ProductTypeId == prams.TypeId) &&
                  (!prams.BrandId.HasValue || x.ProductBrandId == prams.BrandId))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            //AddOrderBy(p => p.Name);
            ApplyPaging(skip: prams.PageSize * (prams.PageIndex - 1), take: prams.PageSize);
            switch (prams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDesc(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }

        }
        
    }
}
