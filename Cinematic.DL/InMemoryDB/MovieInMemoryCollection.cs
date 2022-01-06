using Cinematic.Models.DTO;
using System.Collections.Generic;

namespace Cinematic.DL.InMemoryDB
{
    class MovieInMemoryCollection
    {
        public static List<Movie> MovieDB = new List<Movie> {

        new Movie()
        {
             id=1,
             Name="Fast and furious 1",
             Genre="Äction",
             Rating=Models.Enums.Rating.Excellent,
             Duration=120,
             Price=5

            },
           new Movie()
        {
             id=2,
             Name="Matrix",
             Genre="Äction",
             Rating=Models.Enums.Rating.Average,
             Duration=110,
             Price=5.50

            },
              new Movie()
        {
             id=1,
             Name="Ice Age",
             Genre="Comedy",
             Rating=Models.Enums.Rating.Good,
             Duration=115,
             Price=3

            },
    };
    }
}