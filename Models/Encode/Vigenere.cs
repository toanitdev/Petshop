using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Encode
{
    public class Vigenere
    {
        public static string Encode(string code)
        {

            string t = code;
            string m = "";
            string b = "";
            string decode = "";
            string key = "TOAN";
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string beta = "";
            bool x = true;
            int temp = 0;
            List<int> numArray = new List<int>();
            List<int> numArray2 = new List<int>();
            List<int> numArray3 = new List<int>();
            List<char> charArray = new List<char>();

            int pos = 0;
            for (int i = 0; i < t.Length; i++)
            {

                charArray.Add(key[pos]);
                pos++;
                if (pos >= key.Length)
                    pos = 0;
            }

            for (int i = 0; i < t.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (alpha[j] == t[i])
                        numArray.Add(j);
                }
            }

            for (int i = 0; i < charArray.Count; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (alpha[j] == charArray[i])
                        numArray2.Add(j);
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if ((numArray[i] + numArray2[i]) >= 26)
                {
                    numArray3.Add((numArray[i] + numArray2[i]) % 26);
                }
                else
                {
                    if ((numArray[i] + numArray2[i]) < 26)
                    {
                        numArray3.Add((numArray[i] + numArray2[i]));
                    }

                }
            }
            foreach (int item in numArray3)
            {
                b += alpha[item];
            }
            return b.ToString();

        }
        public static string DeCode(string code)
        {

            string t = code;
            string m = "";
            string b = "";
            string decode = "";
            string key = "TOAN";
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string beta = "";
            bool x = true;
            int temp = 0;
            List<int> numArray = new List<int>();
            List<int> numArray2 = new List<int>();
            List<int> numArray3 = new List<int>();
            List<char> charArray = new List<char>();

            int pos = 0;
            for (int i = 0; i < t.Length; i++)
            {

                charArray.Add(key[pos]);
                pos++;
                if (pos >= key.Length)
                    pos = 0;
            }

            for (int i = 0; i < t.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (alpha[j] == t[i])
                        numArray.Add(j);
                }
            }

            for (int i = 0; i < charArray.Count; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (alpha[j] == charArray[i])
                        numArray2.Add(j);
                }
            }
            for (int i = 0; i < t.Length; i++)
            {
                if ((numArray[i] - numArray2[i]) >= 0)
                {
                    numArray3.Add(numArray[i] - numArray2[i]);
                }
                else
                {
                    if ((numArray[i] - numArray2[i]) < 0)
                    {
                        numArray3.Add((numArray[i] - numArray2[i]) + 26);
                    }

                }
            }
            foreach (int item in numArray3)
            {
                b += alpha[item];
            }
            return b.ToString();

        }
    }
}
