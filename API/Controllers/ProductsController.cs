using API.DTOs;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> productBrandRepo
            , IGenericRepository<ProductType> productTypeRepo, IMapper mapper)


        {

            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts
            ([FromQuery] ProductPrams prams)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(prams);
            var countspec = new ProductWithFilterWithCountSpecification(prams);
            var totalItems =await _productRepo.CountAsync(countspec);
            var products = await _productRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);
            var result = new Pagination<ProductToReturnDto>(
                   pageIndex: prams.PageIndex,
                   pageSize: prams.PageSize,
                   count: totalItems,
                   data: data);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(type: typeof(ApiResponse), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(type: typeof(ProductToReturnDto), statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            return Ok(_mapper.Map<ProductToReturnDto>(product));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}
