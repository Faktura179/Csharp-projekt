using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
     abstract class Zdarzenie
    {
        private string _importance;
        protected string _description;

        public Zdarzenie(string imp, string desc)
        {
            _importance = imp;
            _description = desc;
        }

        public string Importance
        {
            get
            {
                return _importance;
            }

            set
            {
                _importance = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public abstract void Display();
    }
}
