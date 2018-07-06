using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParanthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            do
            {
                input = Console.ReadLine();
                string error = string.Empty;
                if (CheckBalancedExp(input, out error))
                {
                    Console.WriteLine("Valid Expression");
                }
                else
                {
                    Console.WriteLine("Invalid Expression" + error);
                }
            } while (input != "");

            Console.ReadLine();
        }

        private static bool CheckBalancedExp(string exp, out string error)
        {
            var s = new Stack<char>();
            var expIndex = new Stack<int>();
            error = string.Empty;

            var opeChars = new HashSet<char>(new[] { Constants.openCurly, Constants.openNormal, Constants.openSquare });
            var closedChars = new HashSet<char>(new[] { Constants.closedCurly, Constants.closedNormal, Constants.closedSquare });

            for(int i = 0; i < exp.Length; i++)
            {
                if(opeChars.Any(x=> x == exp[i]))
                {
                    s.Push(exp[i]);
                    expIndex.Push(i);
                    continue;
                }

                if(closedChars.Any(x=> x == exp[i]))
                {
                    if(s.Count() == 0)
                    {
                        error = string.Format(" Character {0} at position {1} is responsible",exp[i],i + 1);
                        return false;
                    }
                    else if (ParanthesisComparer.instance.Equals(s.Pop(), exp[i]))
                    {
                        expIndex.Pop();
                    }
                    else
                    {
                        error = string.Format(" Character {0} at position {1} is responsible", exp[expIndex.Peek()], expIndex.Peek() + 1);
                        return false;
                    }
                }
            }

            if (s.Count() == 0)
                return true;
            else
            {
                error = string.Format(" Character {0} at position {1} is responsible", s.Last(), expIndex.Last() + 1);
                return false;
            }
        }         
    }
}

