using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Notatka : Zdarzenie, INameable
    {
        private string _title;

        public Notatka(string imp, string desc, string title) : base(imp, desc)
        {
            _title = title;
        }

        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        public override void Display()
        {
            Console.WriteLine("Ważność notatki: {0}\nOpis notatki: {1}\nTytuł notatki: {2}\n", base.Importance, base.Description, _title);
        }
    }
}
