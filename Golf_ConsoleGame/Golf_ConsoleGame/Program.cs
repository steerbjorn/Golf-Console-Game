using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Golf_ConsoleGame
{      
    class Program
    {        
        static void Main(string[] args)
        {
            Course courseRef = new Course("", 0, 0, 0);
            Course one = new Course("Course 1", 0, 300.2, 500);
            Course two = new Course("Course 2", 0, 250.7, 500);
            Course three = new Course("Course 3", 0, 350.5, 500);
            Course four = new Course("Course 4", 0, 170.6, 500);
            Course five = new Course("Course 5", 0, 180.5, 500);
            Course six = new Course("Course 6",  0, 400.7, 500);
            Course seven = new Course("Course 7", 0, 320.9, 500);
            Course eight = new Course("Course 8", 0, 365.5, 500);
            Course nine = new Course("Course 9", 0, 375.3, 500);

            List<Course> courses = new List<Course>() { one, two, three, four, five, six, seven, eight, nine };            

            PowerBar powerbar = new PowerBar() { PowerChar = 'X', Max = 10, Delay = 35 };
            Game game = new Game(courses, powerbar, courseRef);

            game.GamePlay();
        }
    }
}
