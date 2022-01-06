using Cinematic.Models.DTO;
using System;
using System.Collections.Generic;


namespace Cinematic.DL.InMemoryDB
{
    public class SeriesInMemoryCollection
    {
        public static List<Series> SeriesDB = new List<Series> {

        new Series()
        {
             id=1,
             Name="The Witcher",
             Genre="Äction",
             Rating=Models.Enums.Rating.Excellent,
             Duration=60,
             Price=10,
             seasons=2

            },
           new Series()
        {
             id=2,
             Name="The Walking Dead",
             Genre="Horror",
             Rating=Models.Enums.Rating.Terrible,
             Duration=40,
             Price=9,
             seasons=10

            },
                 new Series()
        {
             id=3,
             Name="The Vampire Diaries",
             Genre="Fantasy",
             Rating=Models.Enums.Rating.Average,
             Duration=50,
             Price=11,
             seasons=6

            },
    };
    }
}

