using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pakizin.Helpers
{
    public class TimeHelper
    {
        public static string Greeting(int time)
        {
            string greeting = null;
            if (time < 11)
            {
                greeting = "Selamat Pagi";
            }
            else if (time > 11 && time < 15)
            {
                greeting = "Selamat Siang";
            }
            else if (time > 11 && time < 15)
            {
                greeting = "Selamat Sore";
            }
            else
            {
                greeting = "Selamat Malam";
            }
            return greeting;
        }
        public static string DateIndo(string timeExpode)
        {
            string[] tm = timeExpode.Split(' ');
            string newTime = "";

            string[] enDate = { "January",
                                "February",
                                "March",
                                "April",
                                "May",
                                "June",
                                "July",
                                "August",
                                "September",
                                "October",
                                "November",
                                "December"};
            string[] idDate = { "Januari",
                                "Februari",
                                "Maret",
                                "April",
                                "Mei",
                                "Juni",
                                "Juli",
                                "Agustus",
                                "September",
                                "Oktober",
                                "November",
                                "Desember"};
            int no = 0;
            foreach (var x in enDate)
            {
                if (tm[1].Equals(x))
                {
                    newTime = timeExpode.Replace(tm[1], idDate[no]);
                }
                no++;
            }
            return newTime;
        }
    }
}