using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface ICup
    {
        public string Volume { get; set; }
        public string Type { get; set; }
        public string Relif();
        public string Wash();
        public void Preview();
    }
}
