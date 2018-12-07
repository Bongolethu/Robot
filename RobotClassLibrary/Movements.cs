using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotClassLibrary
{
    /// <summary>
    /// This class is responsible of moving a robot on a floor grid. The direction and steps taken
    /// are represented as an input string from a console application
    /// The position the robot is in initial is calculated as a step
    /// </summary>
    public class Movements
    {
        private static string _stepsByDirection = string.Empty;
        private static string[] _stepsByDirectionArray = null;
        private static List<PositionSteps> _listPositionSteps = null;

        private const string _compass = "NSEW";
        public Movements()
        {
        }

        public Movements(string stepsByDirection)
        {
            _stepsByDirection = stepsByDirection;
        }
        public static int MoveRobot(string stepsByDirectionArray)
        {
            var stepsByDirection = SplitCommaDelimeteredMovementsStringToArray();
            int numberOfSteps = 0;
            foreach (var stepByDirection in stepsByDirection)
            {
                numberOfSteps = GetStepsTakenByRobotFromMovementArrayElements(stepByDirection);
            }
            return numberOfSteps;
        }
        /// <summary>
        /// This method gets and splits the input string into an array of steps by direction
        /// </summary>
        /// <param name="stepsByDirection"></param>
        /// <returns></returns>
        public static string[] SplitCommaDelimeteredMovementsStringToArray()
        {
            try
            {
                _stepsByDirectionArray = _stepsByDirection.Split(',');
                return _stepsByDirectionArray;
            }
            catch
            {
                throw new ArgumentOutOfRangeException("invalid string stepsByDirectionArray");
            }
        }
        /// <summary>
        /// This method builds steps for the robot movements from the input element of steps by direction.
        /// </summary>
        /// <param name="movementArrayElements"></param>
        /// <returns></returns>
        public static int GetStepsTakenByRobotFromMovementArrayElements(string movementArrayElements)
        {
            int pass = 1;

            #region validate the element split from the input string
            if (movementArrayElements == string.Empty)
                throw new FormatException("invalid element charactors");
            if (movementArrayElements.Length < 2)
                throw new FormatException("invalid element charactors");
            if (!_compass.Contains(movementArrayElements.Substring(0, 1)))
                throw new FormatException("invalid element charactors");
            if (!Int32.TryParse(movementArrayElements.Remove(0, 1), out pass))
                throw new FormatException("invalid element charactors");
            PositionSteps positionSteps = null;
            #endregion
            //We have a constructor overloaded because according to the assessment they count the position before the robot moves as a step
            try
            {
                if (_listPositionSteps == null)
                {
                    positionSteps = new PositionSteps();
                    positionSteps.Direction = movementArrayElements.Substring(0, 1);
                    positionSteps.TotalSteps = Convert.ToInt32(movementArrayElements.Remove(0, 1));
                    positionSteps.LastCoordinate = "0,0";
                    positionSteps.StepsArray = positionSteps.BuildStepsArray(movementArrayElements);
                    _listPositionSteps = new List<PositionSteps>();
                }
                else
                {
                    string i = _listPositionSteps[_listPositionSteps.Count - 1].LastCoordinate;
                    positionSteps = new PositionSteps(movementArrayElements, i);
                }

                _listPositionSteps.Add(positionSteps);
                #region The thinking is that I get combine all the steps taken and remove the duplicates which will eliminate the repeat on blocks

                string[] duplicates = _listPositionSteps[0].StepsArray;

                for (int item = 1; item < _listPositionSteps.Count; item++)
                {
                    int currentArraySize = duplicates.Length;
                    Array.Resize<string>(ref duplicates, duplicates.Length + _listPositionSteps[item].StepsArray.Length);
                    _listPositionSteps[item].StepsArray.CopyTo(duplicates, currentArraySize);
                }

                #endregion

                return duplicates.Distinct().Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
