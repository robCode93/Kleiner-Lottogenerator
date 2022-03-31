using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahlen_Raten
{
    internal class TestingClass
    {
        public int[] produceArray(int arraySize)
        {
            int[] array = new int[arraySize];
            return array;
        }

        public bool checkArrays(int[] numbers, int[] randNumbers)
        {
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(Array.Exists(randNumbers, x => x == numbers[i]))
                {
                    counter++;
                }
            }

            if(counter == numbers.Length)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public int startLoop(int start, int stop, int[] numbers)
        {
            int randNumber;
            int counter = 0;
            int[] randArray = produceArray(numbers.Length);
            bool won = false;
            // Max-Wert ist exklusiv
            Random random = new Random();

            do
            {
                counter++;
                Console.WriteLine("---------- ROUND {0} ----------", counter);

                for (int i = 0; i < numbers.Length; i++)
                {
                    randNumber = random.Next(start, stop + 1);
                    if (Array.Exists(randArray, x => x == randNumber))
                    {
                        while(Array.Exists(randArray, x => x == randNumber))
                        {
                            randNumber = random.Next(start, stop + 1);
                        }
                    }
                    else
                    {
                        randArray[i] = randNumber;
                    }
                        Console.WriteLine("[{0}. Wert]: {1}", i + 1, randArray[i]);
                }

                won = checkArrays(numbers, randArray);
                Console.WriteLine();

            } while (won == false);

            return counter;
        }
    }
}
