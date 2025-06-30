using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Encryption129
{
    internal class EncryptionCodes
    {
        private Dictionary<char, char> KamaSutraMap;

        public EncryptionCodes()
        {
            KamaSutraMap = new Dictionary<char, char>
            {
            {'A', 'N'}, {'N', 'A'},
            {'B', 'O'}, {'O', 'B'},
            {'C', 'P'}, {'P', 'C'},
            {'D', 'Q'}, {'Q', 'D'},
            {'E', 'R'}, {'R', 'E'},
            {'F', 'S'}, {'S', 'F'},
            {'G', 'T'}, {'T', 'G'},
            {'H', 'U'}, {'U', 'H'},
            {'I', 'V'}, {'V', 'I'},
            {'J', 'W'}, {'W', 'J'},
            {'K', 'X'}, {'X', 'K'},
            {'L', 'Y'}, {'Y', 'L'},
            {'M', 'Z'}, {'Z', 'M'}
            };
        }
        public string CaesarEncrypt(string input, int shift)
        {
            StringBuilder result = new StringBuilder();

            foreach (char ch in input)
            {
                if (char.IsLetter(ch))
                {
                    char offset = char.IsUpper(ch) ? 'A' : 'a';
                    result.Append((char)(((ch + shift - offset) % 26) + offset));
                }
                else
                {
                    result.Append(ch);
                }
            }

            return result.ToString();
        }


        public string CaesarDecrypt(string input, int shift)
        {
            return CaesarEncrypt(input, 26 - shift);
        }
        public string KamaSutraEncryptDecrypt(string input)
        {
            return new string(input.ToUpper().Select(c =>
                KamaSutraMap.ContainsKey(c) ? KamaSutraMap[c] : c
            ).ToArray());
        }

        public string UniqueEncrypt(string text, string vigenereKey, int transpositionKey)
        {
            int textLength = text.Length;
            char[] vigenereEncrypted = new char[textLength];
            int keyIndex = 0;

            
            for (int i = 0; i < textLength; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    char baseChar = char.IsUpper(text[i]) ? 'A' : 'a';
                    char baseKey = char.IsUpper(vigenereKey[keyIndex % vigenereKey.Length]) ? 'A' : 'a';

                    vigenereEncrypted[i] = (char)(baseChar + (text[i] - baseChar + vigenereKey[keyIndex % vigenereKey.Length] - baseKey) % 26);
                    keyIndex++;
                }
                else
                {
                    vigenereEncrypted[i] = text[i];
                }
            }

            
            char[] transposedArray = new char[textLength];
            for (int i = 0; i < textLength; i++)
            {
                int newPosition = (i + transpositionKey) % textLength;
                transposedArray[newPosition] = vigenereEncrypted[i];
            }

            return new string(transposedArray);
        }

        public string UniqueDecrypt(string text, string vigenereKey, int transpositionKey)
        {
            int textLength = text.Length;
            char[] transposedArray = new char[textLength];

            
            for (int i = 0; i < textLength; i++)
            {
                int originalPosition = (i - transpositionKey + textLength) % textLength;
                transposedArray[originalPosition] = text[i];
            }

            
            char[] decryptedArray = new char[textLength];
            int keyIndex = 0;

            for (int i = 0; i < textLength; i++)
            {
                if (char.IsLetter(transposedArray[i])) 
                {
                    char baseChar = char.IsUpper(transposedArray[i]) ? 'A' : 'a';
                    char baseKey = char.IsUpper(vigenereKey[keyIndex % vigenereKey.Length]) ? 'A' : 'a';

                    decryptedArray[i] = (char)(baseChar +
                        (transposedArray[i] - baseChar - (vigenereKey[keyIndex % vigenereKey.Length] - baseKey) + 26) % 26);

                    keyIndex++; 
                }
                else
                {
                    decryptedArray[i] = transposedArray[i]; 
                }
            }

            return new string(decryptedArray);
        }


    }

    public class SimpleCipher
    {
        private static readonly Dictionary<char, char> substitution = new Dictionary<char, char>
        {
            {'A', 'Q'}, {'B', 'W'}, {'C', 'E'}, {'D', 'R'}, {'E', 'T'},
            {'F', 'Y'}, {'G', 'U'}, {'H', 'I'}, {'I', 'O'}, {'J', 'P'},
            {'K', 'A'}, {'L', 'S'}, {'M', 'D'}, {'N', 'F'}, {'O', 'G'},
            {'P', 'H'}, {'Q', 'J'}, {'R', 'K'}, {'S', 'L'}, {'T', 'Z'},
            {'U', 'X'}, {'V', 'C'}, {'W', 'V'}, {'X', 'B'}, {'Y', 'N'},
            {'Z', 'M'}, {' ', ' '}
        };

        private static readonly Dictionary<char, char> crypt = new Dictionary<char, char>();

        static SimpleCipher()
        {
            foreach (var pair in substitution)
            {
                crypt[pair.Value] = pair.Key;
            }
        }

        public static string Encrypt(string pText)
        {
            pText = pText.ToUpper();
            return new string(pText.Select(c => substitution.ContainsKey(c) ? substitution[c] : c).ToArray());
        }

        public static string Decrypt(string cText)
        {
            cText = cText.ToUpper();
            return new string(cText.Select(c => crypt.ContainsKey(c) ? crypt[c] : c).ToArray());
        }


      
    }



}
