using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Projekt
{
    class TrayIconThread
    {

        private static volatile bool _stop = false;


        public static void StopThread()
        {
            _stop = true;
        }


        public static void Ikonka()
        {
            while (!_stop)
            {
                Icon programmeicon = new Icon(SystemIcons.Application, 32, 32);
                NotifyIcon icon = new NotifyIcon();
                icon.Icon = programmeicon;
                icon.Visible = true;

                Thread.Sleep(100);
            }

        }

    }
}
