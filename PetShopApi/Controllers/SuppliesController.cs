using BLL.Entities;
using BLL.IRepositories;
using Microsoft.AspNetCore.Mvc;
using PetShopApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly IGenericRepository<Supply> _repository;
        private readonly ILogger<ManufacturerController> _logger;
        private readonly IGenericRepository<Product> _productRepository;

        public SuppliesController(IGenericRepository<Supply> repository, ILogger<ManufacturerController> logger, IGenericRepository<Product> productRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        // GET: api/<SuppliesController>
        [HttpGet]
        public IEnumerable<SupplyViewModel> Get()
        {
            return _repository.GetList().Select(b => new SupplyViewModel
            {
                id = b.Id,
                invoiceNumber = b.InvoiceNumber,
                dateCreate = b.DateCreate
            });
        }

        // GET api/<SuppliesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuppliesController>
        [HttpPost]
        public JsonResult Post([FromBody] SupplyViewModel model)
        {
            var item = new Supply
            {
                InvoiceNumber = model.invoiceNumber,
                DateCreate = model.dateCreate,
                SupplierData = model.supplierData
            };
            try
            {
                _repository.Create(item);

                var productList = _productRepository.GetList();

                foreach (var productModel in model.products)
                {
                    foreach (var product in productList)
                    {
                        if (productModel.productId == product.Id)
                        {
                            product.ProductQuantity = product.ProductQuantity + productModel.productQuantity;
                            product.PurchasingPrice = productModel.purchasingPrice;
                        }
                    }

                    item.SupplyForProducts.Add(new SupplyForProduct { 
                        ProductId = productModel.productId,
                        ProductQuantity = productModel.productQuantity,
                        PurchasingPrice = productModel.purchasingPrice
                    });
                }
                _repository.Save();

                return new JsonResult($"Поставка произведена");
            }
            catch
            {
                return new JsonResult("Ошибка при создании записи");
            }
        }

        // PUT api/<SuppliesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuppliesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
