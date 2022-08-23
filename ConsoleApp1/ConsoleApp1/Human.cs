using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    public class Human : Character
    {
        int mp = 100;
        int maxMP = 100;

        const int RegenerationCount = 3; // 리제너레이션도 턴 추가해야함!!!!
        int regenerationRemain = 0;

        const float DefenseCount = 3; // 3턴간 방어력이 오른다
        float defenseRemain = 0;




        public Human(string newName) : base(newName)
        {

        }

        public override void Generate_Status()
        {
            base.Generate_Status();
            maxMP = rand.Next() % 100;
            mp = maxMP;
        }

        public override void Print_Status()
        {
            Console.WriteLine("────────────────");
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"HP   : {hp}/{maxHP}");
            Console.WriteLine($"MP   : {mp}/{maxMP}");
            Console.WriteLine($"STR  : {strength}");
            Console.WriteLine($"DEX  : {dexterity}");
            Console.WriteLine($"INT  : {intelligence}");
            Console.WriteLine("────────────────");
        }

        public override void Use_Attack(Character target)
        {
            float damage = (strength + (dexterity * 0.3f));
            float HP = 0;

            if (rand.NextDouble() < 0.3f)
            {
                damage += (strength + (dexterity * 0.6f));
                Console.WriteLine($"{name}의 치명타!");
            }

            if (regenerationRemain > 0)
            {
                Console.WriteLine("리제너레이션으로 인해 체력이 올랐습니다.");
                regenerationRemain--;
                
                
            }

            Console.WriteLine($"{name}이 {target.Name}한테 {damage}의 피해를 입힙니다. 공격력 : {damage}");
            target.Take_Damage(damage);
            

        }

        public void Use_Skill(Character target)
        {
            Console.WriteLine("스킬을 선택하세요\t");
            Console.WriteLine("1) 파워 스트라이크 (mp -10)\t2) 리제너레이션 (mp -10)\t3) 블레스 (mp -10)");
            int skillType;
            string temp = Console.ReadLine();
            int.TryParse(temp, out skillType);

            int Require_Mana = 10;

            
            
                switch (skillType)
                {
                    case 1:
                    if (mp - Require_Mana > 0)
                    {
                        Console.WriteLine("파워 스트라이크를 사용했습니다");
                        mp -= 10;
                        float damage = (strength + (dexterity * 0.3f));
                        damage += 2;
                        Console.WriteLine($"{name}이 {target.Name}한테 {damage}의 피해를 입힙니다. 공격력 : {damage}");
                        target.Take_Damage(damage);
                    }
                        break;

                    case 2:
                    if (mp - Require_Mana > 0)
                    {
                        Console.WriteLine("리제너레이션을 사용했습니다.\n공격할 때 마다 체력이 올라갑니다.\n");
                        Console.WriteLine($"3턴간 공격할때 체력이 올라감");
                        regenerationRemain += RegenerationCount;
                        mp -= 10;
                        HP += 3;

                    }
                        break;

                    case 3:
                    if (mp - Require_Mana > 0)
                    {
                        Console.WriteLine("블레스를 사용했습니다.\tStrength 와 Dexterity가 2씩 올라갑니다.");
                        mp -= 10;
                        strength += 2;
                        dexterity += 2;

                    }
                        break;
                }
            if (mp < 10)
            {
                Console.WriteLine("마나가 부족합니다");
                Console.WriteLine("공격이나 스킬을 선택하세요");
                ㅁㄴㅇㄻㄴㅇㄻㄴㅇㄹ
            }

            

            

            


            
        }

        public void Regeneration()
        {
            Console.WriteLine($"3턴간 공격할때 체력이 올라감");
            regenerationRemain += RegenerationCount;
        }


        public void Use_Defense()
        {
            Console.WriteLine($"3턴간 받는 데미지 반감");
            defenseRemain += DefenseCount;

        }

        public override void Take_Damage(float damage)
        {
            if (defenseRemain > 0)
            {
                Console.WriteLine("방어력이 올랐습니다! 받는 데미지가 절반 감소합니다.");

                defenseRemain--;

                damage = damage * 0.5f;
            }
            base.Take_Damage(damage);
        }

    }
}
