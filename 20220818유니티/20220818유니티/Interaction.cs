using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _20220818유니티
{
    internal class Interaction : Character
    {
        Human human1 = new Human();
        Orc orc1 = new Orc();


        public virtual void menuSelect(Character target)
        {


            Console.WriteLine("메뉴를 선택하세요");
            Console.WriteLine("1. 공격\n2. 스킬\n3. 힐");
            string temp = Console.ReadLine();
            int selectMenu;
            int.TryParse(temp, out selectMenu);

            switch (selectMenu)
            {
                case 1:
                    Console.WriteLine("공격!");
                    human1.Attack(orc1);
                    break;

                case 2:

                    Console.WriteLine("스킬사용!");
                    Console.WriteLine("스킬을 선택하세요\n1번. 크리티컬 히트");
                    int selectSkill;
                    int.TryParse(temp, out selectSkill);
                    temp = Console.ReadLine();

                    //if (selectSkill == 1)
                    //{
                    int damage = strength;
                    damage *= 2;

                    Console.WriteLine($"{name}의 크리티컬 히트!");

                    Console.WriteLine($"{name}이 {target.Name}에게 {damage}만큼의 공격을 합니다.(공격력 : {damage})");

                    target.TakeDamage(damage);
                    break;

                case 3:
                    Console.WriteLine("힐");
                    hp += 5;
                    break;
            }
        }
    }
}
