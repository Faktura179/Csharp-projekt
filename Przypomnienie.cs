using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt
{
    class Przypomnienie : Zdarzenie, INameable
    {
        private DateTime _time;

        public Przypomnienie(string imp, string desc, DateTime time) : base(imp, desc)
        {
            _time = time;
        }

        public DateTime Time
        {
            set { _time = value; }
            get { return _time; }
        }

        public override void Display()
        {
            Console.WriteLine("Ważność przypomnienia: {0}\nOpis przypomnienia: {1}\nCzas przypomnienia: {2}\n", base.Importance, base.Description, _time);
        }
    }
}
