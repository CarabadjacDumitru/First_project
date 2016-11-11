using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class Angle
    {
        #region Constants
        private const int MAX_SECONDS = 60, MIN_SECONDS = 0;
        private const int MAX_MINUTES = 60, MIN_MINUTES = 0;
        private const int MAX_GRADES = 360, MIN_GRADES = 0;
        #endregion Constants

        #region Properties
        public int Grade { get; private set; }
        public int Minute { get; private set; }
        public int Second { get; private set; }
        #endregion Properties

        #region Constructors
        public Angle()
        {
            Grade = 0;
            Minute = 0;
            Second = 0;
        }

        public Angle(int grades, int minutes, int seconds)
        {
            if (seconds >= MAX_SECONDS || seconds < MIN_SECONDS ||
                 minutes >= MAX_MINUTES || minutes < MIN_MINUTES ||
                 grades >= MAX_GRADES || grades < MIN_GRADES)
            {
                throw new ArgumentOutOfRangeException("Angle values out of range, further working with such values is immposible");
            }
            else
            {
                Second = seconds;
                Minute = minutes;
                Grade = grades;
            }
        }
        #endregion Constructors

        #region Operators
        public static Angle operator +(Angle c1, Angle c2)
        {
            Angle c3 = new Angle();
            int result = 0;

            result = c1.Second + c2.Second;
            if (result >= MAX_SECONDS)
            {
                c3.Minute++;
                result -= MAX_SECONDS;
            }
            c3.Second = result;

            result = c1.Minute + c2.Minute + c3.Minute;
            if (result >= MAX_MINUTES)
            {
                c3.Grade++;
                result -= MAX_MINUTES;
            }
            c3.Minute = result;

            result = c1.Grade + c2.Grade + c3.Grade;
            if (result >= MAX_GRADES)
            {
                throw new ArgumentOutOfRangeException("Operation for decreasing angles failed");
            }
            c3.Grade = result;

            return c3;
        }

        public static Angle operator -(Angle c1, Angle c2)
        {
            Angle c3 = new Angle();
            int result = 0;

            result = c1.Second - c2.Second;
            if (result < MIN_SECONDS)
            {
                result += 60;
                c3.Minute = -1;
            }
            c3.Second = result;

            result = c1.Minute - c2.Minute + c3.Minute;
            if (result < MIN_MINUTES)
            {
                result += 60;
                c3.Grade = -1;
            }
            c3.Minute = result;
            
            result = c1.Grade - c2.Grade + c3.Grade;
            if (result < MIN_GRADES)
                throw new ArgumentOutOfRangeException("Erroneous Angle", "Deacreasing of two angles failed");

            c3.Grade = result;
            return c3;
        }

        public static Angle operator /(Angle c1, int divider)
        {
            if (divider <= 0 || divider > MAX_GRADES)
                throw new ArgumentException("Erroneous divider value", "Cannot divide angle in " + divider + " parts");

            int convertedAngle1 = (c1.Grade * 3600 + c1.Minute * 60 + c1.Second) / divider;

            Angle c2 = new Angle();
            c2.Grade = convertedAngle1 / 3600;
            c2.Second = convertedAngle1 % 60;
            c2.Minute = (convertedAngle1 - c2.Grade * 3600 - c2.Second) / 60;
            
            return c2;
        }

        public static Angle operator *(Angle c1, int multiplier)
        {
            if (multiplier > MAX_GRADES)
                throw new ArgumentException("Erroneous multiplier value", "Cannot multiply angle to " + multiplier);

            int convertedAngle1 = (c1.Grade * 3600 + c1.Minute * 60 + c1.Second) * multiplier;

            Angle c2 = new Angle();
            c2.Grade = convertedAngle1 / 3600;
            c2.Second = convertedAngle1 % 60;
            c2.Minute = (convertedAngle1 - c2.Grade * 3600 - c2.Second) / 60;

            return c2;
        }

        #endregion Operators

        public override string ToString()
        {
            return string.Format("The Angle is     : {0,3:D}°{1,2:D}'{2,2:D}" + @"""", Grade, Minute, Second);
        }
    }
}