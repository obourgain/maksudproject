namespace GREWordStudy.Model
{
    partial class GreWord
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
    }
}


