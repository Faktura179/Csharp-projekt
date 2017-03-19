using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekt
{
    class Tools
    {

        public static int Getint()
        {
            while (true)
            {
                int a;
                try
                {
                    a = int.Parse(Console.ReadLine());
                    return a;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " Spróbuj jeszcze raz.");
                }
            }
        }

        public static void DodajNotatke(string path)
        {
            Console.Clear();
            Console.WriteLine("Podaj ważność notatki: ");
            string imp = Console.ReadLine();
            Console.WriteLine("Podaj opis notatki: ");
            string desc = Console.ReadLine();
            Console.WriteLine("Podaj tytuł notatki: ");
            string title = Console.ReadLine();

            try
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine("{0}#{1}#{2}", imp,desc,title); 
                sw.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Operacja nie powiodła się: " + ex.Message);
                Console.ReadLine();
            }

            return;
        }

        public static void DodajPrzypomnienie(string path)
        {
            Console.Clear();
            Console.WriteLine("Podaj ważność przypomnienia: ");
            string imp = Console.ReadLine();
            Console.WriteLine("Podaj opis przypomnienia: ");
            string desc = Console.ReadLine();
            Console.WriteLine("Podaj datę przypomnienia(rok-miesiąc-dzień[ godzina:minuty]): ");
            DateTime date;
            while (true)
            {
                try
                {
                    date = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Operacja nie powiodła się: " + ex.Message + " Spróbuj jeszcze raz.");
                    Console.ReadLine();
                }
            }

            try
            {
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine("{0}#{1}#{2}", imp, desc, date.ToString()); 
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operacja nie powiodła się: " + ex.Message);
                Console.ReadLine();
            }

            return;
        }

        public static void PokazWydarzenia(string path)
        {
            Console.Clear();

            StreamReader sr = null;

            try
            {
                sr = new StreamReader(path);

                string str;
                ushort n = 1;
                while ((str = sr.ReadLine()) != null)
                {
                    if (str.Split('#').GetLength(0) != 3)
                        continue;

                    string imp = str.Split('#')[0];
                    string desc = str.Split('#')[1];
                    DateTime dt;
                    if (DateTime.TryParse(str.Split('#')[2], out dt))
                    {
                        Przypomnienie prz = new Przypomnienie(imp, desc, dt);
                        Console.Write(n + ".) ");
                        prz.Display();
                    }else
                    {
                        string title = str.Split('#')[2];
                        Notatka nt = new Notatka(imp, desc, title);
                        Console.Write(n + ".) ");
                        nt.Display();
                    }
                    n++;
                }

                sr.Close();

            }catch(Exception ex)
            {
                Console.WriteLine("Wystapił błąd: " + ex.Message + " Spróbuj jeszcze raz.");
            }
            finally
            {
                if(sr != null)
                    sr.Close();
               // Console.ReadLine();
                
            }
        }

        public static void Usunwydzarzenie(string path)
        {
            PokazWydarzenia(path);
            Console.WriteLine("Które wydarzenie chcesz usunąć(dodatni numer, 0 aby anulować) : ");
            ushort n;
            while (true)
            {
                try
                {
                    n = ushort.Parse(Console.ReadLine());
                    break;
                }catch(FormatException)
                {
                    Console.WriteLine("Nieprawidłowa liczba. Spróbuj jeszcze raz.");
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + " Spróbuj jeszcze raz.");
                }
            }

            if(n == 0)
                return;

            try
            {
                string[] arrLines = File.ReadAllLines(path);
                List<string> list = arrLines.ToList();
                list.RemoveAt(n - 1);
                arrLines = list.ToArray();
                File.WriteAllLines(path, arrLines);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " Spróbuj jeszcze raz.");
                Console.ReadLine();
            }
        }
    }
}
