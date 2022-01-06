using Cinematic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinematic.Models.Requests
{
     public class MovieRequest
    {
        public string Name { get; set; }
        public double Duration { get; set; }
        public string Genre { get; set; }
        public Rating Rating { get; set; }

        public double Price { get; set; }
    }
}
