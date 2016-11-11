using System;

namespace ConsoleApplication1
{
    class TestAngle
    {
        static void Main()
        {
            try
            {
                int divider = 3, multiplier = 0; ;
                //Angle c1 = new Angle(56, 59, 59);
                //Angle c1 = new Angle(10, 10, 10);
                Angle c1 = new Angle(56, 50, 50);

                //Angle c2 = new Angle();
                //Angle c2 = new Angle(30, 30, 30);
                //Angle c2 = new Angle(360, 60, 60);
                //Angle c2 = new Angle(10, 10, 10);
                //Angle c2 = new Angle(66, 59, 59);
                //Angle c2 = new Angle(57, 10, 10);
                //Angle c2 = new Angle(56, 50, 51);
                Angle c2 = new Angle(56, 50, 49);
                
                Angle c3 = new Angle(12, 42, 32);
                 
                Console.WriteLine("angle A1 : " + c1.ToString());
                Console.WriteLine("angle A2 : " + c2.ToString());
                Console.WriteLine("angle A3 : " + c3.ToString());
                Console.WriteLine("----------------------");
                Console.WriteLine("Plus       : " + (c1 + c2).ToString());
                Console.WriteLine("Minus      : " + (c1 - c2).ToString());
                Console.WriteLine("----------------------");
                Console.WriteLine("Divide A1 / {0}: " + (c1 / divider).ToString(), divider--);
                Console.WriteLine("Divide A1 / {0}: " + (c1 / divider).ToString(), divider);
                Console.WriteLine("Divide A2 / {0}: " + (c2 / divider).ToString(), divider++);
                Console.WriteLine("Divide A2 / {0}: " + (c2 / divider).ToString(), divider);
                Console.WriteLine("----------------------");
                Console.WriteLine("Multiply A3 * {0}: " + (c3 * multiplier).ToString(), multiplier++);
                Console.WriteLine("Multiply A3 * {0}: " + (c3 * multiplier).ToString(), multiplier++);
                Console.WriteLine("Multiply A3 * {0}: " + (c3 * multiplier).ToString(), multiplier++);
                Console.WriteLine("Multiply A3 * {0}: " + (c3 * multiplier).ToString(), multiplier);
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {
                Console.WriteLine("Error: {0}", outOfRange.Message);
            } 
            catch (ArgumentException argExcept)
            {
                Console.WriteLine("Error: {0}", argExcept.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Just to be sure no other error will be triggered. Only in this project. Error: {0}", ex.Message);
            }
             
        }
    }
}
