using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace course
{
    static class Arrange
    {
        private static Random random = new Random();
        public static List<ClassChoice> arrange(List<ClassChoice> choices)
        {
            return arrangeCourse(randomList(choices));
        }
        public static List<ClassChoice> arrange(List<ClassChoice> neededChoices, List<ClassChoice> choices)
        {
            var newList = randomList<ClassChoice>(neededChoices);
            var newList2 = randomList(choices);
            newList.AddRange(newList2);

            return arrangeCourse(newList);
        }
        private static List<ClassChoice> arrangeCourse(List<ClassChoice> randomChoices)
        {
            List<ClassChoice> solution = new List<ClassChoice>();
            
            foreach (ClassChoice cc1 in randomChoices)
            {
                foreach (ClassChoice cc2 in solution)
                {
                    if (cc2.IsConflictWith(cc1))
                    {
                        goto label1;
                    }
                }
                solution.Add(cc1);
                
            label1: ;
            }
            return solution;
        }
        public static List<T> randomList<T>(List<T> list)
        {
            var newList = new List<T>();
            foreach (var t in list)
            {
                newList.Insert(random.Next(newList.Count), t);
            }
            return newList;
        }
    }
}
