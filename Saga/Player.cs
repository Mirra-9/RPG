using System;
using System.Collections.Generic;

namespace CourseApp
{
    public abstract class Player
    {
        private static readonly Random Rnd = new Random(); // readonaly - поле для чтения, изменить нельзя
        private static string[] names = new string[40]
           {
                "Артур",
                "Робин",
                "Мэрлин",
                "Гвэн",
                "Кэтрин",
                "Эдвард",
                "Патрик",
                "Грегори Хаус",
                "Стефан",
                "Деймон",
                "Элиот",
                "Этель",
                "Софи",
                "Верис",
                "Сильвия",
                "Геральт",
                "Джоэл",
                "Кассион",
                "Клаус",
                "Мистик",
                "Джей",
                "Роберт",
                "Элиадес",
                "Леонардо",
                "Царица",
                "Пьер",
                "Фауст",
                "Тето",
                "Мэри",
                "Гектор",
                "Эдуард",
                "Максимильян",
                "Аннэт",
                "Диана",
                "Мико",
                "Широ",
                "Сора",
                "Неван",
                "Роуэн",
                "Сиф",
           };

        public Player()
        {
            Name = names[Rnd.Next(0, 30)];
            Hp = Rnd.Next(50, 300);
            Strength = Rnd.Next(25, 150);
            Effects = false;
            StandTime = 0;
        }

        public string Class { get; protected set; }

        public string Name { get; set; }

        public double Hp { get; set; }

        public int Strength { get; set; }

        public bool Effects { get; set; }

        public int StandTime { get; set; }

        public string AbilityName { get; set; } // название способности

        public int AbilityDamage { get; set; } // урон способности

        public int DamageInfo { get; set; } // информация об уроне

        public virtual int Ability(Player player, Player enemy) // virtual - методы, которые сделаны доступными для переопределения
        {
            return 0;
        }

        public int Attack(Player fighter, Player fighterEnemy)
        {
            if (fighter.Effects == true)
            {
                fighter.Effects = false;
                DamageInfo = fighter.Ability(fighter, fighterEnemy);
                return DamageInfo;
            }
            else
            {
                DamageInfo = Strength;
                return Strength;
            }
        }

        public void GetDamage(int damage)
        {
            Hp -= damage;
        }

        public override string ToString()
        {
            return $"Name: {Name}. Strength: {Strength}. Health: {Hp}.";
        }
    }
}