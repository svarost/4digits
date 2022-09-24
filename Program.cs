// Main
int[] num = new int[4];
int[] hidden = ToArray(1234);
int count = 1;

Console.WriteLine("\t  Guess \t \t Resalt");

while(FindBull(num, hidden) != 4)
{
    Console.Write($"{count} \t");
    num = Promt(4);
    PrintResalt(num, hidden);
    count++;
}
Console.WriteLine("You Win!!!");


// Methods

int[] Promt(int count)
{
    while (true)
    {
        Console.Write(">> ");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            if (LengthNumber(value) == count && IsDifferentDigits(ToArray(value)))
                return ToArray(value);
        }
        Console.WriteLine("Введено некорректное значение, посторите ввод...");
        Console.Write("\t");
    }
}

int LengthNumber(int value)
{
    int len = 1;
    while (value > 10)
    {
        value /= 10;
        len++;
    }
    return len;
}

int[] ToArray(int number)
{
    int[] array = new int[LengthNumber(number)];
    for (int i = 0; i < array.Length - 1; i++)
    {
        array[i] = number % 10;
        number /= 10;
    }
    array[array.Length - 1] = number;
    return array;
}

bool IsDifferentDigits(int[] numbers)
{
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        for (int j = i + 1; j < numbers.Length; j++)
        {
            if (numbers[i] == numbers[j])
                return false;
        }
    }
    return true;
}

int FindBull(int[] number, int[] hidden)
{
    int count = 0;
    for (int i = 0; i < hidden.Length; i++)
    {
        if (number[i].Equals(hidden[i]))
            count++;
    }
    return count;
}

int FindCow(int[] number, int[] hidden)
{
    int count = 0;
    for (int i = 0; i < number.Length; i++)
    {
        foreach (var item in hidden)
        {
            if (number[i].Equals(item))
                count++;
        }
    }
    return count - FindBull(number, hidden);
}

void PrintResalt(int[] number, int[] hidden)
{
    Console.SetCursorPosition(34, Console.GetCursorPosition().Top - 1);
    Console.WriteLine($"{FindBull(number, hidden)}A{FindCow(number, hidden)}B");
}