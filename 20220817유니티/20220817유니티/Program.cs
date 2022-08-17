using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220817유니티
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("최성준"); //출력 
            //string str = Console.ReadLine(); // 키보드입력을 받아서 str 이라는 string 변수에 저장한다.
            //Console.WriteLine(str);

            //변수: 변하는 숫자, 컴퓨터에서 사용할 데이터를 저장할수있는곳.
            //변수의 종류: 
            // int: integer 정수. 소수점 없는 숫자 32bit
            // float: 실수. 소수점 있는 숫자. 32bit
            // string: 문자열. 글자들을 저장
            // bool: true/false 저장.

            /*
            int a = 10; // a 라는 인티저 변수에 10이라는 데이터를 넣는다
            long b = 50000000000; // 50억은 int 에 넣을수없다. 32비트로 표현가능한 숫자의 갯수는 2^32(4,294,967,296)개 이기 때문이다.
            int c = -100;
            int d = 2000000000;
            int e = 2000000000;
            int f = d + e;
            Console.WriteLine(f);

            //float 의 단점 : 태생적으로 오차가 있음
            float aa = 0.000123f;
            float ab = 0.99999999999999f; // 계산결과 1이 들어있을 수도 있음.
            float ac = 0.00000000000001f;
            float ad = ab + ac;
            Console.WriteLine(ad);

            string str1 = "hello";
            string str2 = "안녕";
            string str3 = $"{b} Hello {a}"; //"Hello 10"
            Console.WriteLine(str3);
            string str4 = str1 + str2; //"hello안녕"
            Console.WriteLine(str4);

            bool b1 = true;
            bool b2 = false;
            */
            /*
            int level = 1;
            int hp = 10;
            float exp = 0.9f;
            string name = "너굴맨";

            // 너굴맨의 레벨은 1이고, HP 는 10, EXP 는 0.9다.

            string result = $"{name}의 레벨은 {level} 이고, HP 는 {10} 이고, EXP 는 {exp}다.\n";
            Console.WriteLine(result);

            Console.WriteLine($"이름 : {name}\nlevel: {level}\nHP : {hp}\nexp : {exp}"); // \n 로 다음줄로 만들수 있다. "\n = new line"

            Console.Write("이름을 입력하세요 : ");
            name = Console.ReadLine();
            Console.Write($"{name}의 레벨을 입력하세요 : ");

            // level 은 int 라서 숫자입력해야함

            string temp = Console.ReadLine();

            //level = int.Parse(temp); //string을 int 로 변경해주는 코드 (숫자로 바꿀 수 있을때만 가능). 간단하지만 위험함
            //level = Convert.ToInt32(temp); string 을 int 로 변경해주는 코드 숫자로 바꿀수있을때만 가능). 더 세세하게 변경 가능하다. 그래도 위험

            int.TryParse(temp, out level); // string 을 int 로 변경해주는 코드 (숫자로 바꿀수 없으면 0으로 만들수도 있음).

            exp = 0.959595f;
            result = $"{name}의 레벨은 {level} 이고, HP 는 {10} 이고, EXP 는 {exp*100:f2}%다.\n"; // *100 을해서 소수점을 % 로 만들수 있고, ':f2'해서 2자리수 반올림이 가능하다.
            Console.WriteLine(result);

            */

            //이름, 레벨, hp, 경험치 각각 입력받고 출력하는 코드 만들기

            string name ;
            int level, hp;
            float exp;
            string read = Console.ReadLine();

            Console.Write("이름을 입력하세요 : ");
            name = Console.ReadLine();

            Console.Write($"{name}의 레벨을 입력하세요 : ");
            read = Console.ReadLine();
            int.TryParse(read, out level);
                        
            Console.Write($"{name}의 HP를 입력하세요 : ");
            read = Console.ReadLine();
            int.TryParse(read, out hp);
            
            Console.Write($"{name}의 EXP를 입력하세요 : ");
            read = Console.ReadLine();
            float.TryParse(read, out exp);
            
            string result = ($"이름 : {name}\n레벨 : {level}\nHP : {hp}\nEXP : {exp*100:F2}");
            Console.WriteLine(result);

            Console.ReadKey(); //키 입력 대기하는 코드
        }
    }
}
