using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w programie notatki!");
            string path = @"D:\Zdarzenia.txt";

            Thread notify = new Thread(() => NotificationThread.Przypomnienie(path));
            Thread iconThread = new Thread(()=>TrayIconThread.Ikonka());

            notify.Start();
            iconThread.Start();

            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                    Console.WriteLine("Stworzono plik do przechowywania notatek.");
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " Zamykanie aplikacji. Spróbuj ponownie.");
                Console.ReadLine();
                return;
            }

            bool f = true;

            while (f)
            {
                
                int x;
                Console.Write("Lista opcji:\n[1] Dodaj notatkę\n[2] Dodaj przypomnienie\n[3] Pokaż moje wydarzenia\n[4] Usuń Wydarzenie\n[5] Wyjdź\n\nPodaj liczbę: ");

                while ((x = Tools.Getint()) < 1 || x > 5)               
                    Console.WriteLine("Liczba poza zakresem. Spróbuj jeszcze raz.");
                
                switch (x)
                {
                    case 1:
                        Tools.DodajNotatke(path);                       
                        break;
                    case 2:
                        Tools.DodajPrzypomnienie(path);
                        NotificationThread.DodajPrzypomnienie();
                        break;
                    case 3:
                        Tools.PokazWydarzenia(path);
                        Console.ReadLine();
                        break;
                    case 4:
                        Tools.Usunwydzarzenie(path);
                        break;
                    case 5:
                        f = false;
                        break;
                }
                Console.Clear();              
            }

            TrayIconThread.StopThread();
            NotificationThread.StopThread();
            notify.Join();
            iconThread.Join();
        }
    }
}
