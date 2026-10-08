using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Aplikacja
{

    public class Program
    {
        public static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== MENU GŁÓWNE ===");
            Console.WriteLine("1. Szyfruj tekst");
            Console.WriteLine("2. Wyjście");
            Console.WriteLine(); // Linijka przerwy, mogłem dać \n\n , ale tak mam więcej lini w kodzie
            Console.Write("Wybierz opcję (1-2): ");
            Console.ResetColor();

            string wyborOpcji = Console.ReadLine();

            switch(wyborOpcji)
            {
                case "1" :
                    Console.Clear();
                    // Podawanie Hasłą przez Użytkownika
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Podaj Hasło: "); Console.ResetColor(); string? hasloWpisane = Console.ReadLine();

                    // Hashowanie hasła wpisanego przez uzytkownika na hash: SHA256
                    byte[] inputBytes = Encoding.UTF8.GetBytes(hasloWpisane);
                    byte[] hashBytes = SHA256.HashData(inputBytes);
                    string hashHex = Convert.ToHexString(hashBytes);

                    Console.Clear();

                    // Wyświetlanie shasowanego hasła
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Twoje Hasło w hash SHA-256 \n");
                    Console.ResetColor();

                  
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine(hashHex);
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.ResetColor();

                    // Czy zapisać hasło?

                    Console.WriteLine("\n Czy chcesz zapisać hasło");
                    Console.WriteLine("t = TAK");
                    Console.WriteLine("n = NIE");

                    string opcjaZapisu = Console.ReadLine();
                    
                    switch(opcjaZapisu)
                    {
                        case "t":
                            Console.Clear();
                            Console.Write("Wpisz jak chcesz nazwać plik: "); string? wpisanaNazwaPliku = Console.ReadLine();
                            string nazwaPliku = $"{wpisanaNazwaPliku}.txt";
                            Console.Clear(); Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write($"Plik z Hasłem zostało zapisany jako "); Console.ResetColor(); Console.ForegroundColor = ConsoleColor.DarkYellow; Console.Write(wpisanaNazwaPliku); Console.ResetColor();

                            File.WriteAllText(nazwaPliku, $"Hasło które wpisałeś = {hasloWpisane} \n Hasło otrzymane w hash SHA-256: {hashHex}");
                            break;
                        case "n":
                            Console.Clear();
                            Console.WriteLine("Do zobaczenia!");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("To nie jest opcja!");
                            break;
                    }

                //Koniec Programu do Hashowania Haseł

                    break; 

                    //Zamknięcie programu
                case "2":
                    Console.Clear();
                    Console.WriteLine("Zamykanie programu. Do widzenia!");
                    break;

                    // Wpisanie złych danych, błąd wyboru
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Błąd, wybierz opcje (1-2)");
                    Console.ResetColor();
                    break;


            }

        }
    }
}