using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program 
    {



        static void Main(string[] args)
        {
            Human player;
            string result;

            do
            {
                Console.Write("당신의 이름을 입력해 주세요 : ");
                string name = Console.ReadLine();
                player = new Human(name);
                Console.Write($"이대로 진행하시겠습니까? (yes/no) : ");
                result = Console.ReadLine();
            }

            while (result != "yes" && result != "Yes" && result != "y" && result != "Y");

            Enemy enemy = new Enemy("나쁜구리");

            Console.WriteLine($"오크 {enemy.Name} 가 나타났다!");

            Console.WriteLine("----------------------전투 시작-------------------------");

            while (true)
            {
                int selection = 0;
                do
                {
                    Console.Write("행동을 선택하세요\n1) 공격\n2) 스킬 \n3) 방어\n");
                    string temp = Console.ReadLine();
                    int.TryParse(temp, out selection);

                } while (selection < 1 || selection > 3);
                //while (selection != 1 && selection != 2 && selection != 3);

                switch (selection)
                {
                    case 1:
                        player.Use_Attack(enemy);
                        break;
                    case 2:
                        player.Use_Skill(enemy);
                        break;
                    case 3:
                        player.Use_Defense();
                        break;
                    default:
                        break;
                }

                player.Print_Status();
                enemy.Print_Status();

                if (enemy.IsDead)
                {
                    Console.WriteLine("승리!");
                    break;
                }

                enemy.Use_Attack(player);
                player.Print_Status();
                enemy.Print_Status();

                if(player.IsDead)
                {
                    Console.WriteLine("패배...");
                    break;
                }
            }

            Console.ReadKey();



        }
    }
}
