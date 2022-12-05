using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2022
{
    internal class Problem
    {
        private Problem(int year, int day, int part)
        {
            Year = year;
            Day = day;
            Part = part;
        }

        public int Year { get; }
        public int Day { get; }
        public int Part { get; }

        internal class Builder
        {
            private int _year;
            private int _day;
            private int _part;

            internal Builder()
            {
                SetDefaults();
            }

            public Problem Build()
            {
                return new Problem(_year, _day, _part);
            }

            public void SetDefaults()
            {
                DateTime now = DateTime.Now;
                SetYear(now.Year);
                SetDay(now.Day);
                SetPart(1);
            }

            public Builder SetYear(int year)
            {
                _year = ValidateYear(year);
                return this;
            }

            public Builder SetDay(int day)
            {
                _day = ValidateDay(day);
                return this;
            }

            public Builder SetPart(int part)
            {
                _part = ValidatePart(part);
                return this;
            }

            private int ValidateYear(int year)
            {
                if (year < 2015)
                {
                    throw new ArgumentOutOfRangeException(nameof(year), "problem year may not precede 2015");
                }
                DateTime now = DateTime.Now;
                if ((year > now.Year) || year == now.Year && now.Month < 12)
                {
                    throw new ArgumentOutOfRangeException(nameof(year), "problem year is not yet available");
                }

                return year;
            }

            private int ValidateDay(int day)
            {
                if (day is < 0 or > 25)
                {
                    throw new ArgumentOutOfRangeException(nameof(day),
                        "problem day must be between 1 and 25 inclusive");
                }

                return day;
            }

            private int ValidatePart(int part)
            {
                if (part is < 1 or > 2)
                {
                    throw new ArgumentOutOfRangeException(nameof(part), "problem part may only be 1 or 2");
                }

                return part;
            }
        }
    }
}
