using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using GameOfHouses.Logic;
using GameOfHouses.Web.DTOs;
using static GameOfHouses.Web.Utility.Helpers;


namespace GameOfHouses.Web.Controllers
{
    

    [RoutePrefix("api/person")]
    public class PersionController : ApiController
    {

        // GET api/<controller>/5
        public PersonDTO Get(Guid id)
        {
            var game = (Game)HttpContext.Current.Application["Game"];
            var world = game.Players[0].House.World;
            var p = world.Population.SingleOrDefault(person => person.Id == id);
            return new DTOs.PersonDTO()
            {
                Id = p.Id,
                Age = p.Age,
                FullNameAndAge = p.FullNameAndAge,
                FullNameAndAgeWithLinks = GetFullNameAndAgeWithLinks(p),
                House = new HouseController().Get(p.House.Id),
                Name = p.Name,
                Residence = p.Household.Lordship.Name,
                Sex = p.Sex
            };
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}