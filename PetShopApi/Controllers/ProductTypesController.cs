using BLL.Entities;
using BLL.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShopApi.ViewModels;

namespace PetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductTypesController(IGenericRepository<ProductType> repository, ILogger<ProductsController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<ProductTypes>
        [HttpGet]
        public IEnumerable<ProductTypeViewModel> Get()
        {
            return _repository.GetList().Select(b => new ProductTypeViewModel
            {
                id = b.Id,
                name = b.ProductTypeName
            });
        }
    }
}
