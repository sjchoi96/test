using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice0817
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sumResult = Sum(10, 20);
            Console.WriteLine($"SumResult : {sumResult}");

            Print();

            string name = "Lulu";
            int level = 2;
            int hp = 10;
            int maxHP = 20;
            float exp = 0.1f;
            float maxExp = 1.0f;

            PrintCharacter("Lulu", 2, 10, 20, 0.1f, 1.0f);


            Console.ReadKey();









            //Practice 1
            //string name;
            //int level;
            //int hp;
            //float exp;

            //Console.WriteLine("이름을 입력하세요.\n");
            //name = Console.ReadLine();

            //Console.WriteLine("레벨을 입력하세요.\n");
            //string temp;
            //temp = Console.ReadLine();
            //int.TryParse(temp, out level);

            //Console.WriteLine("HP를 입력하세요.\n");
            //temp = Console.ReadLine();
            //int.TryParse(temp, out hp);

            //Console.WriteLine("EXP를 입력하세요.\n");
            //temp = Console.ReadLine();
            //float.TryParse(temp, out exp);


            //string result = ($"Name : {name}\nLevel : {level}\nHP : {hp}\nEXP : {exp}");
            //Console.WriteLine(result);

            //Console.ReadKey();

            //Practice 2
            //string name;
            //int level;
            //int hp;
            //float exp = 0.5f;

            //string temp;
            //temp = Console.ReadLine();

            //float tempExp;
            //float.TryParse(temp, out tempExp);
            //float sum = exp + tempExp;


            //while ((sum) < 1.0f )
            //{
            //    Console.WriteLine($"Current EXP is {exp}");
            //    Console.WriteLine("Need more EXP\n");
            //    Console.WriteLine("Type in the EXP needed\n");
            //    temp = Console.ReadLine();

            //    sum += tempExp;
            //}

            //{
            //    Console.WriteLine("Level UP!");
            //}

            //level = 1;
            //while (level < 3)
            //{
            //    Console.WriteLine($"Current Level : {level}");
            //    level++;
            //}
            //Console.WriteLine("Level 3 reached");
            //Console.ReadKey();

            //hp = 10;
            //for (int i=0; i<3;i++)
            //{
            //    Console.WriteLine($"현재 HP : {hp}");
            //    hp += 10;
            //}
            //Console.WriteLine($"최종 HP : {hp}");

            //Console.ReadKey();

            //Practice 3

            //exp = 0.0f;
            //Console.WriteLine($"현재 경험치 : {exp}");

            //while (1.0f > exp)
            //{
            //    Console.WriteLine("경험치를 추가해야합니다.");
            //    Console.WriteLine("추가할 경험치 : ");
            //    string temp = Console.ReadLine();

            //    float tempExp = 0.0f;
            //    float.TryParse(temp, out tempExp);

            //    exp += tempExp;
            //}

            //Console.WriteLine("레벨업");



        }

        static int Sum(int a, int b)
        {
            int result = a + b;

            return result;
        }

        static void Print()
        {
            Console.WriteLine("Print");
        }

        static void PrintCharacter(string name, int level, int hp, int maxHP, float exp, float maxExp)
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Level : {level}");
            Console.WriteLine($"HP : {hp}");
            Console.WriteLine($"Max HP : {maxHP}");
            Console.WriteLine($"EXP : {exp}");
            Console.WriteLine($"Max EXP : {maxExp}");

        }
    }

    
}
