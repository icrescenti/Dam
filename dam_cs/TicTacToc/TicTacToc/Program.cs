//============================================================================
// Name        : TicTacToc
// Author      : Ivan Crescenti Hernandez, Carles Llauger Coma i Pol Boada Puigdemont
// Version     : 1.1
// Copyright   : IES Rafael Campalans © Copyright 2020
// Description : Joc de tres en ratlla
//============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToc
{
    class Program
    {
        static void Main(string[] args)
        {
            #region variables

            int[,] tauler = new int[3, 3];
            bool jugador_1 = true,
            joc_finalitzat = false,
            executar_programa = true,
            victoria = false;

            #endregion

            #region variables dinamiques

            uint x, y = 0;
            bool validat;

            #endregion

            while (executar_programa)
            {
                do
                {
                    mostrar(tauler);

                    #region validacio
                    validat = false;

                    Console.Write("[*] Insereix la coordenada X (Horizontal): ");
                    if (uint.TryParse(Console.ReadLine(), out x) && x <= tauler.GetUpperBound(0) && x >= 0)
                    {
                        Console.Write("[*] Insereix la coordenada Y (Vertical): ");
                        if (uint.TryParse(Console.ReadLine(), out y) && y <= tauler.GetUpperBound(1) && y >= 0)
                            if (tauler[x, y] == 0) validat = true;
                            else
                            {
                                Console.WriteLine("[!] Les coordenades estan ocupades, torna a intentar-ho.");
                                Console.ReadKey();
                            }
                        else integer_invalid();
                    }
                    else integer_invalid();
                    #endregion

                    if (validat)
                    {
                        if (jugador_1)
                        {
                            tauler[x, y] = 1;
                        }
                        else
                        {
                            tauler[x, y] = 2;
                        }

                        jugador_1 = !jugador_1;

                        ha_finalitzat(tauler, out joc_finalitzat, out victoria);
                    }
                }
                while (!joc_finalitzat);

                mostrar(tauler);

                if (victoria)
                {
                    jugador_1 = !jugador_1;

                    if (jugador_1)
                        Console.WriteLine("[*] El jugador 1 (X) ha guanyat!");
                    else
                        Console.WriteLine("[*] El jugador 2 (O) ha guanyat!");
                }
                else if (joc_finalitzat && !victoria)
                {
                    Console.WriteLine("[!] EMPAT, no es poden realitzar més moviments.");
                }

                Console.Write("[*] Tornar a jugar o sortir? (jugar/sortir): ");
                if (Console.ReadLine() != "jugar") executar_programa = false;

                tauler = new int[3, 3];
                jugador_1 = true;
                joc_finalitzat = false;
            }
        }

        #region Comprovacio de si la partida ha estat finalitzada 
        static void ha_finalitzat(int[,] matriu, out bool finalitzat, out bool victoria)
        {
            int[] vector_valors = new int[(matriu.GetUpperBound(0) + 1) * (matriu.GetUpperBound(1) + 1)];
            int comptador = 0;

            victoria = finalitzat = false;

            for (int i = 0, k = 0; i <= matriu.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matriu.GetUpperBound(1); j++)
                {
                    vector_valors[k++] = matriu[j, i];
                    if (matriu[i, j] != 0) comptador++;
                }
            }

            #region Comprovacio de victoria
            if (
                //Victoria horitzontal
                (vector_valors[0] != 0 && vector_valors[0] == vector_valors[1] && vector_valors[1] == vector_valors[2]) ||
                (vector_valors[3] != 0 && vector_valors[3] == vector_valors[4] && vector_valors[4] == vector_valors[5]) ||
                (vector_valors[6] != 0 && vector_valors[6] == vector_valors[7] && vector_valors[7] == vector_valors[8]) ||
                //Victoria vertical
                (vector_valors[0] != 0 && vector_valors[0] == vector_valors[3] && vector_valors[3] == vector_valors[6]) ||
                (vector_valors[1] != 0 && vector_valors[1] == vector_valors[4] && vector_valors[4] == vector_valors[7]) ||
                (vector_valors[2] != 0 && vector_valors[2] == vector_valors[5] && vector_valors[5] == vector_valors[8]) ||
                //victoria diagonal
                (vector_valors[0] != 0 && vector_valors[0] == vector_valors[4] && vector_valors[4] == vector_valors[8]) ||
                (vector_valors[2] != 0 && vector_valors[2] == vector_valors[4] && vector_valors[4] == vector_valors[6])
                )
            {
                finalitzat = victoria = true;
            }
            #endregion

            if (comptador > 8)
            {
                finalitzat = true;
            }
        }
        #endregion

        static void mostrar(int[,] matriu)
        {
            Console.Clear();
            Console.WriteLine("\n      0   1   2\n    +---+---+---+");
            for (int i = 0; i <= matriu.GetUpperBound(0); i++)
            {
                Console.Write("  {0} |", i);
                for (int j = 0; j <= matriu.GetUpperBound(0); j++)
                {
                    if (matriu[j, i] == 0)
                        Console.Write(" {0} |", " ");
                    else if (matriu[j, i] == 1)
                        Console.Write(" {0} |", "X");
                    else if (matriu[j, i] == 2)
                        Console.Write(" {0} |", "O");
                }
                Console.WriteLine("\n    +---+---+---+");
            }
        }

        #region errors
        static void integer_invalid()
        {
            Console.WriteLine("[!] Les coordenades no són correctes, torna a intentar-ho.");
            Console.ReadKey();
        }
        #endregion
    }
}
