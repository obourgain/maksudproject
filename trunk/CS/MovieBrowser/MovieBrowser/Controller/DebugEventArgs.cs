using System;

namespace MovieBrowser.Controller
{
    public class DebugEventArgs : EventArgs
    {
        public string Text { get; set; }

        public DebugEventArgs(string text)
        {
            Text = text;
        }

        public DebugEventArgs()
        {

        }

        public override string ToString()
        {
            return Text;
        }
    }
}