namespace GREWordStudy.Model
{
    partial class GreWord
    {
        public string RememberPercentile
        {
            get
            {
                if (Remembered + Forgotten == 0)
                    return "0";
                else
                    return string.Format("{0:0.0}", (double)Remembered * 100.0 / (double)(Remembered + Forgotten));
            }
        }
    }
}


