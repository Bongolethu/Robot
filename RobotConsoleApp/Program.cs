using RobotClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //N1,S1,E1,W1,S1,N1,W1,E1
            //N4,E2,S2,W4
            try
            {
                Console.Write("Please give the Robot Instruction \n ");
                string stepsByDirection = Console.ReadLine();
                Movements move = new Movements(stepsByDirection);
                int numberOfSteps = Movements.MoveRobot(stepsByDirection);
                Console.WriteLine(String.Format("Number of unit bocks is : {0} ", numberOfSteps.ToString()));
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();
            }
        }
    }
}
