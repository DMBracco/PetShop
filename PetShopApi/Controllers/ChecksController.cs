using BLL.Entities;
using BLL.IRepositories;
using Microsoft.AspNetCore.Mvc;
using PetShopApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecksController : ControllerBase
    {
        private readonly IGenericRepository<Check> _repository;
        private readonly ILogger<ChecksController> _logger;
        private readonly IGenericRepository<BonusCard> _bonusCardRepository;
        private readonly IGenericRepository<Product> _productRepository;

        public ChecksController(IGenericRepository<Check> repository, ILogger<ChecksController> logger, IGenericRepository<BonusCard> bonusCardRepository, IGenericRepository<Product> productRepository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bonusCardRepository = bonusCardRepository ?? throw new ArgumentNullException(nameof(bonusCardRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }
        // GET: api/<ChecksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ChecksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChecksController>
        [HttpPost]
        public JsonResult Post([FromBody] CheckViewModel model)
        {
            var item = new Check
            {
                DateCreate = DateTime.Now,
                TotalPrice = model.totalPrice
            };

            try
            {
                _repository.Create(item);

                var productList = _productRepository.GetList();

                var bonus = _bonusCardRepository.GetByIdOrNULL(model.bonusCardId);
                if(null != bonus)
                {
                    bonus.Points = model.bonusPoints;
                    bonus.Points += (float)(model.totalPrice * 0.05);
                    _productRepository.Save();

                }

                foreach (var productModel in model.products)
                {
                    foreach (var product in productList)
                    {
                        if (productModel.productId == product.Id)
                        {
                            product.ProductQuantity = product.ProductQuantity - productModel.productQuantity;
                            product.PurchasingPrice = productModel.purchasingPrice;
                        }
                    }
                    item.CheckForProducts.Add(new CheckForProduct { 
                        ProductId = productModel.productId,
                        ProductQuantity = productModel.productQuantity
                    });
                }
                _repository.Save();

                return new JsonResult($"Запись создана под id = { item.Id }");
            }
            catch
            {
                return new JsonResult("Ошибка при создании записи");
            }
        }

        // PUT api/<ChecksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChecksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
