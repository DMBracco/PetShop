using BLL.Entities;
using BLL.IRepositories;
using Microsoft.AspNetCore.Mvc;
using PetShopApi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IGenericRepository<Manufacturer> _repository;
        private readonly ILogger<ManufacturerController> _logger;

        public ManufacturerController(IGenericRepository<Manufacturer> repository, ILogger<ManufacturerController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // GET: api/<ManufacturerController>
        [HttpGet]
        public IEnumerable<ManufacturerViewModel> Get()
        {
            return _repository.GetList().Select(b => new ManufacturerViewModel
            {
                id = b.Id,
                name = b.Name
            });
        }

        // GET api/<ManufacturerController>/5
        [HttpGet("{id}")]
        public ManufacturerViewModel Get(int id)
        {
            var itemDb = _repository.GetByIdOrNULL(id);

            var itemNew = new ManufacturerViewModel();

            if (itemDb != null)
            {
                itemNew = new ManufacturerViewModel
                {
                    id = itemDb.Id,
                    name = itemDb.Name
                };
            }

            return itemNew;
        }

        // POST api/<ManufacturerController>
        [HttpPost]
        public JsonResult Post([FromBody] ManufacturerViewModel model)
        {
            var item = new Manufacturer
            {
                Name = model.name
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

        // PUT api/<ManufacturerController>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] ManufacturerViewModel model)
        {
            if (id != model.id)
            {
                return new JsonResult("Id неверен");
            }
            var item = new Manufacturer
            {
                Id = model.id,
                Name = model.name
            };

            try
            {
                _repository.Update(item);
                return new JsonResult($"Запись успешна обновлена");
            }
            catch
            {
                return new JsonResult("Ошибка при обновлении записи");
            }
        }

        // DELETE api/<ManufacturerController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            if (_repository.Delete(id))
            {
                return new JsonResult("Запись успешна удалена");
            }
            else
            {
                return new JsonResult("Ошибка при удалении записи");
            }
        }
    }
}
