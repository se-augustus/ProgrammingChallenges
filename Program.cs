using System;
using System.Text.RegularExpressions;

namespace TalkingClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is an alarm clock.");
            Console.WriteLine("Enter a time in 24 (0-23), and I will tell you the time in words");
            Console.WriteLine("Enter a Time below: \n");
            Console.WriteLine("Enter hour: ");

            var hour = Console.ReadLine();

            while (!Validate(hour) || hour.Length > 2 || int.Parse(hour) > 23)
            {
                Console.WriteLine("Enter hour: ");
                hour = Console.ReadLine();

            }

            Console.WriteLine("Enter minute: ");

            var minute = Console.ReadLine();

            while (!Validate(minute) || minute.Length > 2 || int.Parse(minute) > 59)
            {
                Console.WriteLine("Enter minute: ");
                minute = Console.ReadLine();
            }



            var dt = ConvertToDateTime(hour, minute);
            Console.WriteLine("It's " + dt + " ");
        }

        private static bool Validate(string somethingtocheck)
        {
            var reggie = new Regex("^[0-9]*$");

            return reggie.IsMatch(somethingtocheck);
        }


        private static string ConvertToDateTime(string hour, string minutes)
        {

            string[] singles = { "twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve" };
            string[] decades = { "twenty", "thirty", "forty", "fifty" };
            string[] adolescent = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

            var time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, int.Parse(hour), int.Parse(minutes), 00);

            var h = string.Empty;
            var m = string.Empty;
            var mm = string.Empty;
            var am = string.Empty;
            var tm = Convert.ToInt16(time.Minute);
            try
            {
                h = singles[time.Hour];
                am = "a.m.";
            }

            catch (Exception e)
            {
                h = singles[time.Hour % 10 - 2];
                am = "p.m.";
            }

            if (tm / 10 > 1)
            {

                m = decades[tm / 10 - 2];

                if (tm % 10 != 0)
                {
                    mm = singles[(tm % 10)];
                }
            }

            else if (tm / 10 > 0)
            {
                m = adolescent[tm % 10];
            }
            else
            {
                mm = "oh " + singles[tm % 10];
            }

            return h + " " + m + " " + mm + " " + am;

        }

    }
}
