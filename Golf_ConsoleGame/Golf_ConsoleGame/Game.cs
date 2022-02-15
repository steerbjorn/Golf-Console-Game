using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Golf_ConsoleGame
{
    public class Game
    {
        private List<Course> courseList;
        private PowerBar powerbar;
        private Course courseRef;

        public Game(List<Course> courseList, PowerBar powerbar, Course courseRef)
        {
            this.courseList = courseList;
            this.powerbar = powerbar;
            this.courseRef = courseRef;
        }

        public void GamePlay()
        {

            // TODO: Add out-of-bounce check
            // TODO: Return score in GamePlay

            foreach (var course in courseList)
            {
                Console.WriteLine("Course: " + course + ", total distance: " + course.courseCupLoc);

                while (!course.courseComplete)
                {
                    course.HitBall(powerbar);
                }
            }
        }
    }
}
