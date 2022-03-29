using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica5LINQ__Bernardo_Garcia_
{
    internal class Program
    {
        class Turista
        {
            public int CI { get; set; }
            public string NomTurista { get; set; }
            public string CodTour { get; set; }
            public int CodPaquete { get; set; }

            public Turista(int _ci, string _nom, string _codT, int _codP)
            {
                CI = _ci;
                NomTurista = _nom;
                CodTour = _codT;
                CodPaquete = _codP;
            }
        }
        class Tour
        {
            public string CodTour { get; set; }
            public string NomTour { get; set; }
            public string Responsable { get; set; }

            public Tour(string _ct, string _nom, string r)
            {
                CodTour = _ct;
                NomTour = _nom;
                Responsable = r;
            }
        }

        class Lugar
        {
            public string CodLugar { get; set; }
            public string NomLugar { get; set; }
            public int Paquete { get; set; }

            public Lugar(string _cl, string _nom, int _p)
            {
                CodLugar = _cl;
                NomLugar = _nom;
                Paquete = _p;
            }
        }

        class Turista_Lugar
        {
            public int CI { get; set; }
            public string IDLugar { get; set; }

            public Turista_Lugar(int _ci, string _idlugar)
            {
                CI = _ci;
                IDLugar = _idlugar;
            }
        }

        class Paquete
        {
            public int CodPaquete { get; set; }
            public string NomPaquete { get; set; }

            public Paquete(int _cod, string _nom)
            {
                CodPaquete = _cod;
                NomPaquete = _nom;
            }
        }

        static Turista[] turistas = { new Turista(123, "Elias Andrade", "TA", 4), 
                                      new Turista(234, "Moira Alen", "TA", 2), 
                                      new Turista(345, "Lony Labbe", "TG", 8), 
                                      new Turista(456, "Sidney Sommer", "TA", 3), 
                                      new Turista(567, "Ari Hass", "TG", 8), 
                                      new Turista(678, "Rita Asis", "TC", 5), 
                                      new Turista(789, "Marco Esteves", "TA", 3), 
                                      new Turista(890, "Julia Lang", "TG", 6), 
                                      new Turista(901, "Ingrid RamosAsis", "TC", 5), 
                                      new Turista(012, "Erick Kolbe", "TP", 1) };

        static Tour[] excursiones = { new Tour("TA", "Turismo Aventura", "Magic Tours"), 
                                      new Tour("TG", "Turismo Gastronómico", "Turismo Kronos"), 
                                      new Tour("TC", "Turismo Compras", "Eva's Tours Co."), 
                                      new Tour("TP", "Turismo Paseos", "Alex Tours") };

        static Lugar[] lugares = { new Lugar("PV", "Puerto Varas", 4), 
                                   new Lugar("BRLCH", "Bariloche", 3), 
                                   new Lugar("BRA", "Rio de Janeiro", 3), 
                                   new Lugar("CHLT", "Chalten", 1), 
                                   new Lugar("PA", "Punta Arenas", 5), 
                                   new Lugar("PN", "Puerto Natales", 8), 
                                   new Lugar("VAL", "Valdivia", 6), 
                                   new Lugar("BA", "Buenos Aires", 2), 
                                   new Lugar("SP", "San Pablo", 1), 
                                   new Lugar("FLO", "Florianópolis", 2) };

        static Turista_Lugar[] turista_visita = { new Turista_Lugar(123, "BRLCH"), new Turista_Lugar(123, "PV"), 
                                                  new Turista_Lugar(123, "BRA"), new Turista_Lugar(123, "FLO"), new Turista_Lugar(234, "SP"),
                                                  new Turista_Lugar(234, "BA"), new Turista_Lugar(345, "PN"), new Turista_Lugar(345, "VAL"), 
                                                  new Turista_Lugar(456, "BRA"), new Turista_Lugar(456, "BA"), new Turista_Lugar(567, "PN"), 
                                                  new Turista_Lugar(678, "PA"), new Turista_Lugar(678, "PV"), new Turista_Lugar(789, "BRA"), 
                                                  new Turista_Lugar(789, "SP"), new Turista_Lugar(789, "FLO"), new Turista_Lugar(890, "VAL"), 
                                                  new Turista_Lugar(890, "BRLCH"), new Turista_Lugar(901, "PA"), new Turista_Lugar(012, "CHLT") };

        static Paquete[] paquetes = { new Paquete(1, "Básico"), 
                                      new Paquete(2, "Económico"), 
                                      new Paquete(3, "Estandar"), 
                                      new Paquete(4, "Jubilados"), 
                                      new Paquete(5, "Familiar"), 
                                      new Paquete(6, "Todo incluido"), 
                                      new Paquete(7, "Extra"), 
                                      new Paquete(8, "Vip") };

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("PRACTICA 5 - LINQ \n");

            //inciso1();
            //inciso2("Rio de Janeiro");
            //inciso3("Básico");
            //inciso4("Elias Andrade");
            //inciso5();
            //inciso6();
            //inciso7();  
            //inciso8();
            //inciso9();
            //inciso10();

            Console.ReadKey();
        }

        static void inciso1()
        {
            Console.WriteLine("1. Listar todos los turistas agrupados por tour.\n");

            var AgrupadoTour = from t in turistas
                               join e in excursiones
                               on t.CodTour equals e.CodTour
                               group t by e.CodTour;

            foreach (var item in AgrupadoTour)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Tour " + item.Key);
                foreach (var t in item)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" " + t.NomTurista);
                }
            }       
        }

        static void inciso2(string lugar)
        {
            Console.WriteLine("2. Dado el nombre de un lugar, listar losnombres de losturistas que visitaránese lugar.\n");

            var ListaTuristas = from l in lugares
                                join tl in turista_visita
                                on l.CodLugar equals tl.IDLugar
                                join t in turistas
                                on tl.CI equals t.CI
                                where l.NomLugar == lugar
                                select new { nomTurista = t.NomTurista };
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lugar: " + lugar);
            foreach (var item in ListaTuristas)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(item.nomTurista); 
            }
        }

        static void inciso3(string paquete)
        {
            Console.WriteLine("3. Dado el nombre de un paquete indicar que lugares son visitados con ese paquete.\n");

            var ListaPaquete = from p in paquetes
                               join l in lugares
                               on p.CodPaquete equals l.Paquete
                               where p.NomPaquete == paquete
                               select new { lugarV = l.NomLugar };
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Paquete: " + paquete);
            foreach (var item in ListaPaquete)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(item.lugarV);
            }
        }

        static void inciso4(string turista)
        {
            Console.WriteLine("4. Dado un turista mostrar el nombre del responsable de su tour.\n");

            var ListaResponsables = from to in excursiones
                                    join t in turistas
                                    on to.CodTour equals t.CodTour
                                    where t.NomTurista == turista
                                    select new { nomResponsable = to.Responsable };
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Turista: " + turista);
            foreach (var item in ListaResponsables)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(item.nomResponsable);
            }
        }

        static void inciso5()
        {
            Console.WriteLine("5. Mostrar los nombres de turistas junto a su responsable de tour.\n");

            var lstTuristResponsable = from t in turistas
                                       join e in excursiones
                                       on t.CodTour equals e.CodTour
                                       group t by e.Responsable;

            foreach (var item in lstTuristResponsable)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Responsable del Tour: " + item.Key);
                Console.WriteLine(" Turistas: ");
                foreach (var t in item)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  " + t.NomTurista);
                }
            }
        }

        static void inciso6()
        {
            Console.WriteLine("6. Mostrar los turistas por cada lugar a visitar.\n");
            var lstTuristaLugar = from t in turistas
                                  join tl in turista_visita
                                  on t.CI equals tl.CI
                                  join l in lugares
                                  on tl.IDLugar equals l.CodLugar
                                  group t by l.NomLugar;

            foreach (var item in lstTuristaLugar)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nombre Lugar: " + item.Key);
                Console.WriteLine(" Turistas: ");
                foreach (var t in item)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  " + t.NomTurista);
                }
            }
        }

        static void inciso7()
        {
            Console.WriteLine("7. Cantidad de turistas que habrá en cada lugar a visitar.\n");

            var lstTuristaTotal = from t in turistas
                                  join tl in turista_visita
                                  on t.CI equals tl.CI
                                  join l in lugares
                                  on tl.IDLugar equals l.CodLugar
                                  group t by l.NomLugar;

            foreach (var t in lstTuristaTotal)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Cantitad de turistas en: " + t.Key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(t.Count());
            }
        }

        static void inciso8()
        {
            Console.WriteLine("8. Nombres de turistas agrupados por (nombre de) paquete.\n");

            var AgrupadoPaquete = from t in turistas
                                  join p in paquetes
                                  on t.CodPaquete equals p.CodPaquete
                                  orderby p.NomPaquete
                                  group t by p.NomPaquete;

            foreach (var item in AgrupadoPaquete)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Paquete " + item.Key);
                foreach (var t in item)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" " + t.NomTurista);
                }
            }
        }

        static void inciso9()
        {
            Console.WriteLine("9. Turistas registrados en más de un paquete.\n"); //No habria ni un turista ya que no hay turistas registrados en mas de un paquete.

            var lstTuristaRegistrado = from t in turistas
                                       join p in paquetes
                                       on t.CodPaquete equals p.CodPaquete
                                       group t by p.NomPaquete
                                       into temp
                                       where temp.Count() > 1
                                       select temp;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Paquetes con más de un turista.\n");

            foreach (var item in lstTuristaRegistrado)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Paquete: " + item.Key);
                foreach (var t in item)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" " + t.NomTurista);
                }
            }
        }

        static void inciso10()
        {
            Console.WriteLine("10. Mostrar la cantidad de turistas por cada tour en forma descendente.\n");

            var cantidadTuristas = from t in turistas
                                   join e in excursiones
                                   on t.CodTour equals e.CodTour
                                   group t by e.CodTour;

            foreach (var t in cantidadTuristas)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Cantitad de turistas en: " + t.Key);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(t.Count());
            }
        }
    }
}
