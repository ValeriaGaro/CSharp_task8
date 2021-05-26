using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8
{
    class Program
    {
        static void Main()
        {
            //checking 1
            List<User> list_users = new List<User>
            {
                new User("Anton", "anton_gr@gmail.com", 32),
                new User("Alina", "alinaa@mu", 26),
                new User("Antonina", "antonina_latush/gmail.com", 57),
                new User("Tatsiana", "tatsiana_gromova@gmil.com", 69),
                new User("Valeria", "valeeeerrre", 29)

            };

            var choice = list_users.Where(user => user.age > 13 &&  user.mail.Contains("@")).ToList();
            Console.WriteLine("Users List you chose");
            foreach (var usr in choice)
            {

                Console.WriteLine($"User name: {usr.name} User mail:  {usr.mail} user age: {usr.age}");
            }

            /*  2   
        [Использовать LINQ]

        Необходимо получить список уникальных (без повторений) доменных имен почтовых ящиков из списка почтовых адресов
        Доменное имя - правая часть почтового адреса (всё что после @)
            */

            string[] emails = new string[]
            {
                "randommail@mail.ru",
                "someoneshere@gmail.by",
                "jackteller@gmail.com",
                "yellow.brick.records@mail.cz",
                "randommail2@mail.ru",
                "kidywalters999@gmail.com",
                "mail.trueman@mail.cz",
                "sol.goodman@gmail.com",
                "alfick.demon.44@mail.gv.cz"
            };

            var list_emails = (from email_domain in emails
                               select email_domain.Substring(email_domain.IndexOf("@") + 1)).Distinct().ToList();

            foreach (var email_domain in list_emails) 
            {
                Console.WriteLine("Уникальное доменное имя: " + email_domain);
            }

            //checking 3
            Database checking_database = new Database(4);

            Race Human_race = new Race("Human");
            Race Wolf_race = new Race("Wolf");

            checking_database.AddPlayers(new Player("Cristofer", 12, Human_race),
                new Player("Adam", 18, Human_race),
                new Player("Marianna", 98, Human_race),
                new Player ("Wolf1", 245, Wolf_race),
                new Player("Wolf2", 520, Wolf_race),
                new Player("Wolf3", 25, Wolf_race));
            checking_database.Print_players();

            

            List<Player> one_race_players = checking_database.player_database.Where(player => player.race.Name == Wolf_race.Name).ToList();
            Print_list(one_race_players);

            List<Player> qurrent_level = checking_database.player_database.Where(player => player.age > 100).ToList();
            Print_list(qurrent_level);

            List<Player> name_letter = checking_database.player_database.Where(player => player.Nickname[0] == 'A').ToList();
            Print_list(name_letter);

            List<Player> complex_choice = checking_database.player_database.Where(player => (player.race.Name == Human_race.Name && player.age > 50) || player.race.Name == Wolf_race.Name && player.age > 200).ToList();

            Print_list(complex_choice);

            Console.ReadKey();
        }
        static void Print_list(List<Player> Name)
        {
            foreach (var players_in_list in Name)
            {

                Console.WriteLine($"Name: {players_in_list.Nickname}");
            }
        }
    }
}

/*  1
          +  Объявить тип User содержащий:
           + • Имя пользователя
           + • Возраст
           + • Почтовый адрес
           + • Конструктор с параметрами
          
           + Создать коллекцию из 5 пользователей

			[Использовать LINQ]
          +  Создать List<User>, в который добавить только пользователей старше 13 лет и почтовые ящики у которых содержат символ @
        */
//1
struct User 
{
    public readonly string name;
    public readonly int age;
    public readonly string mail;
    public User(string name, string mail, int age)
    {
        this.name = name;
        this.mail = mail;
        this.age = age;
    }
}



    /* 3
   + Создать структуру Race
   + • Свойство Name (только для чтения)
   + • Конструктор, инициализирующий Name

   + Создать класс Player, содержащий:
   + [Информация] Модификаторы доступа и сигнатуру (поле или свойство) выбрать на свое усмотрение
   + • Ник
   + • Возраст персонажа
   + • Раса (тип Race)
   + • Конструктор для инициализации полей

   + Создать класс DataBase
   + [Информация] Модификаторы доступа и сигнатуру (поле или свойство) выбрать на свое усмотрение
   + • Максимальный размер базы данных (целое число)
   + • Коллекция для хранения объектов типа Player
   + • Конструктор, инициализирующий максимальный размер базы данных
   + • Открытый метод void AddPlayers(X) для добавления игроков. Вместо X — возможность принимать в качестве параметра любое количество объектов типа Player.
   + • Учесть в базе данных возможность нехватки места (превышение макс. размера базы)
   + • Учесть возможность наличия такого никнейма в базе до его добавления (реализовать с использованием следующего метода)
  +  • Закрытый метод bool IsNickNameExists(string nickname) возвращающий true если такой ник уже есть в базе, false - иначе

    Main
    + • Создать игроков (с произвольными никнеймами, уровнем и расой)
    + • Создать базу данных
   + • Добавить игроков в базу данных
    [LINQ]
    Сформировать из игроков, находящихся в базе данных, следующие выборки:
   + • Игроки одной расы (любая произвольная раса из существующих)
   + • Игроки больше X уровня. X выбрать произвольно.
  +  • Игроки, чьи ники начинаются с определенной (произвольной) буквы
   + • Игроки расы X с уровнем не больше чем A и игроки расы Y с уровнем не больше чем B. A, B, X, Y выбрать на свое усмотрение.
    */

struct Race
{ 
public string Name { get; }

    public Race(string name)
    {
        Name = name;
    }

}

class Player
{

    public string Nickname;

    public int age;

    public Race race;

    public Player(string nickname, int age, Race race) 
    {
        this.Nickname = nickname;
        this.age = age;
        this.race = race;
    }

}
class Database 
{

    private int MaxLength;

    public List<Player> player_database = new List<Player>();

    public Database(int db_length) 
    {
        MaxLength = db_length;
        player_database.Capacity = MaxLength;

    }


    public void AddPlayers(params Player[] players)
    {
        foreach (var player in players)
        {
            if (player_database.Capacity - player_database.Count <= 0)
            {
               continue;
            }
            else if(player_database.Capacity - player_database.Count > 0)
                {
                if (IsNickNameExists(player.Nickname))
                {
                    continue;
                }
                else {
                    player_database.Add(player);
                }
                
            }
           
        
        }

    }
    private bool IsNickNameExists (string nickname)
    {
        foreach (var player in player_database)
        {
            if (nickname == player.Nickname)
            {
                return true;
            }
        }
       
        return false;
    }

    public void Print_players()
    {
        foreach (var player in player_database)
        {
            Console.WriteLine($"Name {player.Nickname} " +
                $"level {player.age} " +
                $"race {player.race.Name}");
        }
    }
}
