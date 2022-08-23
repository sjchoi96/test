using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Enemy : Character
    {
        int rage = 0;
        int maxRage = 0;
        bool berserker = false;

        public Enemy (string newName) : base (newName)
        {

        }

        public override void Generate_Status()
        {
            base.Generate_Status();
            rage = 0;
        }

        public override void Print_Status() // 스텟나오게 하기
        {
            Console.WriteLine("────────────────");
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"HP   : {hp}/{maxHP}");
            Console.WriteLine($"Rage : {rage}/{maxRage}");
            Console.WriteLine($"STR  : {strength}");
            Console.WriteLine($"DEX  : {dexterity}");
            Console.WriteLine($"INT  : {intelligence}");
            Console.WriteLine("────────────────");
        }
        
        void BerserkerMode(bool on)
        {
            berserker = on;
            if (berserker)
            {
                strength *= 2;
            }
            else
            {
                //strenth /= 2;
                strength = strength >> 1; // 절반으로 줄이기
            }
        }

        public override void Take_Damage(float damage)
        {
            // 맞을 때마다 최대 분노의 1/10 증가 + 데미지 10당 1씩 증가
            rage += (int)(maxRage * 0.1f + damage * 0.1f);
            if (rage >= maxRage)
            {
                BerserkerMode(true);
            }
            base.Take_Damage(damage);
        }

    }
}
