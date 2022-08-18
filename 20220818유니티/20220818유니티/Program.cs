using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220818유니티
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestFunction();

            //실습
            // 1. int 타입의 파라메터를 하나 받아서 그 숫자에 해당하는 구구단을 출력해주는 함수 만들기
            // 2. 1번에서 만드는 함수는 2~9까지 입력이 들어오면 해당 구구단 출력. 그 외의 숫자는 "잘못된 입력입니다" 출력하기
            // 3. 메인 함수에서 숫자를 하나 입력받는 코드가 있어야 한다.

            //bool b1 = true;
            //bool b2 = false;

            //// 논리연산자
            //// && (and) - 둘 다 참일 때만 참이다 t && t = t, t && f = f, f && f = f
            //// || (or) - 둘 중 하나만 참이면 참이다 t || t = t, t || f = t, f || f = f
            //// ~  (not) -  true 는 false, false 는 true. ~t = f


            //string temp = Console.ReadLine();
            //int dan;
            //int.TryParse(temp, out dan);

            //Gugudan(dan);

            //Console.ReadKey();

            

            Character human1 = new Character(); // 메모리 할당 완료(Instance 화). 객체 (object) 생성 완료 (객체의 인스턴스를 만들었다)
            Character human2 = new Character(); // Character 타입으로 하나 더 만든 것. human 1과 human 2는 서로 다르다.

            Console.WriteLine($"{human1.HP}");

            human1.TestPrintStatus();

            

            Console.ReadKey();


        }

        public static void Gugudan(int dan)
        {











            //private static void TestFunction()
            //{
            //    string name = "너굴맨";
            //    int level = 2;
            //    int hp = 10;
            //    int maxHP = 20;
            //    float exp = 0.1f;
            //    float maxExp = 1.0f;

            //    PrintCharacter(name, level, hp, maxHP, exp, maxExp);
            //}

            //static void PrintCharacter(String name, int level, int hp, int maxHP, float exp, float maxExp)
            //{
            //    Console.WriteLine($"이름\t:{name}");
            //    Console.WriteLine($"레벨\t:{level}");
            //    Console.WriteLine($"HP\t:({hp}/{maxHP})");
            //    Console.WriteLine($"Exp\t:({exp:f2}/{maxExp:f2})");

        }
    }
}
