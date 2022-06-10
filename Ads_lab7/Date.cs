using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS_Hashtable
{
    struct Date
    {
        public int year;
        public string month;
        public int day;
        public Date(int day, string month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public static int Converter(String month)
        {
            month = month.ToLower();
            Dictionary<String, int> converter = new Dictionary<string, int>() { 
                { "січня", 1 },
                {"лютого",2 },
                {"березня",3 },
                {"квітня",4 },
                {"травня",5 },
                {"червня",6 },
                {"липня",7 },
                {"серпня",8 },
                {"вересня",9 },
                {"жовтня",10 },
                {"листопада",11},
                {"грудня",12 }
            };

            return converter[month];           
        }


        public static int countLeapYears(Date d)
        {
           
            int years = d.year;
            if (Converter(d.month) <= 2)
            {
                years--;
            }
            return years / 4 - years / 100 + years / 400;
        }
        public static int getDifference(Date dt1, Date dt2)
        {
            int[] monthDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            int n1 = dt1.year * 365 + dt1.day;

            for (int i = 0; i < Converter(dt1.month) - 1; i++)
                n1 += monthDays[i];

            n1 += countLeapYears(dt1);
            int n2 = dt2.year * 365 + dt2.day;
            
            for (int i = 0; i < Converter(dt2.month) - 1; i++)
                n2 += monthDays[i];

            n2 += countLeapYears(dt2);

            return n2 - n1;
        }

        public override string ToString()
        {
            return day + " " + month + " " + year;
        }
    }
}
