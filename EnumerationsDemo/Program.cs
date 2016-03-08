using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var draw = new Draw();
            draw.DrawLine(LineStyle.DotDash);
            draw.DrawLine((LineStyle) 2);

            var check = Enum.IsDefined(typeof(LineStyle), "DashDash");
            Console.WriteLine("IsDefined \"DashDash\": {0}", check);

            //bit flags demo

            DaysOfWeek dow;
            //"|" is a logic operator (works at binary level), not conditional
            //bits 0010101
            dow = DaysOfWeek.Monday | DaysOfWeek.Wednesday | DaysOfWeek.Friday;
            //!!!
            Console.WriteLine(dow);
            if ((dow & DaysOfWeek.Monday) == DaysOfWeek.Monday)
            {
                Console.WriteLine("Monday included");
            }

            //bit flags practical example
            var gym = new Task
            {
                Title = "Go to gym",
                ScheduledDay = DaysOfWeek.Monday | DaysOfWeek.Wednesday | DaysOfWeek.Friday
            };

            var rest = new Task
            {
                Title = "Rest at home",
                ScheduledDay = DaysOfWeek.Friday | DaysOfWeek.Saturday | DaysOfWeek.Sunday
            };

            var schedule = new List<Task>();
            schedule.Add(gym);
            schedule.Add(rest);

            var friday = schedule.Where(x => x.ScheduledDay.HasFlag(DaysOfWeek.Friday)).Select(x => x.Title).ToList();
            var saturday = schedule.Where(x => x.ScheduledDay.HasFlag(DaysOfWeek.Saturday)).Select(x => x.Title).ToList();
            var fridayAndSaturday = schedule.Where(x =>
                x.ScheduledDay.HasFlag(DaysOfWeek.Saturday) &&
                x.ScheduledDay.HasFlag(DaysOfWeek.Friday)
                ).Select(x => x.Title).ToList();
            var mondayAndWednesday = schedule.Where(x =>
                x.ScheduledDay.HasFlag(DaysOfWeek.Monday) &&
                x.ScheduledDay.HasFlag(DaysOfWeek.Wednesday)
                ).Select(x => x.Title).ToList();
            var mondayOrSunday = schedule.Where(x =>
                x.ScheduledDay.HasFlag(DaysOfWeek.Monday) ||
                x.ScheduledDay.HasFlag(DaysOfWeek.Sunday)
                ).Select(x => x.Title).ToList();

            Console.ReadLine();
        }
    }

    public class Draw
    {
        public void DrawLine(LineStyle lineStyle)
        {
            Console.WriteLine(lineStyle.ToString());
        }
    }

    public enum LineStyle
    {
        None = 0,
        Solid = 1,
        Dotted = 2,
        DotDash = 3,
    }

    #region bit flags

    /// <summary>
    /// Each enum represents a collection of flags, rather then a single value
    /// 
    /// Multiple values assigned to one enum
    /// 
    /// http://www.codeproject.com/Articles/396851/Ending-the-Great-Debate-on-Enum-Flags
    /// 
    /// Monday =    0000001
    /// Tuesday =   0000010
    /// Wednesday = 0000100
    /// Thursday =  0001000
    /// Friday =    0010000
    /// Saturday =  0100000
    /// Sunday =    1000000
    /// </summary>
    [Flags]
    public enum DaysOfWeek
    {
        //bit shifting
        Monday = 1,
        Tuesday = 1 << 1,
        Wednesday = 1 << 2,
        Thursday = 1 << 3,
        Friday = 1 << 4,
        Saturday = 1 << 5,
        Sunday = 1 << 6,
    }

    public class Task
    {
        public string Title { get; set; }
        public DaysOfWeek ScheduledDay { get; set; }
    }

    #endregion
}
