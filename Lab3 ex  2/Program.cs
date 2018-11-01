using System;

namespace Lab3_ex__2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool jouer = true;

            while (jouer == true)
            {


                Console.CursorVisible = false;

                int faute = 0;
                string mauvaisLettre = "";

                string[] tabMotRandom = { "banane", "porte", "pendue", "tableau", "avion", "train", "plombier", "eau", "os", "sumo" };
                Random gen = new Random();
                int choixMot = gen.Next(0, 10);

                char[] tabLettre = new char[tabMotRandom[choixMot].Length];
                char[] tabAff = new char[tabMotRandom[choixMot].Length];

                for (int i = 0; i < tabMotRandom[choixMot].Length; i++)
                {
                    tabLettre[i] = tabMotRandom[choixMot][i];
                    if (tabLettre[i] != ' ')
                    {
                        tabAff[i] = '_';
                    }
                    else
                    {
                        tabAff[i] = ' ';
                    }
                }

                if (faute < 5)
                {
                    bool joueurPerdu = false;
                    bool joueurGagner = false;

                    ChangerLettre();

                    while (!joueurPerdu && !joueurGagner)
                    {
                        bool lettreTrouver = false;

                        Console.SetCursorPosition(20, 8);
                        Console.Write("Choisisser une Lettre");
                        Console.SetCursorPosition(48, 3);
                        Console.Write("Faute");
                        Console.SetCursorPosition(49, 4);
                        Console.Write(faute + "/5");

                        ConsoleKeyInfo lettreUser = Console.ReadKey(true);
                        for (int i = 0; i < tabLettre.Length; i++)
                        {
                            if (lettreUser.KeyChar == tabLettre[i])
                            {
                                tabAff[i] = lettreUser.KeyChar;
                                lettreTrouver = true;
                            }
                        }


                        if (lettreTrouver == false)
                        {
                            Console.SetCursorPosition(45, 8);
                            mauvaisLettre += lettreUser.KeyChar;
                            faute++;
                            Console.Write("Mauvaise lettre");
                            Console.SetCursorPosition(45, 10);
                            Console.Write("|  ");
                            for (int i = 0; i < mauvaisLettre.Length; i++)
                            {
                                Console.Write(mauvaisLettre[i].ToString().ToLower() + " ");
                            }
                            Console.Write(" |");
                        }
                        ChangerLettre();


                        if (faute == 5)
                        {
                            joueurPerdu = true;
                        }

                        joueurGagner = true;

                        for (int i = 0; i < tabAff.Length; i++)
                        {
                            if (tabAff[i] == '_')
                            {
                                joueurGagner = false;
                            }
                        }
                    }
                    int choixFin = 0;

                    if (joueurGagner == true)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(20, 8);
                        Console.WriteLine("Vous avez trouvé le mot");
                    }
                    if (joueurPerdu == true)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(20, 8);
                        Console.WriteLine("Vous n'avez plus de vie");

                    }
                    Console.SetCursorPosition(20, 10);
                    Console.WriteLine("1-Continuer?");
                    Console.SetCursorPosition(20, 11);
                    Console.WriteLine("2-Quitter?");
                    choixFin = Convert.ToInt32(Console.ReadKey(true).KeyChar);

                    if (choixFin == 50)
                    {
                        jouer = false;
                    }
                    Console.Clear();
                }

                void ChangerLettre()
                {
                    for (int i = 0; i < tabAff.Length; i++)
                    {
                        Console.SetCursorPosition(20 + i + i, 10);
                        Console.Write(tabAff[i] + " ");
                    }
                }
            }
            Environment.Exit(-1);
        }
    }
}
