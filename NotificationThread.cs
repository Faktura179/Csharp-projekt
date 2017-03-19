using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Media;

namespace Projekt
{
    class NotificationThread
    {

        private static volatile bool _stop = false;

        public static void StopThread()
        {
            _stop = true;
        }

        public static void Przypomnienia(string path)
        {

            List<Przypomnienie> plist = new List<Przypomnienie>();
            string str;

            while (true)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while ((str = sr.ReadLine()) != null)
                    {

                        Przypomnienie prz = null;

                        DateTime dt;
                        if (DateTime.TryParse(str.Split('#')[2], out dt))
                        {
                            string imp = str.Split('#')[0];
                            string desc = str.Split('#')[1];
                            prz = new Przypomnienie(imp, desc, dt);

                            if (!plist.Contains(prz))
                                plist.Add(prz);
                        }
                    }
                }

                Thread.Sleep(2000);

                foreach (Przypomnienie p in plist)
                {
                    if (DateTime.Now.Date == p.Time.Date && DateTime.Now.Hour == p.Time.Hour && DateTime.Now.Minute == p.Time.Minute && DateTime.Now.Second <= 4)
                    {
                        SystemSounds.Beep.Play();
                        MessageBox.Show(p.Description, "Przypomnienie", MessageBoxButtons.OK);
                    }
                }

                if (_stop)
                    break;
            }

        }
    }
}
