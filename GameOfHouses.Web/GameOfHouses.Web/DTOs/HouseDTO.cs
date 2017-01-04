using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfHouses.Web.DTOs
{
    public class HouseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CrestNumber { get; set; }
    }

}