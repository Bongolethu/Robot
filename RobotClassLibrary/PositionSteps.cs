using System;
using System.Collections.Generic;
using System.Text;

namespace RobotClassLibrary
{
    public class PositionSteps
    {
        public int TotalSteps { get; set; }
        public string Direction { get; set; }
        public string[] StepsArray { get; set; }
        public string LastCoordinate { get; set; }//these coordinates tell me where the robot is at present
        private int _xCoordinate { get; set; }
        private int _yCoordinate { get; set; }
        private bool _initialSteps = false;
        public PositionSteps()
        {
            _initialSteps = true;
        }
        /// <summary>
        /// We have a constructor overloaded because according to the assessment they count the position before the robot moves as a step
        /// </summary>
        /// <param name="movementArrayElements"></param>
        /// <param name="lastCoordinate"></param>
        public PositionSteps(string movementArrayElements, string lastCoordinate)
        {
            LastCoordinate = lastCoordinate;
            Direction = movementArrayElements.Substring(0, 1);
            TotalSteps = Convert.ToInt32(movementArrayElements.Remove(0, 1));
            BuildStepsArray(movementArrayElements);
             
        }
        /// <summary>
        /// This method builds out the steps taken in a certain direction from an element created by the delimeter function 
        /// that splits the input string
        /// </summary>
        /// <param name="movementArrayElements"></param>
        /// <returns></returns>
        public string[] BuildStepsArray(string movementArrayElements)
        {
            StepsArray = new string[TotalSteps];
            _xCoordinate = Convert.ToInt32(LastCoordinate.Substring(0, LastCoordinate.IndexOf(",")));
            _yCoordinate = Convert.ToInt32(LastCoordinate.Remove(0, LastCoordinate.IndexOf(",")+1));
            try
            {
                for (int i = 0; i < TotalSteps; i++)
                {

                    LastCoordinate = "";
                    // Cator for the initial position as step 1
                    if (_initialSteps)
                    {
                        LastCoordinate += _xCoordinate.ToString() + "," + _yCoordinate.ToString();
                        StepsArray[i] = LastCoordinate;
                        _initialSteps = false;
                    }
                    else if (movementArrayElements.Substring(0, 1) == "N")
                    {
                        _yCoordinate++;
                        LastCoordinate += _xCoordinate.ToString() + "," + _yCoordinate.ToString();
                        StepsArray[i] = LastCoordinate;
                    }
                    else if (movementArrayElements.Substring(0, 1) == "E")
                    {
                        _xCoordinate++;
                        LastCoordinate += _xCoordinate.ToString() + "," + _yCoordinate.ToString();
                        StepsArray[i] = LastCoordinate;
                    }
                    else if (movementArrayElements.Substring(0, 1) == "S")
                    {
                        _yCoordinate--;
                        LastCoordinate += _xCoordinate.ToString() + "," + _yCoordinate.ToString();
                        StepsArray[i] = LastCoordinate;
                    }
                    else if (movementArrayElements.Substring(0, 1) == "W")
                    {
                        _xCoordinate--;
                        LastCoordinate += _xCoordinate.ToString() + "," + _yCoordinate.ToString();
                        StepsArray[i] = LastCoordinate;
                    }


                }

                return StepsArray;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }

}