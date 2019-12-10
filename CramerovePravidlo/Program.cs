using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*! \mainpage Hlavná stránka
 *
 * \section intro_sec Úvod
 *
 * Tento program vypočíta hodnoty troch premenných zo sústavy 
 *
 * \section navod_sec Návod
 * Vložte hodnoty rovníc v chronologickom poradí hodnôt.
 * Po každej hodnote stlačte <enter>.
 * 
 *
 */
/*! 
*  \details   Táto stránka zobrazuje základné informácie.
*  \author    Adrián Gajdošík
*  \author    Tomáš Hrbáček
*  \version   1.0
*  \date      10.12.2019
*  \pre       Najprv vložte hodnoty
*  \bug       Nie su a ak vám niečo nefunguje tak to zle používate
*  \warning   Pri nesprávnom použití vám môže zhorieť počítať
*  \copyright Google
*/
namespace Cramerove_pravidlo
{

    /// <summary>
    /// Trieda Program
    /// </summary>

    class Program
    {
        /// <summary>
        /// Metóda pre zadanie matice.
        /// </summary>
        /// <param name="matica"></param>
        static void zadajMaticu(double[,] matica)
        {
            for (int riadok = 0; riadok < 3; riadok++)
            {
                for (int stlpec = 0; stlpec < 4; stlpec++)
                {
                    matica[riadok, stlpec] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }
        /// <summary>
        /// Vypocet determinantu
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        static double DeterminantMatice(double[,] mat)
        {
            double ans;
            ans = mat[0, 0] * (mat[1, 1] * mat[2, 2] - mat[2, 1] * mat[1, 2])
                - mat[0, 1] * (mat[1, 0] * mat[2, 2] - mat[1, 2] * mat[2, 0])
                + mat[0, 2] * (mat[1, 0] * mat[2, 1] - mat[1, 1] * mat[2, 0]);
            return ans;
        }

        /// <summary>
        /// Tato funcke hledá řešení soustavy lieárních rovnic zapoužití Cramerova pravidla
        /// </summary>
        /// <param name="matica"></param>
        static void Vypocet(double[,] matica)
        {
            /**
             * Uprava 1. matice pro cramerove pravidlo
             */
            double[,] d = {
        { matica[0,0], matica[0,1], matica[0,2] },
        { matica[1,0], matica[1,1], matica[1,2] },
        { matica[2,0], matica[2,1], matica[2,2] },
    };

            /**
            * Uprava 2. matice pre cramerove pravidlo
            */
            double[,] d1 = {
        { matica[0,3], matica[0,1], matica[0,2] },
        { matica[1,3], matica[1,1], matica[1,2] },
        { matica[2,3], matica[2,1], matica[2,2] },
    };
            /**
             * Uprava 3. matice pro cramerove pravidlo
             */
            double[,] d2 = {
        { matica[0,0], matica[0,3], matica[0,2] },
        { matica[1,0], matica[1,3], matica[1,2] },
        { matica[2,0], matica[2,3], matica[2,2] },
    };

            /**
             * Uprava 4. matice pro cramerove pravidlo
             */
            double[,] d3 = {
        { matica[0,0], matica[0,1], matica[0,3] },
        { matica[1,0], matica[1,1], matica[1,3] },
        { matica[2,0], matica[2,1], matica[2,3] },
    };

            /** 
             * Vypočet determinantu matic 
             */
            double D = DeterminantMatice(d);
            double D1 = DeterminantMatice(d1);
            double D2 = DeterminantMatice(d2);
            double D3 = DeterminantMatice(d3);
            Console.WriteLine($"D: {D}");
            Console.WriteLine($"D1:{D1}");
            Console.WriteLine($"D2:{D2}");
            Console.WriteLine($"D3:{D3}");

            /**
             * Případ 1
             */
            if (D != 0)
            {
                /**
                 *  Koeficient má unikátní řešení. Aplikujem Cramerovo pravidlo
                 */
                double x = D1 / D; /*!< Výpočet x použitím cramerova pravidla */
                double y = D2 / D; /*!< Výpočet y použitím cramerova pravidla */
                double z = D3 / D; /*!< Výpočet Z použitím cramerova pravidla */
                Console.WriteLine($"Hodnota x je: {x}");
                Console.WriteLine($"Hodnota y je: {y}");
                Console.WriteLine($"Hodnota z je: {z}");
            }

            /**
             * Případ 2
             */
            else
            {
                if (D1 == 0 && D2 == 0 && D3 == 0)
                    Console.WriteLine("Nekonečne veľa riešení");
                else if (D1 != 0 || D2 != 0 || D3 != 0)
                    Console.WriteLine("Žiadne riešenia");
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                /**
                * zadanie matice
                */
                double[,] matica = new double[3, 4];
                Console.WriteLine("Zadaj maticu");
                zadajMaticu(matica);
                Console.WriteLine($"x{matica[0, 0]}+y{matica[0, 1]}+z{matica[0, 2]}={matica[0, 3]}");
                Console.WriteLine($"x{matica[1, 0]}+y{matica[1, 1]}+z{matica[1, 2]}={matica[1, 3]}");
                Console.WriteLine($"x{matica[2, 0]}+y{matica[2, 1]}+z{matica[2, 2]}={matica[2, 3]}");
                Vypocet(matica);
                Console.WriteLine("Opakovať program? (y/n)");
                if (Console.ReadLine().ToLower() != "y")
                    break;   // Ukončí while loop 
                Console.WriteLine();
            }
        }
    }
}