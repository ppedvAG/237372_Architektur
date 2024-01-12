using AutoMapper;
using ppedv.DiePizzaBude.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ppedv.DiePizzaBude.Model.Contracts;
using ppedv.DiePizzaBude.API.Model;
using ppedv.DiePizzaBude.Model.DomainModel;

namespace ppedv.DiePizzaBude.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;

        public PizzaController(IRepository repo)
        {
            this.repo = repo;
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            // Create Mapper instance
            this.mapper = new Mapper(config);
        }

        // GET: api/<PizzaController>
        [HttpGet]
        public ActionResult<IEnumerable<PizzaDTO>> Get()
        {
            var pizzas = repo.GetAll<Pizza>().ToList();
            return Ok(mapper.Map<List<PizzaDTO>>(pizzas));
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ActionResult<PizzaDTO> Get(int id)
        {
            var pizza = repo.GetById<Pizza>(id);
            if (pizza == null) return NotFound();
            return Ok(mapper.Map<PizzaDTO>(pizza));
        }

        // POST api/<PizzaController>
        [HttpPost]
        public ActionResult Post([FromBody] PizzaDTO pizzaDTO)
        {
            var pizza = mapper.Map<Pizza>(pizzaDTO);
            repo.Add(pizza);
            repo.SaveAll();
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizzaDTO);
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] PizzaDTO pizzaDTO)
        {
            var pizza = repo.GetById<Pizza>(id);
            if (pizza == null) return NotFound();

            mapper.Map(pizzaDTO, pizza);
            repo.Update(pizza);
            repo.SaveAll();
            return NoContent();
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var pizza = repo.GetById<Pizza>(id);
            if (pizza == null) return NotFound();

            repo.Delete(pizza);
            repo.SaveAll();
            return NoContent();
        }
    }
}
