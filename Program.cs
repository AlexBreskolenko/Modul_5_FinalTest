/*
1.Необходимо создать метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж):
Имя;
Фамилия;
Возраст;
Наличие питомца;
Если питомец есть, то запросить количество питомцев;
Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек (заполнение с клавиатуры);
Запросить количество любимых цветов;
Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
Корректный ввод: ввод числа типа int больше 0.
2.Метод, который принимает кортеж из предыдущего шага и показывает на экран данные.
3.Вызов методов из метода Main.
*/

using System;

class Program
{
    //------------------------------------------Методы-------------------------------------------------------
    //Метод для проверки веденно ли число
    static int CheckNum()
    {
        int result = 0;
        while(true)
        {        
            bool flag = int.TryParse(Console.ReadLine(), out int number);

            if (flag == false || number < 1)
            {
                Console.WriteLine("Input error, please try again !");
                //Console.Write("Enter number : ");
            }
            else
            {
                result = number;
                break;
            }
        }
            return result;
    } 

    //Метод для заполнения массива
    static string[] CreateArray(int num)
    {
        var arrResult = new string[num];

        for (int i = 0; i < arrResult.Length; i++)
        {
            Console.Write($"{i + 1}. : ");
            string name = Console.ReadLine();
            arrResult[i] = name;
        }

        return arrResult;
    }

    //Метод для вывода кортежа
    static void PrintTuple((string name, string lastName, int age, bool is_pet,string[] namePet, string[] nameColor) UserPrint)
    {
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        Console.Write($"Ваше имя : {UserPrint.name}");
        Console.Write($"Ваша фамилия : {UserPrint.lastName}");
        Console.Write($"Ваш возраст : {UserPrint.age}");

        if(UserPrint.is_pet)
        {
            Console.WriteLine("Ваши питомцы : ");

            foreach (var name in UserPrint.namePet)
            {
                Console.WriteLine(name);
            }
        }

        Console.WriteLine("Ваши любимые цвета : ");

        foreach (var colors in UserPrint.nameColor)
        {
            Console.WriteLine(colors);
        }
    }


    //Метод для заполнения кортежа
    static (string name, string lastName, int age,bool is_pet, string[] namePet, string[] nameColor) EnterUser()
    {
        (string name, string lastName, int age, bool is_pet,string[] namePet, string[] nameColor) User;

        Console.Write("Введите имя : ");
        User.name = Console.ReadLine();

        Console.Write("Введите фамилию : ");
        User.lastName = Console.ReadLine();

        Console.Write("Введите возраст : ");
        User.age = CheckNum();

        Console.Write("Есть ли у вас питомец ?(Да/Нет) : ");
        string answer = Console.ReadLine();
        if (answer == "Да")
        {
            User.is_pet = true;
            Console.Write("Введите количество ваших питомцев : ");
            int numAnswer = CheckNum();
            User.namePet = CreateArray(numAnswer);
        }
        else
        {
            User.namePet = null;
            User.is_pet = false;
        }
        

        Console.Write("Сколько у вас любимых цветов ? : ");
        int numColor = CheckNum();
        Console.WriteLine("Введите ваши любимые цвета : ");
        User.nameColor = CreateArray(numColor);

        return User;
    }
    
    //-------------------------------------------------------------------------------------------------------

    static void Main(string[] args)
    {
        (string name, string lastName, int age, bool is_pet,string[] namePet, string[] nameColor) anketa = EnterUser();
        PrintTuple(anketa);
    }
}

