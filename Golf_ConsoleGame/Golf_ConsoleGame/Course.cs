using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Golf_ConsoleGame
{
    public class Course
    {
        private string courseName;
        double courseStartLoc;        
        private int swingCount;
        private int totalScore;
        public bool courseComplete;
        public readonly double courseCupLoc;
        private readonly double courseMaxLenght;
        private double ballLocation;
        private bool behindCup;

        public Course(string courseName, double courseStartLoc, double courseCupLoc, double courseMaxLenght)
        {
            this.courseName = courseName;
            this.courseStartLoc = courseStartLoc;
            this.courseCupLoc = courseCupLoc;
            this.courseMaxLenght = courseMaxLenght;
        }

        public override string ToString()
        {
            return courseName;
        }
        public void GameOver()
        {
            if (swingCount > 10)
            {
                totalScore += 10;
                Console.WriteLine("Game over. Reason: ");
                throw new SwingOverloadException(string.Format("Too many swings. " + "Total Score", totalScore));
            }
            else if (ballLocation > courseMaxLenght)
            {
                totalScore += 10;
                Console.WriteLine("Game over. Reason: ");
                throw new OutOfBoundsException(string.Format("Out of bounds " + "Total Score", totalScore));
            }
        }

        public void HitBall(PowerBar powerbar)
        {
            double ballAngle = 0.77;

            Console.WriteLine("Press SPACE to swing");
            while (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {

                powerbar.Start();
                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {powerbar.Stop(); Console.Clear(); }

                int pwrVal = powerbar.Value;

                Console.WriteLine($"Power: {pwrVal}");
                
                Thread.Sleep(50);
                double ballSpeed = pwrVal * 4.5;
                double ballDistance = Math.Pow(ballSpeed, 2) / 9.8 * Math.Sin(2 * ballAngle);
                Console.WriteLine("You hit " + Math.Round(ballDistance) + " meters");
                swingCount++;
                totalScore++;

                if (!behindCup)
                    ballLocation += ballDistance;
                else
                    ballLocation -= ballDistance;

                double distanceFromCup = Math.Abs(courseCupLoc - ballLocation);

                behindCup = ballLocation > courseCupLoc;


                if (IsInTolerance(distanceFromCup, 10))
                {
                    courseComplete = true;
                    Console.WriteLine("COURSE COMPLETED: " + swingCount + " swings" + "\n");
                    swingCount = 0;
                    return;
                }
                    try
                    {
                        GameOver();
                    }
                    catch(SwingOverloadException e)
                    {
                        Console.WriteLine("SwingOverloadException: {0}", e.Message);
                    }
                    catch (OutOfBoundsException e)
                    {
                    Console.WriteLine("OutOfBoundsException: {0}", e.Message);
                }

                if (behindCup)
                {
                    Console.WriteLine($"You shot past the cup. Distance left: {Math.Round(distanceFromCup)}");
                }
                else
                {
                    Console.WriteLine($"Distance left to cup = {Math.Round(distanceFromCup)}m");
                    Console.WriteLine($"Ball Location = {Math.Round(ballLocation)}m");
                }
            }
        }
      

        private bool IsInTolerance(double distanceToCup, double tolerance)
        {
            if (distanceToCup <= tolerance && distanceToCup >= -tolerance)
                return true;
            else
                return false;
        }
    }
    public class SwingOverloadException : Exception
    {
        public SwingOverloadException(string swingMessage) : base(swingMessage)
        {}
    }
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException(string boundsMessage) : base(boundsMessage)
        {}
    }
}
