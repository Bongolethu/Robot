using NUnit.Framework; 
using RobotClassLibrary;
using System.Collections.Generic;

namespace RobotUnitTest
{
    [TestFixture]
    public class RobotMovementsTest
    {
        [Test]
        public void SplitCommaDelimeteredMovementsStringToArray([Values("N4,E2,S2,W4")] string stepsByDirection)
        {
            Movements movements = new Movements(stepsByDirection); 
            string[] stepsByDirectionArray = Movements.SplitCommaDelimeteredMovementsStringToArray();
            CollectionAssert.AreEqual(new string[] { "N4","E2","S2","W4" }, stepsByDirectionArray);
        }
        [Test]
        [ExpectedException(typeof(System.FormatException))]
        public void MovementArrayInvalidElementCharactors([Values("","2","N","2N","NN")]string movementArrayElements)
        {
            
            Movements movements = new Movements();
            int steps = 0;
            steps = Movements.GetStepsTakenByRobotFromMovementArrayElements(movementArrayElements);
            
        }
        [Test]
        public void MovementArrayValidElementCharactors([Values("E1", "S1", "W1", "N1","E1")]string movementArrayElements)
        {
        
            Movements movements = new Movements();
            int steps = 0;
            steps = Movements.GetStepsTakenByRobotFromMovementArrayElements(movementArrayElements);

        }
        [Test]
        public void StandardParameters([Values("N4", "E2", "S2", "W4")]string movementArrayElements)
        {

            Movements movements = new Movements();
            int steps = 0;
            steps = Movements.GetStepsTakenByRobotFromMovementArrayElements(movementArrayElements);

        }
        [Test]
        public void StarParameters([Values("N1", "S1", "E1", "W1","S1","N1","W1","E1")]string movementArrayElements)
        {

            Movements movements = new Movements();
            int steps = 0;
            steps = Movements.GetStepsTakenByRobotFromMovementArrayElements(movementArrayElements);

        }
        


    }
}
