using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    public class Encryption
    {
        protected char[] alphabet = {   'а','б', 'в', 'г',
                                        'д','е', 'ж', 'з',
                                        'и', 'к', 'л', 'м',
                                        'н','о', 'п', 'р',
                                        'с', 'т', 'у', 'ф',
                                        'х', 'ц', 'ч', 'ш',
                                        'щ', 'э', 'ю', 'я',
                                        'ъ', 'ь'            };
        
        protected string word;
        protected string key;
        protected byte[] bt;

        public Encryption()
        {
            this.word = "EMPTY";
            this.key = "EMPTY";
        }
        public Encryption(string word, string key)
        {
            this.word = word;
            this.key = key;

        }
        public Encryption(byte[] bt, string key)
        {
            this.bt = bt;
            this.key = key;

        }

        public string Encrypt()
        {
            int indexEncrypt = 0;
            int indexWord;
            int indexKey;
            string encryptWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                if(word[i] == ' ')
                {
                    encryptWord += ' ';
                    continue;
                } else if ((word[i] == '\r') && (word[i+1] == '\n'))
                {
                    encryptWord += "\r\n";
                    continue;
                }
                indexWord = Array.IndexOf(alphabet, word[i]);
                indexKey = Array.IndexOf(alphabet, key[i % key.Length]);
               
                indexEncrypt = (indexWord + indexKey + 1) % alphabet.Length ;

                encryptWord += alphabet[indexEncrypt];
            }
            
            return encryptWord;
        }

        public string EncryptTwo()
        {
            int indexEncrypt = 0;
            int indexWord;
            int indexKey;
            string encryptWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    encryptWord += ' ';
                    continue;
                }
                else if ((word[i] == '\r') && (word[i + 1] == '\n'))
                {
                    encryptWord += "\r\n";
                    continue;
                }
                indexWord = Array.IndexOf(alphabet, word[i]);
                indexKey = Array.IndexOf(alphabet, key[i % key.Length]);

                indexEncrypt = (indexWord + indexKey) % alphabet.Length;

                encryptWord += alphabet[indexEncrypt];
            }

            return encryptWord;
        }

        public string Decrypt()
        {
            int indexDecrypt = 0;
            int indexText;
            int indexKey;
            string decryptWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    decryptWord += ' ';
                    continue;
                }else if ((word[i] == '\r') && (word[i + 1] == '\n'))
                {
                    decryptWord += "\r\n";
                    continue;
                }
                indexText = Array.IndexOf(alphabet, word[i]);
                indexKey = Array.IndexOf(alphabet, key[i % key.Length]);

                if ((indexText - indexKey) <= 0)
                {
                    indexDecrypt = (indexText - indexKey - 1) + alphabet.Length;
                }
                else
                {
                    indexDecrypt = (indexText - indexKey - 1) % alphabet.Length;
                }

                decryptWord += alphabet[indexDecrypt];
            }

            return decryptWord;
        }

        public string DecryptTwo()
        {
            int indexDecrypt = 0;
            int indexText;
            int indexKey;
            string decryptWord = "";

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    decryptWord += ' ';
                    continue;
                }
                else if ((word[i] == '\r') && (word[i + 1] == '\n'))
                {
                    decryptWord += "\r\n";
                    continue;
                }
                indexText = Array.IndexOf(alphabet, word[i]);
                indexKey = Array.IndexOf(alphabet, key[i % key.Length]);

                if ((indexText - indexKey) <= 0)
                {
                    indexDecrypt = (indexText - indexKey) + alphabet.Length;
                }
                else
                {
                    indexDecrypt = (indexText - indexKey) % alphabet.Length;
                }

                decryptWord += alphabet[indexDecrypt % alphabet.Length];
            }

            return decryptWord;
        }

        public byte[] fileEncrypt()
        {
            byte[] keyInASCII = Encoding.ASCII.GetBytes(key);
            byte[] indexEncrypt = new byte[bt.Length];
 
            for (int i = 0; i < bt.Length; i++)
                    indexEncrypt[i] = Convert.ToByte((bt[i] + keyInASCII[i % keyInASCII.Length] + 1) % (Byte.MaxValue + 1));

            return indexEncrypt;
        }

        public byte[] fileDecrypt()
        {
            byte[] keyInASCII = Encoding.ASCII.GetBytes(key);
            byte[] indexDecrypt = new byte[bt.Length];
            int indexByte;

            for (int i = 0; i < bt.Length; i++)
            {
                if ((bt[i] - keyInASCII[i % keyInASCII.Length] - 1) < 0)
                {
                    indexByte = bt[i] - keyInASCII[i % keyInASCII.Length] - 1;
                    indexDecrypt[i] = Convert.ToByte(indexByte + (Byte.MaxValue + 1));
                }
                else
                {
                    indexByte = bt[i] - keyInASCII[i % keyInASCII.Length] - 1;
                    indexDecrypt[i] = Convert.ToByte(indexByte % (Byte.MaxValue + 1));
                }
            }

            return indexDecrypt;
        }
        public byte[] fileEncryptTwo()
        {
            byte[] keyInASCII = Encoding.ASCII.GetBytes(key);
            byte[] indexEncrypt = new byte[bt.Length];

            for (int i = 0; i < bt.Length; i++)
                indexEncrypt[i] = Convert.ToByte((bt[i] + keyInASCII[i % keyInASCII.Length]) % (Byte.MaxValue + 1));

            return indexEncrypt;
        }

        public byte[] fileDecryptTwo()
        {
            byte[] keyInASCII = Encoding.ASCII.GetBytes(key);
            byte[] indexDecrypt = new byte[bt.Length];
            int indexByte;

            for (int i = 0; i < bt.Length; i++)
            {
                if ((bt[i] - keyInASCII[i % keyInASCII.Length]) < 0)
                {
                    indexByte = bt[i] - keyInASCII[i % keyInASCII.Length];
                    indexDecrypt[i] = Convert.ToByte(indexByte + (Byte.MaxValue + 1));
                }
                else
                {
                    indexByte = bt[i] - keyInASCII[i % keyInASCII.Length];
                    indexDecrypt[i] = Convert.ToByte(indexByte % (Byte.MaxValue + 1));
                }
            }

            return indexDecrypt;
        }
    }
}
