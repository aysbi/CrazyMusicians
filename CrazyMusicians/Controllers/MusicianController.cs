using CrazyMusicians.DTOs;
using CrazyMusicians.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        [HttpGet]

        public List<Musician> Get()
        {
            return Data.Musicians();
        }

        [HttpGet("{id}")]

        public ActionResult<Musician> Get(int id)
        {
            Musician? musician = Data.Musicians().FirstOrDefault(x => x.Id == id);

            if (musician == null)
                return NotFound();

            return musician;
        }

        [HttpPost] 

        public ActionResult<Musician> Post(NewMusicianDTO newMusician)
        {
            var id = Data.Musicians().Max(x => x.Id) + 1;
            Musician musician = new Musician() { Id = id, Name = newMusician.Name, Occupation = newMusician.Occupation, Description = newMusician.Description};
            Data.Musicians().Add(musician);

            return CreatedAtAction(nameof(Get), new {id = musician.Id}, musician);
        }

        [HttpPut("{id}")]

        public ActionResult Put(int id, UpdateMusicianDTO dTO)
        {
            if (id != dTO.Id) 
                return BadRequest();

            Musician musician = Data.Musicians().FirstOrDefault(x => x.Id == id);

            if (musician == null)
                return NotFound();

            musician.Name = dTO.Name;
            musician.Occupation = dTO.Occupation;
            musician.Description = dTO.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            Musician? musician = Data.Musicians().FirstOrDefault(x => x.Id == id);

            if (musician == null)
                return NotFound();

            Data.Musicians().Remove(musician);

            return NoContent();
        }

        [HttpPatch("rewrite-description/{id:int:min(1)}")]

        public ActionResult<IEnumerable<Musician>> rewriteDescription(int id, string newDescription, [FromBody] JsonPatchDocument<Musician> patchDocument)
        {
            Musician? musician = Data.Musicians().FirstOrDefault(x => x.Id == id);

            if (musician == null)
                return NotFound();

            musician.Description = newDescription;

            patchDocument.ApplyTo(musician);

            return NoContent();
        }

        [HttpGet("search")]

        public ActionResult<IEnumerable<Musician>> Search([FromQuery] string name)
        {
            var musician = Data.Musicians().Where(x => x.Name == name).FirstOrDefault();

            return Ok(musician);
        } 
    }
}
