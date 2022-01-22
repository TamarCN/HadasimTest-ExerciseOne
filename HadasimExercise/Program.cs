using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadasimExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ExerciseOne exerciseOne = new ExerciseOne();
                exerciseOne.TheMostCommonNames();
                System.Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
           

        }
    }
}
