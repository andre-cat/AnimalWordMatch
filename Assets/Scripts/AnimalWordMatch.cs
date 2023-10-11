namespace AnimalWordMatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class List
    {
        private static readonly Random range = new();

        public static List<T> Shuffle<T>(List<T> list)
        {
           return list.OrderBy(a => range.Next()).ToList();
        }
    }


}