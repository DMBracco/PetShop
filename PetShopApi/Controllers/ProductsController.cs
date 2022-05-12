using BLL.Entities;
using BLL.IRepositories;
using Microsoft.AspNetCore.Mvc;
using PetShopApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(IGenericRepository<Product> repository, ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductViewModel> Get()
        {
            return _repository.GetList().Select(b => new ProductViewModel
            {
                productId = b.Id,
                productName = b.ProductName,
                purchasingPrice = b.PurchasingPrice,
                productQuantity = b.ProductQuantity,
            });
        }

        [HttpGet("get-list-of-supply")]
        public IEnumerable<ProductViewModel> GetListOfSupply()
        {
            var products = _productRepository.GetFullList().ToList();
            var productModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                if (0 < product.SupplyForProducts.Count)
                {
                    var productModel = new ProductViewModel
                    {
                        productId = product.Id,
                        productName = product.ProductName,
                        purchasingPrice = product.PurchasingPrice,
                        productQuantity = product.ProductQuantity,
                    };
                    productModels.Add(productModel);
                }
            }
            return (productModels);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public JsonResult Post([FromBody] ProductViewModel value)
        {
            var itemNew = new Product
            {
                ProductName = value.productName,
                ManufacturerId = value.manufacturerId,
                ProductTypeId = value.productTypeId,
                PurchasingPrice = value.purchasingPrice,
                ProductQuantity = value.productQuantity
            };
            _repository.Create(itemNew);
            try
            {
                _repository.Save();
            }
            catch
            {
                return new JsonResult("Ошибка при создании записи");
            }

            return new JsonResult($"Запись создана под id = { itemNew.Id }");
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
