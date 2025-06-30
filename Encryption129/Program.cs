using System;
using System.Linq;
using System.Threading;
using System.IO;

namespace Encryption129
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "CipherX - Encryption/Decryption System";
            SetConsoleColors();
            ShowIntro();  
            ShowMenu(); 
        }

        static void SetConsoleColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        static void ShowIntro()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\ud83c\udf38 Welcome to CipherX \ud83c\udf38");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Data Encryption & Decryption System");

            Thread.Sleep(500);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEncrypting your data... \ud83c\udf3f");
            Thread.Sleep(800);

            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = (i % 2 == 0) ? ConsoleColor.Cyan : ConsoleColor.Magenta;
                Console.WriteLine("⏳ Encrypting...");
                Thread.Sleep(300);
                Console.Clear();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nData successfully encrypted! \ud83c\udf38");
            Thread.Sleep(1000);
            Console.Clear();
        }

        static void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------- Always remember the encrypted text for Decryption. -------");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n Menu ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Kama Sutra Cipher (Encrypt/Decrypt)");
                Console.WriteLine("2. Simple Cipher (Encrypt/Decrypt)");
                Console.WriteLine("3. Caesar Cipher Technique (Encrypt/Decrypt)");
                Console.WriteLine("4. Unique Cipher Technique (Encrypt/Decrypt)");
                Console.WriteLine("5. Exit");

                Console.Write("\nPlease select an option (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ChooseKamaSutraMode();
                        break;
                    case "2":
                        ChooseSimpleCipherMode();
                        break;
                    case "3":
                        ChooseCaesarMode();
                        break;
                    case "4":
                        ChooseUniqueEncryptionMode();
                        break;
                    case "5":
                        Console.WriteLine("Exiting... Thank you for using CipherX!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid input! Please enter a valid option (1-5).");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1500);
                        break; 
                }
            }
        }


        static void ChooseKamaSutraMode()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Kama Sutra Cipher:");
            Console.WriteLine("Origin: Ancient India, described in the Kama Sutra text.");
            Console.WriteLine();
            Console.WriteLine("Use:");
            Console.WriteLine("- A simple substitution cipher where letters are paired.");
            Console.WriteLine("- Each letter in a pair is swapped with its counterpart.");
            Console.WriteLine("- Used for secret communications in ancient times.");
            Console.WriteLine();
            Console.WriteLine("Pros:");
            Console.WriteLine("- Simple to implement.");
            Console.WriteLine("- Provides basic secrecy for casual messages.");
            Console.WriteLine();
            Console.WriteLine("Cons:");
            Console.WriteLine("- Easily breakable with frequency analysis.");
            Console.WriteLine("- Not secure for modern cryptographic use.");
            Console.WriteLine("-------------------------------------------------");
            Console.ResetColor();


            while(true)
    {
                Console.WriteLine("\nDo you want to: \n1. Encrypt \n2. Decrypt");
                Console.Write("Choose an option (1 or 2): ");
                string mode = Console.ReadLine();

                if (mode == "1" || mode == "2")
                {
                    KamaSutraCipher();
                    return;  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice! Please enter 1 for Encrypt or 2 for Decrypt.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }

        static void KamaSutraCipher()
        {
            EncryptionCodes encryption = new EncryptionCodes();
            Console.Write("Enter text: \n");
            string input = Console.ReadLine();

            string output = encryption.KamaSutraEncryptDecrypt(input);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Output: {output}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }

        static void ChooseUniqueEncryptionMode()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Unique Cipher:");
            Console.WriteLine("Origin: A combination of Vigenère cipher and transposition.");
            Console.WriteLine();
            Console.WriteLine("Use:");
            Console.WriteLine("- Uses Vigenère cipher for polyalphabetic substitution.");
            Console.WriteLine("- Applies transposition for additional obfuscation.");
            Console.WriteLine("- Designed to provide more security than simple ciphers.");
            Console.WriteLine();
            Console.WriteLine("Pros:");
            Console.WriteLine("- Harder to break than monoalphabetic ciphers.");
            Console.WriteLine("- Resists frequency analysis.");
            Console.WriteLine("- More secure when a strong key is used.");
            Console.WriteLine();
            Console.WriteLine("Cons:");
            Console.WriteLine("- More complex than basic ciphers.");
            Console.WriteLine("- Still vulnerable to cryptanalysis with enough ciphertext.");
            Console.WriteLine("-------------------------------------------------");
            Console.ResetColor();


            Console.WriteLine("\nDo you want to: \n1. Encrypt \n2. Decrypt");
            Console.Write("Choose an option: ");
            string mode = Console.ReadLine();

            if (mode == "1")
                UniqueEncryption(true);
            else if (mode == "2")
                UniqueEncryption(false);
            else
                ShowMenu();
        }

        static void UniqueEncryption(bool encrypt)
        {
            EncryptionCodes encryption = new EncryptionCodes();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Drag and drop a file here and press Enter:");
                string filePath = Console.ReadLine()?.Trim('"');

                if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid file! Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    continue;
                }

                Console.Write("Enter the word to search: ");
                string searchWord = Console.ReadLine();

                Console.Write("Enter Vigenère Key: ");
                string vigenereKey = Console.ReadLine().ToUpper();

                Console.Write("Enter Transposition Key (Number): ");
                if (!int.TryParse(Console.ReadLine(), out int transpositionKey))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid transposition key! Must be a number.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    continue; 
                }

                string inputText = File.ReadAllText(filePath);

                if (!inputText.Contains(searchWord))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Word '{searchWord}' not found in the file. Try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    continue;  
                }

                string processedWord = encrypt
                    ? encryption.UniqueEncrypt(searchWord, vigenereKey, transpositionKey)
                    : encryption.UniqueDecrypt(searchWord, vigenereKey, transpositionKey);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"Processed Word: {processedWord}");

                string outputText = inputText.Replace(searchWord, processedWord);

                string directory = Path.GetDirectoryName(filePath);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                string extension = Path.GetExtension(filePath);
                string outputFileName = Path.Combine(directory, fileNameWithoutExtension + (encrypt ? "_word_encrypted" : "_word_decrypted") + extension);

                File.WriteAllText(outputFileName, outputText);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Operation completed! Output saved to {outputFileName}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
                ShowMenu();
                return;  
            }
        }



        static void ChooseSimpleCipherMode()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Simple/Monoalphabetic Cipher:");
            Console.WriteLine("Origin: Caesar Cipher. Used by Julius Caesar around 58 BC");
            Console.WriteLine();
            Console.WriteLine("Use:");
            Console.WriteLine("- Used for encrypting messages by exchanging each letter");
            Console.WriteLine("  from plain text with a set letter in the ciphertext.");
            Console.WriteLine("- Used in military communications and secret messages.");
            Console.WriteLine("- Used in puzzles.");
            Console.WriteLine();
            Console.WriteLine("Pros:");
            Console.WriteLine("- Easy to execute.");
            Console.WriteLine("- Fast encryption and decryption.");
            Console.WriteLine("- Can be done manually.");
            Console.WriteLine();
            Console.WriteLine("Cons:");
            Console.WriteLine("- Can be cracked within seconds, not suitable for modern security.");
            Console.WriteLine("- Single mapping letter makes it predictable.");
            Console.WriteLine("-------------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("\nDo you want to: \n1. Encrypt \n2. Decrypt");
            Console.Write("Choose an option: ");
            string mode = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter text: ");
            string input = Console.ReadLine();

            string output = mode == "1" ? SimpleCipher.Encrypt(input) : SimpleCipher.Decrypt(input);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Output: {output}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }

        static void ChooseCaesarMode()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Caesar Cipher:");
            Console.WriteLine("Origin: Julius Caesar, 58 BC.");
            Console.WriteLine("Use: Shifts each letter by a fixed number.");
            Console.WriteLine("Pros: Simple and quick.");
            Console.WriteLine("Cons: Easily broken by brute force.");
            Console.WriteLine("-------------------------------------------------");
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("\nDo you want to: \n1. Encrypt \n2. Decrypt");
                Console.Write("Choose an option (1 or 2): ");
                string mode = Console.ReadLine();

                if (mode == "1" || mode == "2")
                {
                    CaesarCipher(mode == "1");
                    return;  // Exit after successful selection
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid choice! Please enter 1 for Encrypt or 2 for Decrypt.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }
        }

        static void CaesarCipher(bool encrypt)
        {
            EncryptionCodes encryption = new EncryptionCodes();

            Console.Write("Enter text: ");
            string input = Console.ReadLine();

            int shift;
            while (true)
            {
                Console.Write("Enter shift value (1-25): ");
                string shiftInput = Console.ReadLine();

                if (int.TryParse(shiftInput, out shift) && shift >= 1 && shift <= 25)
                {
                    break; 
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid shift value! Please enter a number between 1 and 25.");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1500);
            }

            string output = encrypt ? encryption.CaesarEncrypt(input, shift) : encryption.CaesarDecrypt(input, shift);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Output: {output}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
            ShowMenu();
        }


    }
}
