using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice0818
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("출력할 구구단을 입력하세요");
            string temp = Console.ReadLine();
            int dan;
            int.TryParse(temp, out dan);

            Gugudan(dan);

            Console.ReadKey();
        }

        static void Gugudan(int dan)
        {
            if(1 < dan && dan < 10)
            {
                Console.WriteLine($"구구단 {dan}단 출력");
                for(int i=1; i <10; i++)
                {
                    Console.WriteLine($"{dan} * {i} = {dan * i}");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
            }
        }
    }
}
