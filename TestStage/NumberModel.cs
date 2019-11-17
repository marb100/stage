using System;
using System.Collections.Generic;
using System.Text;

namespace TestStage
{
    public class NumberModel
    {
        public int Key { get; set; }
        public int Total { get; set; }

        public NumberModel(int key, int total)
        {
            this.Key = key;
            this.Total = total;
        }
    }
}
