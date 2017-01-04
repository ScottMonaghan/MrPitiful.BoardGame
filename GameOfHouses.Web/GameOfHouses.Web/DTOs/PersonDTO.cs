using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameOfHouses.Logic;

namespace GameOfHouses.Web.DTOs
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public HouseDTO House { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }
        public String Residence { get; set; }
        public String FullNameAndAge { get; set; }
        public String FullNameAndAgeWithLinks { get; set; }
        public String Relation { get; set; }
    }
}