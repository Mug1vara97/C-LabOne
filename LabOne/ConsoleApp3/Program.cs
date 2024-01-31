using System;

/// <summary>
/// Класс Fraction представляет дробь с числителем и знаменателем.
/// </summary>
class Fraction
{
    private int numerator; // числитель
    private int denominator; // знаменатель

    /// <summary>
    /// Конструктор класса Fraction для инициализации дроби.
    /// Выдает исключение ArgumentException, если знаменатель равен нулю.
    /// </summary>
    /// <param name="numerator">числитель</param>
    /// <param name="denominator">знаменатель</param>
    /// <exception cref="ArgumentException"></exception>
    public Fraction(int numerator, int denominator) //инициализация дроби
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Знаменатель не может быть равен 0");
        }
        this.numerator = numerator; this.denominator = denominator;
    }
    /// <summary>
    /// Получает или устанавливает числитель дроби.
    /// </summary>
    public int Numerator //получение и установка числителя
    {
        get { return numerator; }
        set { numerator = value;}
    }

    /// <summary>
    /// Получает или устанавливает знаменатель дроби.
    /// Выдает исключение ArgumentException, если знаменатель равен нулю
    /// </summary>
    public int Denominator    //получение и установка знаменателя
    {
        get { return denominator; }        
        set 
        {            
            if (value == 0)
            {                
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            denominator = value;        
        }
    }
    /// <summary>
    /// Свойство для получения представления дроби в виде числа с плавающей точкой.
    /// </summary>
    public double DecimalValue //представление дроби
    {
        get 
        { 
            return (double)numerator / denominator; 
        }    
    }
    /// <summary>
    /// Метод для сложения двух дробей.
    /// </summary>
    /// <param name="fraction">Дробь, которую нужно сложить с текущей дробью</param>
    /// <returns>Результат сложения двух дробей</returns>
    public Fraction Add(Fraction fraction) //сложение
{
    int newNumerator = (numerator * fraction.denominator) + (fraction.numerator * denominator);
    int newDenominator = denominator * fraction.denominator;
    return Simplify(new Fraction(newNumerator, newDenominator));
}
    /// <summary>
    ///  Метод для вычитания двух дробей.
    /// </summary>
    /// <param name="fraction">Дробь, которую нужно вычесть из текущей дроби</param>
    /// <returns>Результат вычитания двух дробей</returns>
    public Fraction Subtract(Fraction fraction) //вычитание
{
    int newNumerator = (numerator * fraction.denominator) - (fraction.numerator * denominator);
    int newDenominator = denominator * fraction.denominator;
    return Simplify(new Fraction(newNumerator, newDenominator));
}
    /// <summary>
    /// Метод для умножения двух дробей.
    /// </summary>
    /// <param name="fraction">Дробь, на которую нужно умножить текущую дробь</param>
    /// <returns>Результат умножения двух дробей</returns>
    public Fraction Multiply(Fraction fraction) //умножение
{
    int newNumerator = numerator * fraction.numerator;
    int newDenominator = denominator * fraction.denominator;
    return Simplify(new Fraction(newNumerator, newDenominator));
}
    /// <summary>
    /// Выполняет деление дробей
    /// </summary>
    /// <param name="fraction">Дробь, на которую нужно разделить текущую дробь</param>
    /// <returns>Результат деления двух дробей</returns>
    public Fraction Divide(Fraction fraction) //деление
{
    int newNumerator = numerator * fraction.denominator;
    int newDenominator = denominator * fraction.numerator;
    return Simplify(new Fraction(newNumerator, newDenominator));
}
    /// <summary>
    /// Метод для упращения дробей
    /// </summary>
    /// <param name="fraction">Дробь, которую нужно упростить</param>
    /// <returns>Упрощенная дробь</returns>
    private Fraction Simplify(Fraction fraction) //упрощение дроби 
{
    int gcd = GCD(fraction.numerator, fraction.denominator); //gcd-greatest common divisor(наибольший общий делитель(НОД))
    fraction.numerator /= gcd;
    fraction.denominator /= gcd;
        
    return fraction;
}
    /// <summary>
    /// Метод для нахождения наибольшего общего делителя НОД(GCD)
    /// </summary>
    /// <param name="a">числитель</param>
    /// <param name="b">знаменатель</param>
    /// <returns>Наибольший общий делитель</returns>
    private int GCD(int a, int b) //Алгоритм Евклида, нахождение gcd(нод)
{
    while (b != 0)
    {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите числитель 1 дроби: ");
        int numerator1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите знаменатель 1 дроби: "); int denominator1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите числитель 2 дроби: ");
        int numerator2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите знаменатель 2 дроби: "); int denominator2 = Convert.ToInt32(Console.ReadLine());
        try
        {
            Fraction fraction1 = new Fraction(numerator1, denominator1);
            Fraction fraction2 = new Fraction(numerator2, denominator2);
            Console.WriteLine("Первая дробь: {0}/{1}" + Environment.NewLine + "В виде числа: {2}", fraction1.Numerator, fraction1.Denominator, fraction1.DecimalValue); Console.WriteLine("Вторая дробь: {0}/{1} " + Environment.NewLine + "В виде числа: {2}", fraction2.Numerator, fraction2.Denominator, fraction2.DecimalValue);
            Fraction result = fraction1.Add(fraction2);
            Console.WriteLine("Сумма: {0}/{1}" + Environment.NewLine + "В виде числа: {2}", result.Numerator, result.Denominator, result.DecimalValue);
            result = fraction1.Subtract(fraction2); Console.WriteLine("Разность: {0}/{1}" + Environment.NewLine + "В виде числа: {2}", result.Numerator, result.Denominator, result.DecimalValue);
            result = fraction1.Multiply(fraction2);
            Console.WriteLine("Умножение: {0}/{1}" + Environment.NewLine + "В виде числа: {2}", result.Numerator, result.Denominator, result.DecimalValue);
            result = fraction1.Divide(fraction2); Console.WriteLine("Деление: {0}/{1}" + Environment.NewLine + "В виде числа: {2}", result.Numerator, result.Denominator, result.DecimalValue);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        Console.ReadLine();
    }
}