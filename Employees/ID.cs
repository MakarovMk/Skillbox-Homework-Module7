using System;
using System.Collections.Generic;
using System.Text;

namespace Diary
{
    internal class ID
    {
        private static int count = 0;
        public int num { get; }
        public ID()
        {
            num = ++count;
        }
    }
}
