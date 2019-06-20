using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class Kohviautomaat
    {

        public int Id { get; set; }
        public string JoogiNimi { get; set; }
        public int TopsePakis { get; set; } = 50;

        public int TopseJuua { get; set; }

        
       



    }
}