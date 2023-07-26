using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using PersonneAPI.Data.Repository.IRepository;
using PersonneAPI.Model;
using PersonneAPI.Model.DTO;
using System.Net;

namespace PersonneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonneController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonneRepository _dbPersonne;
        protected Response _response;

        public PersonneController(IMapper mapper, IPersonneRepository dbPersonne)
        {
            _mapper = mapper;
            _dbPersonne = dbPersonne;
            _response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Response>> GetAllPersonnes()
        {
            IEnumerable<Personne> personnes = await _dbPersonne.GetAllAsync();
            
            if(personnes == null || personnes.Count() == 0)
            {
                return NotFound(_response);
            }

             var personnesDTO = _mapper.Map<List<PersonneDTO>>(personnes);

            foreach (var pDTO in personnesDTO)
            {
                pDTO.Age = DateTime.Now.Year - pDTO.BirthDay.Year;
            }

            personnesDTO = personnesDTO.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();

            _response.Result = personnesDTO;

            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Response>> CreatePersonne([FromBody] PersonneDTO personneDTO)
        {
            if (personneDTO == null)
            {
                return BadRequest(_response);
            }

            var age = DateTime.Now.Year - personneDTO.BirthDay.Year;

            if(age >= 150)
            {
                ModelState.AddModelError("CustomError", "Limite d'âge dépassée");
                return BadRequest(_response);
            }

            Personne personne = _mapper.Map<Personne>(personneDTO);

            await _dbPersonne.CreateAsync(personne);

            _response.Result = _mapper.Map<PersonneDTO>(personne);
            _response.StatusCode = HttpStatusCode.Created;

            return Ok(_response);
        }

    }
}
