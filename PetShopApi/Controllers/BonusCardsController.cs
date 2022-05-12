using BLL.Entities;
using BLL.IRepositories;
using Microsoft.AspNetCore.Mvc;
using PetShopApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusCardsController : ControllerBase
    {
        private readonly IGenericRepository<BonusCard> _repository;
        private readonly ILogger<ManufacturerController> _logger;

        public BonusCardsController(IGenericRepository<BonusCard> repository, ILogger<ManufacturerController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<BonusCardsController>
        [HttpGet]
        public IEnumerable<BonusCardViewModel> Get()
        {
            return _repository.GetList().Select(b => new BonusCardViewModel
            {
                id = b.Id,
                points = b.Points
            });
        }

        // GET api/<BonusCardsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BonusCardsController>
        [HttpPost]
        public JsonResult Post([FromBody] BonusCardViewModel value)
        {
            var item = new BonusCard
            {
                Points = value.points
            };
            try
            {
                _repository.Create(item);

                return new JsonResult($"Запись создана под id = { item.Id }");
            }
            catch
            {
                return new JsonResult("Ошибка при создании записи");
            }
        }

        // PUT api/<BonusCardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BonusCardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
