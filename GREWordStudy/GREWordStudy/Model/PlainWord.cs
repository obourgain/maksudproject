using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GREWordStudy.Model
{
    public class PlainWord
    {
        public int RememberPercentile
        {
            get
            {
                if (Remembered + Forgotten == 0)
                    return -1;
                else
                    return (int)((double)Remembered * 100.0 / (double)(Remembered + Forgotten));
            }
        }

        public double Forgotten { get; set; }

        public double Remembered { get; set; }

        public string Word { get; set; }

        public int Hardness { get; set; }
    }
}
