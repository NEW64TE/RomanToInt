using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var romanNumber = "MCMXCIV";

            Console.WriteLine(romanNumber);
            Console.WriteLine(RomanToInt(romanNumber));
        }

        public static int RomanToInt(string s)
        {
            var result = 0;
            var isLastConnected = false;

            Dictionary<string, int> resolvingDict = new Dictionary<string, int>()
            {
                { "I", 1 },
                { "IV", 4 },
                { "V", 5 },
                { "IX", 9 },
                { "X", 10 },
                { "XL", 40 },
                { "L", 50 },
                { "XC", 90 },
                { "C", 100 },
                { "CD", 400 },
                { "D", 500 },
                { "CM", 900 },
                { "M", 1000 }
            };

            List<string> stringList = s.ToUpper().ToCharArray().Select(c => c.ToString()).ToList();

            for (int i = 0; i < stringList.Count; i++)
            {
                if (isLastConnected)
                {
                    i = 0;
                }

                if(i < stringList.Count - 1)
                {
                    switch (stringList[i])
                    {
                        case "I":
                            if(stringList[i + 1] == "V" || stringList[i + 1] == "X")
                            {
                                ConnectForSpecialCase(stringList, i);
                                isLastConnected = true;
                            }
                            else
                            {
                                isLastConnected = false;
                            }
                            break;
                        case "X":
                            if (stringList[i + 1] == "L" || stringList[i + 1] == "C")
                            {
                                ConnectForSpecialCase(stringList, i);
                                isLastConnected = true;
                            }
                            else
                            {
                                isLastConnected = false;
                            }
                            break;
                        case "C":
                            if (stringList[i + 1] == "D" || stringList[i + 1] == "M")
                            {
                                ConnectForSpecialCase(stringList, i);
                                isLastConnected = true;
                            }
                            else
                            {
                                isLastConnected = false;
                            }
                            break;
                        default:
                            if (isLastConnected)
                            {
                                isLastConnected = false;
                            }
                            break;
                    }
                }
            }

            foreach (var str in stringList)
            {
                Console.WriteLine(str);
            }

            return result;
        }

        private static void ConnectForSpecialCase(List<string> stringList, int i)
        {
            var tempString = stringList[i] + stringList[i+1];
            stringList.RemoveAt(i);
            stringList.RemoveAt(i);
            stringList.Add(tempString);

        }
    }
}
