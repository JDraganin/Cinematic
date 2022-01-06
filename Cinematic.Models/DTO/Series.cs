﻿using Cinematic.Models.Enums;

namespace Cinematic.Models.DTO
{
    public  class Series
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public string Genre { get; set; }
        public Rating Rating { get; set; }
        public double Price { get; set; }
        public int seasons { get; set; }
    }
}
