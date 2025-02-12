using Microsoft.AspNetCore.Mvc;
using EgiitmwebapiIzuBtk.Models;
using EgiitmwebapiIzuBtk.Repositories;

namespace EgiitmwebapiIzuBtk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonelsController : ControllerBase
    {
        private readonly IRepository<Personel> _repository;

        public PersonelsController(IRepository<Personel> reposietory)
        {
            _repository = reposietory;
        }

        // GET: api/Personels
        [HttpGet] // GETALL İŞLEMİ BİTTİ
        public async Task<IActionResult> GetPersonels()
        {
          var personels=await _repository.GetAllAsync();
          return Ok(personels);
        }

        // GET: api/Personels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personel>> GetPersonel(int id)
        {
            var personel =await _repository.GetByIdAsync(id);
            // personel yoksa
            if (personel == null)
            {
                // not found bulunamdı döndür
                return NotFound();
            }
            // personel varsa pesoneli getir
            return Ok(personel);
        }

        // PUT: api/Personels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonel(int id, Personel personel)
        { // parametre olarak yolladığım id degeri==personelin id eşitse aynıysa
            if (id != personel.Id)
            {
                return BadRequest(); // hatalı istek gonder 
            }
            _repository.Update(personel);
            return NoContent();
        }

        // POST: api/Personels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]  // ekleme işlemi için
        public async Task<ActionResult<Personel>> PostPersonel(Personel personel)
        {

            await _repository.Create(personel);

            return CreatedAtAction("GetPersonel", new { id = personel.Id }, personel);
        }

        // DELETE: api/Personels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonel(int id)
        {
            var personel = await _repository.GetByIdAsync(id);
            // kayıt yoksa
            if (personel == null)
            {
                return NotFound();
            }
            _repository.Delete(personel);
          
            return NoContent();
        }

        private bool PersonelExists(int id)
        {
           Personel personel=_repository.GetByIdAsync(id).Result;
            if(personel == null)
            {
                return false;
            }
            else
            {
            return true;
            }
        }
    }
}
