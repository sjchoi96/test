using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Character
    {
        protected string name;
        protected float hp, maxHP;
        protected int strength;
        protected int dexterity;
        protected int intelligence;

        protected bool isDead = false;
        
        //읽기용으로 만들기
        public string Name => name; 
        public bool IsDead => isDead;

        //이름 5가지 생성
        string[] nameArray = { "개구리", "너굴리", "다구리", "마구리", "호구리" };

        
        protected Random rand;

        public float HP
        {
            get
            { 
                return hp; 
            }

            set
            { 
                hp = value;
                if (hp > maxHP)
                {
                    hp = maxHP;
                }
                if (hp <= 0)
                {
                    Dead();
                }
            }
        }


        public Character (string newName)
        {
            rand = new Random(DateTime.Now.Millisecond);
            name = newName;

            Generate_Status();
            Print_Status();

        }

        public virtual void Print_Status() // 스텟나오게 하기
        {
            Console.WriteLine("────────────────");
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"HP   : {hp}/{maxHP}");
            Console.WriteLine($"STR  : {strength}");
            Console.WriteLine($"DEX  : {dexterity}");
            Console.WriteLine($"INT  : {intelligence}");
            Console.WriteLine("────────────────");
        }

        public virtual void Generate_Status() // 스텟생성
        {
            maxHP = rand.Next(100, 201);
            hp = maxHP;

            strength = rand.Next(1, 20);
            dexterity = rand.Next(1, 20);
            intelligence = rand.Next(1, 20);

        }

        public virtual void Use_Attack (Character target)
        {
            float damage = strength;
            Console.WriteLine($"{name}이 {target.name}에게 {damage}의 피해를 입힙니다. <공격력 : {damage}>");
            target.Take_Damage(damage);
        }

        public virtual void Take_Damage (float damage)
        {
            
            HP -= damage;
            Console.WriteLine($"{name}이 {damage}만큼의 피해를 입었습니다.");

        }

        private void Dead ()
        {
            Console.WriteLine($"{name}이 사망하였습니다.");
            isDead = true; //있는거랑 없는거 다른점 확인하기
        }

    }
}
