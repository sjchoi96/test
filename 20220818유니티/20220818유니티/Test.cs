// using : 어떤 추가적인 기능을 사용할 것인지를 표시하는것
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace : 이름이 겹치는 것을 방지하기 위해 구분지어 놓는 용도
namespace _20220818유니티
{
    // internal : 같은 어셈블리 안에서는 public 다른 어셈블리면 private

    // 접근제한자 (access modifier) :
    // public : 누구든지 접근 가능
    // private : 자기 자신만 사용가능
    // protected :자신과 자신을 상속받은 자식만 접근할 수 있다
    // internal : 같은 어셈블리안에서는 public, 다른 어셈블리면 private

    // 클래스 : 특정한 오브젝트를 표현하기 위해 그 오브잭트가 가져야 할 데이터와 기능을 모아 놓은것
    public class Character //test 클래스를 public 으로 선언한다.
    {
        //멤버 변수 -> 이 클래스에서 사용되는 데이터
        private string name;
        private int hp = 100;
        private int maxHP = 100;
        private int strength = 10;
        private int dexterity = 5;
        private int intelligence = 7;



        //배열 : 같은 종류의 데이터를 한번에 여러개 가지는 유형의 변수
        //int[] intArray; // 인티저를 여러개 가질 수 있는 배열
        //intArray = new int[5]; // 인티저를 5개 가질수 잇도록 할당

        //Random random = new Random();

        //for (int i = 0; i < 30; i++)
        //{
        //    int randNum = random.Next();
        //    // % :앞에 숫자를 뒤의 숫자로 나눈 나머지 값을 돌려주는 연산자. (모듈레이트 연산. 나머지 연산)
        //    // 10 % 3 하면 결과는 1
        //    // % 연산의 결과는 항상 0~(뒤 숫자-1) 로 나온다.
        //    Console.WriteLine($"랜덤넘버:{randNum}");
        //}

        string[] nameArray = { "너굴맨", "개굴맨", "참새맨", "까치맨", "악어맨" }; // nameArray에 기본값 설정 (선언과 할당을 동시에 처리)
        Random rand;

        public int HP
        {
            get
            {
                return hp;
            }
            set
            {

            }
        }

        public Character()
        {
            Console.WriteLine("캐릭터 생성");
            rand = new Random();
            int randomNumber = rand.Next(); // 랜덤 클래스 이용해서 0~21억 사이의 숫자를 랜덤으로 선택
            randomNumber %= 5; //랜덤에서 고른숫자를 0~4사이로 변경
            name = nameArray[randomNumber]; // 0~4 로 변경한 값을 인덱스로 사용하여 이름 배열해서 선택

            maxHP = rand.Next(100, 201); // 100에서 200중에 랜덤으로 선택
            hp = maxHP;

            strength = rand.Next(20) + 1; // 20만쓰면 0~19 까지 선택됨, +1 을 함으로서 1~20으로 범위를 바꿈
            dexterity = rand.Next(20) + 1;
            intelligence = rand.Next(20) + 1;

        }
        public void TestPrintStatus()
        {
            Console.WriteLine("┌────────────────────────────┐");
            Console.WriteLine($"│이름\t :\t{name}");
            Console.WriteLine($"│HP\t :\t{hp,4} / {maxHP,4}");
            Console.WriteLine($"│힘\t :\t{strength,2}");
            Console.WriteLine($"│민첩\t :\t{dexterity,2}");
            Console.WriteLine($"│지능\t :\t{intelligence,2}");

            Console.WriteLine("└────────────────────────────┘");

        }

        public Character(string newName)
        {
            Console.WriteLine($"생성자 호출 - {newName}");
            name = newName;
        }

        public void Attack ()
        {

        }

        public void TakeDamage()
        {

        }



        //멤버 함수 -> 이 클래스가 가지는 기능
        public void Test_func1()
        {

        }
    }
}
