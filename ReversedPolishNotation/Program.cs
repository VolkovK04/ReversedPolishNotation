using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedPolishNotation
{
    internal class Program
    {
        static Program()
        {
            Operators['*'] = 3;
            Operators['/'] = 3;
            Operators['-'] = 4;
            Operators['+'] = 4;
            Operators['&'] = 8;
            Operators['^'] = 9;
            Operators['|'] = 10;

            LeftAssociate = Operators.Keys.ToList();
        }
        static Dictionary<char, int> Operators = new Dictionary<char, int>();
        static List<char> LeftAssociate = new List<char>();
        static bool IsOperetor(char c)
        {
            return Operators.ContainsKey(c);
        }
        static int GetPriority(char c)
        {
            return Operators[c];
        }
        static bool IsLeftAssociate(char c)
        {
            return LeftAssociate.Contains(c);
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = "";
            Stack<char> buffer = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c >= '0' && c <= '9')
                    output += c;
                if (c == '(')
                    buffer.Push(c);
                if (c == ')')
                {
                    while (buffer.Peek() != '(')
                    {
                        output += buffer.Pop();
                    }
                    buffer.Pop();
                }
                if (IsOperetor(c))
                {
                    while(buffer.Count != 0 && IsOperetor(buffer.Peek()) && 
                        (GetPriority(buffer.Peek()) < GetPriority(c) || (GetPriority(buffer.Peek()) == GetPriority(c) && IsLeftAssociate(buffer.Peek()))))
                    {
                        output += buffer.Pop();
                    }
                    buffer.Push(c);
                }
            }
            while (buffer.Count != 0)
            {
                output += buffer.Pop();
            }
            Console.WriteLine(output);
            Console.ReadLine();
        }

    }
}
