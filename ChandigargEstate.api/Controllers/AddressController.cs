using ChandigarhEstates.Data;
using ChandigarhEstates.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChandigargEstate.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;
        public AddressController(ApplicationDbContext Context) 
        {
            _Context = Context;
        }

        [HttpGet("CountriesList")]
        public List<Country_Table> ListOfCountries()
        {
            return _Context.Countries.ToList();
        }

        [HttpGet("GetstateList")]
        public List<State_Table> ListOfStates()
        {
            return _Context.States.ToList();
        }

       
        [HttpGet("CityList")]
        public List<City_Table> GetCity(int id)
        {
            List<City_Table> cit = _Context.Cities.Where(c => c.StateId == id).ToList();
            return cit;
        }
    }
}
