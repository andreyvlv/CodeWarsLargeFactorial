using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWLargeFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorial(13));
            Console.WriteLine();
            Console.ReadLine();
        }

        public static string Factorial(int n)
        {
            string fact = "1";
            if (n > 0)
            {
                for (int i = 1; i <= n; i++)
                {                   
                    fact = Multiply(IntToDigList(i.ToString()), IntToDigList(fact));
                }
            }
            else if (n <= 0)
            {
                fact = null;

            }
            return fact;
        }

        public static string Multiply(List<int> x, List<int> y)
        {                       
            x.Reverse();
            y.Reverse();

            List<int> result = new List<int>();
            List<char> charRes = new List<char>();
            string res = "";
            int tempAddCount = 0;

            
            for (int ctrY = 0; ctrY < y.Count; ctrY++)
            {
                tempAddCount = ctrY;

                for (int ctrX = 0; ctrX < x.Count; ctrX++)
                {
                    string product = (x.ElementAt(ctrX) * y.ElementAt(ctrY)).ToString();
                    char[] currentProduct = product.ToCharArray();

                    int AddCO = 0;
                    string addition;
                    int coCount = tempAddCount;

                    if (currentProduct.Length > 1) 
                    {
                        
                        if (result.Count == 0 || result.Count <= coCount)
                        {
                            result.Insert(coCount, (int)Char.GetNumericValue(currentProduct[1]));
                        }
                        else
                        {
                            
                            addition = ((int)Char.GetNumericValue(currentProduct[1]) + result.ElementAt(coCount)).ToString();
                            processAddition(ref result, ref AddCO, addition, coCount, false);
                        }

                        coCount++; 

                        if (result.Count == 0 || result.Count <= coCount)
                        {
                            addition = ((int)Char.GetNumericValue(currentProduct[0]) + AddCO).ToString();
                            processAddition(ref result, ref AddCO, addition, coCount, true);
                        }
                        else
                        {
                            addition = ((int)Char.GetNumericValue(currentProduct[0]) + AddCO + result.ElementAt(coCount)).ToString();
                            processAddition(ref result, ref AddCO, addition, coCount, false);
                        }

                        while (AddCO > 0) 
                        {
                            coCount++;

                            if (result.Count == 0 || result.Count <= coCount)
                            {
                                result.Insert(coCount, AddCO);
                                AddCO = 0;
                            }
                            else
                            {
                                addition = (AddCO + result.ElementAt(coCount)).ToString();
                                processAddition(ref result, ref AddCO, addition, coCount, false);
                            }
                        }
                    }
                    else 
                    {
                        if (result.Count == 0 || result.Count <= coCount)
                        {
                            result.Insert(coCount, (int)Char.GetNumericValue(currentProduct[0]));
                        }
                        else
                        {
                            addition = ((int)Char.GetNumericValue(currentProduct[0]) + result.ElementAt(coCount)).ToString();
                            processAddition(ref result, ref AddCO, addition, coCount, false);
                        }

                        while (AddCO > 0)
                        {
                            coCount++;

                            if (result.Count == 0 || result.Count <= coCount)
                            {
                                result.Insert(coCount, AddCO);
                                AddCO = 0;
                            }
                            else
                            {
                                addition = (AddCO + result.ElementAt(coCount)).ToString();
                                processAddition(ref result, ref AddCO, addition, coCount, false);
                            }
                        }

                    }
                    tempAddCount += 1;
                }
            }

            result.Reverse();
            foreach (var charr in result)
            {
                charRes.Add(Char.Parse(charr.ToString()));
            }          
            return new string(charRes.ToArray());            
        }
       
        public static void processAddition(ref List<int> result, ref int carryOver, string additionResult, int currentPosition, bool isInsert)
        {
            if (additionResult.Length > 1)
            {
                char[] currentAddition = additionResult.ToCharArray();
                result[currentPosition] = (int)Char.GetNumericValue(currentAddition[1]);
                carryOver = (int)Char.GetNumericValue(currentAddition[0]);
            }
            else
            {
                if (isInsert)
                    result.Insert(currentPosition, Int32.Parse(additionResult));
                else
                    result[currentPosition] = Int32.Parse(additionResult);
                carryOver = 0;
            }
        }
      
        public static List<int> IntToDigList(string strNum)
        {
            List<int> digList = new List<int>();
            for (int ctr = 0; ctr < strNum.Length; ctr++)
            {
                digList.Add((int)Char.GetNumericValue(strNum[ctr]));
            }
            return digList;
        }
    }
}
