using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Program
    {
        static void Main(string[] args)
        {
            //Used for modeling the average time it takes for a car to use the Zip Zip merging model
            Console.Write("Enter the number of toll booths: ");
            double numTolls = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the number of final number of lanes you will merge the traffic into: ");
            double finalNumLanes = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the time delay at each toll booth per car: ");
            double boothDelay = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter how many cars do you want to use in the simulation: ");
            double numCars = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the rate of acceleration per car: ");
            double carsAcc = Convert.ToDouble(Console.ReadLine());

            double aveTime = 0.0;  //final average time per car
            double numMerges = 0.0;
            const double mergeDistance = 200.0;

            // Determine how many tapers are needed to get the overall length of the merging zone
            // Each merge reduces the number of lanes by either a quarter or 1, whichever is greater
            while(numTolls > finalNumLanes)
            {
                numMerges += 1.0;
                int newNumLanes = (int)(.25 * numTolls);
                if(newNumLanes > 1)
                {
                    numTolls -= newNumLanes;
                }
                else
                {
                    numTolls--;
                }
            }



            for (int i = 0; i < numCars; i++)
            {
                aveTime += boothDelay;      //time in toll booth

                // total distance a car will travel in merging zones
                double distance = numMerges* mergeDistance;

                // Determine how long each car will take to travel through the merging zone
                // Kinematic Equation: d = (1/2)*a*t^2 => t =  (2d/a)^(1/2)
                // Length of taper when merging two lanes is: L = W * S for speeds greater than 45 mph, W is width of closed lane, S is posted speed limit
                double time = Math.Sqrt(2.0 * (distance / carsAcc));
                aveTime += time;
                
            }

            aveTime /= numCars;

            // assume the lanes are 12 feet wide which is the norm for interstate (TODO: find documentation)
            // use this info in the lane shift formula



            Console.ReadKey();
        }
    }
}
