using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendListConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int q = 0;
            string[] friendsList = { null };
            string enteredName;
            ConsoleKeyInfo keyInfo;

            Console.WriteLine("Sveiki atvyke i draugu saraso programa!");
            do
            {
                Console.WriteLine("\nSpauskite SPACE - noredami ivesti nauja drauga, " +
                    "\n L - noredami pamatyti draugu sarasa, " +
                    "\n D - noredami istrinti drauga is saraso," +
                    "\n ESCAPE - noredami iseiti,");
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    // Naujo draugo ivedimas
                    case ConsoleKey.Spacebar:

                        Console.WriteLine("\nIveskite draugo varda: ");

                        if (friendsList[friendsList.Length - 1] == null)
                        {
                            // Veikia jei paskutinio vardo reiksme null
                            enteredName = Console.ReadLine();
                            friendsList[friendsList.Length - 1] = enteredName;
                        }
                        else
                        {
                            // Veikia jei paskutinio vardo reiksme nera null
                            Array.Resize(ref friendsList, friendsList.Length + 1);
                            enteredName = Console.ReadLine();
                            friendsList[friendsList.Length - 1] = enteredName;
                        }
                        break;
                    // Viso saraso ismetimas
                    case ConsoleKey.L:
                        Console.WriteLine("\nDraugu sarasas");
                        foreach (string friendName in friendsList)
                        {
                            Console.Write(friendName + " ");
                        }
                        break;
                    // Draugo istrynimas is saraso
                    case ConsoleKey.D:
                        Console.WriteLine("\nParasykite, kuri drauga norite istrinti");
                        enteredName = Console.ReadLine();

                        bool nameNotFound = true;

                        for (int i = 0; i < friendsList.Length; i++)
                        {
                            // Veikia jei randa ivestos reiksmes draugo varda
                            if (enteredName == friendsList[i])
                            {
                                Console.WriteLine("\nRadome toki drauga");
                                Console.WriteLine("\nAr norite istrinti drauga vardu " + friendsList[i] + " ?");
                                Console.WriteLine("Jei norite istrinti si drauga, patvirtinkit paspausdami - Y");

                                keyInfo = Console.ReadKey();

                                switch (keyInfo.Key)
                                {
                                    case ConsoleKey.Y:
                                        Console.WriteLine(friendsList[i] + " is draugu saraso ismestas!");

                                        for (int y = i; y < friendsList.Length - 1; y++)
                                        {
                                            friendsList[y] = friendsList[y + 1];
                                        }

                                        friendsList[friendsList.Length - 1] = null;

                                        nameNotFound = false;
                                        break;

                                    default:
                                        break;
                                        
                                }
                            }
                        }

                        // Veikia jei neranda ivestos reiksmes draugo vardo
                        if (nameNotFound == true)
                        {
                            Console.WriteLine("Toks draugas nebuvo ivestas!");
                        }
                        break;
                    // Programos isjungimas
                    case ConsoleKey.Escape:
                        q = 1;
                        break;
                }
            } while (q < 1);
            Console.WriteLine("Aciu, kad naudojates musu programa!");
        }
    }
}
