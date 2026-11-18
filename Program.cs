using System;

public class Program
{
    static int passed = 0;
    static int total = 0;
    public static int CalcDelivery(int weight, bool isExpress)
    {
        if (weight <= 0) return -1;
        if (weight > 20)
        {
            int price = weight * 50;
            if (isExpress) price *= 2;
            return price * 95 / 100;
        }
        if (weight > 5)
        {
            int price = weight * 50;
            if (isExpress) price *= 2;
            return price;
        }
        int basePrice = weight * 50;
        if (isExpress) basePrice *= 2;
        return basePrice;
    }
    public static string CheckPassword(string password)
    {
        if (password.Length < 8) return "Короткий пароль";

        bool hasDigit = false;
        bool hasUpper = false;

        foreach (char c in password)
        {
            if (char.IsDigit(c)) hasDigit = true;
            if (char.IsUpper(c)) hasUpper = true;
            if (hasDigit && hasUpper) break;
        }

        if (!hasDigit) return "Нет цифры";
        if (!hasUpper) return "Нет заглавной буквы";

        return "OK";
    }
    public static string Grade(int score)
    {
        if (score < 0 || score > 100) return "Ошибка";
        if (score < 50) return "2";
        if (score < 70) return "3";
        if (score < 85) return "4";
        return "5";
    }
    static void TestInt(string name, int got, int expected)
    {
        total++;
        if (got == expected)
        {
            passed++;
            Console.WriteLine("OK     " + name);
        }
        else
            Console.WriteLine("ПРОВАЛ " + name + ": ожидалось "
                + expected + ", получено " + got);
    }

    static void TestStr(string name, string got, string expected)
    {
        total++;
        if (got == expected)
        {
            passed++;
            Console.WriteLine("OK     " + name);
        }
        else
            Console.WriteLine("ПРОВАЛ " + name + ": ожидалось \""
                + expected + "\", получено \"" + got + "\"");
    }
    public static void Main()
    {
        TestInt("3 кг, обычная", CalcDelivery(3, false), 250);
        TestInt("3 кг, экспресс", CalcDelivery(3, true), 500);
        TestInt("7 кг, обычная", CalcDelivery(7, false), 350);
        TestInt("7 кг, экспресс", CalcDelivery(7, true), 700);
        TestInt("25 кг, обычная", CalcDelivery(25, false), 570);
        TestInt("25 кг, экспресс", CalcDelivery(25, true), 1140);
        TestInt("Отрицательный вес", CalcDelivery(-3, false), -1);

        TestStr("Короткий", CheckPassword("a1b2c"), "Короткий пароль");
        TestStr("Нет цифры", CheckPassword("abcdefgh"), "Нет цифры");
        TestStr("Нет заглавной", CheckPassword("a1b2c3d4"), "Нет заглавной буквы");
        TestStr("OK", CheckPassword("a1b2cD3f"), "OK");

        TestStr("Ошибка (минус)", Grade(-5), "Ошибка");
        TestStr("Оценка 2", Grade(30), "2");
        TestStr("Оценка 3", Grade(60), "3");
        TestStr("Оценка 4", Grade(75), "4");
        TestStr("Оценка 5 (90)", Grade(90), "5");
        TestStr("Оценка 5 (85)", Grade(85), "5");

        TestInt("Гр. вес 0", CalcDelivery(0, false), -1);
        TestInt("Гр. вес 5", CalcDelivery(5, false), 250);
        TestInt("Гр. вес 6", CalcDelivery(6, false), 350);
        TestInt("Гр. вес 20", CalcDelivery(20, false), 350);
        TestInt("Гр. вес 21", CalcDelivery(21, false), 570);

        TestStr("Гр. балл 49", Grade(49), "2");
        TestStr("Гр. балл 50", Grade(50), "3");
        TestStr("Гр. балл 69", Grade(69), "3");
        TestStr("Гр. балл 70", Grade(70), "4");
        TestStr("Гр. балл 84", Grade(84), "4");
        TestStr("Гр. балл 85", Grade(85), "5");
        TestStr("Гр. балл 100", Grade(100), "5");
        TestStr("Гр. балл 101", Grade(101), "Ошибка");

        TestStr("Гр. пароль 7", CheckPassword("a1b2c3d"), "Короткий пароль");
        TestStr("Гр. пароль 8", CheckPassword("a1b2c3d4"), "Нет заглавной буквы");

        Console.WriteLine("=== ИТОГО: " + passed + " из " + total + " тестов пройдено ===");
    }
}