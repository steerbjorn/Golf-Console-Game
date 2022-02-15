using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Golf_ConsoleGame
{
    public class PowerBar
    {
        private readonly Thread t;

        public int Max { get; set; } = 10;
        public char PowerChar { get; set; } = 'X';
        public int Delay { get; set; } = 100;
        public int Value { get; set; }
        public bool Running { get; set; }

        public PowerBar()
        {
            t = new Thread(() => Work())
            {
                IsBackground = true
            };

            t.Start();
        }

        public void Start()
        {
            WriteOutline();
            Value = 1;
            Running = true;
        }

        public void Stop()
        {
            Running = false;
        }

        private void Work()
        {
            int sign = 1;
            while (true)
            {
                if (!Running)
                    continue;

                if (Value == Max)
                    sign = -1;
                else if (Value == 0)
                    sign = 1;

                if (sign == -1)
                {
                    try
                    {
                        Console.CursorLeft--;
                    }
                    catch (Exception)
                    {
                        Console.CursorLeft = 0;
                    }

                    Console.Write(" ");
                    Console.CursorLeft = Value--;
                }
                else
                {
                    Console.Write(PowerChar);
                    Value++;
                }

                Thread.Sleep(Delay);
            }
        }

        private void WriteOutline()
        {
            Console.CursorLeft = 0;
            Console.Write("[");
            Console.CursorLeft = Max + 1;
            Console.Write("]");
            Console.CursorLeft = 1;
        }
    }
}
