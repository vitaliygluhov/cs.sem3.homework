int[] Input(string Mssg)
{
    Console.Write(Mssg + ">");
    string InputText = Console.ReadLine(); // ввод пользовательских данных
    string[] InputWords = InputText.Split(" "); // парсинг введенного текста. раскладываем строку на слова
    int[] arr = new int[InputWords.Length];
    for (int i = 0; i < InputWords.Length; i++)
        int.TryParse(InputWords[i], out arr[i]);
    return arr;
}

//              ОСНОВНЫЕ ЗАДАНИЯ 
//Задача 19 Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
void Task19(int InputNumber)
{
    int InvertNumber = 0;
    for (int TempNumber = InputNumber; TempNumber > 0; TempNumber /= 10)
        InvertNumber = InvertNumber * 10 + TempNumber % 10;
    if (InvertNumber == InputNumber)
        Console.WriteLine($"Введено число {InputNumber} является палиндромом.");
    else Console.WriteLine($"Введено число {InputNumber} НЕ является палиндромом.");
}
//Задача 21 Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
void Task21(int x1, int y1, int z1, int x2, int y2, int z2)
{
    Console.WriteLine(Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2)), 2));
}
// Задача 23 Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
void Task23(int Num)
{

    Console.Clear();
    for (int i = 1; i <= Num; i++)
    {
        Console.Write($"{i} ^ 3 = ");
        Console.WriteLine((Math.Pow(i, 3)));
    }
}
//              ДОПОЛНИТЕЛЬНЫЕ ЗАДАНИЯ

//              ЗАДАНИЯ ПОВЫШЕННОЙ СЛОЖНОСТИ

//Задача 1. На ввод подаётся номер четверти. Создаются 3 случайные точки в этой четверти. Определите самый оптимальный маршрут для торгового менеджера, который выезжает из центра координат.
void AddDiffTask1(int Quarter)
{
    int NodeAmount = 8; // количество узлов

    int[] NodeX = new int[NodeAmount];
    int[] NodeY = new int[NodeAmount];
    bool[] NodeFlag = new bool[NodeAmount]; //флаг посищения

    int CurNode = 0; // текущая нода

    double[,] Graph = new double[NodeAmount, NodeAmount];

    double Way = 0; // весь путь
    int StepCount = 0;

    Random rnd = new Random();
    int xr = 0;
    int yr = 0;
    switch (Quarter)
    {
        case 1:
            xr = 0;
            yr = 0;
            break;
        case 2:
            xr = 0;
            yr = 100;
            break;
        case 3:
            xr = 100;
            yr = 100;
            break;
        case 4:
            xr = 100;
            yr = 0;
            break;
    }


    for (int i = 1; i < NodeAmount; i++)
    {
        //ген. коорд.

        NodeX[i] = rnd.Next(0 - xr, 100 - xr);
        NodeY[i] = rnd.Next(0 - yr, 100 - yr);
    }
    double MaxWeight = 0;
    for (int i = 0; i < NodeAmount; i++) // создаем таблицу весов ребер
        for (int j = 0; j < NodeAmount; j++)
        {
            Graph[i, j] = Math.Round(Math.Sqrt(Math.Pow(NodeX[j] - NodeX[i], 2) + Math.Pow(NodeY[j] - NodeY[i], 2)), 2);
            if (MaxWeight < Graph[i, j])
                MaxWeight = Graph[i, j];
        }


    // начинаем движение (не забыть заключить в цикл)
    while (StepCount < NodeAmount - 1)
    {
        double MinWeight = 0; // минимальный вес соседней
        int MinWeightIndex = 0; // индекс нода сминимальным значением
        NodeFlag[CurNode] = true;
        MinWeight = 100000000; //Graph[CurNode, NodeAmount - 1];
        for (int i = 0; i < NodeAmount; i++)// ищем ближайшую от текущей
        {
            if (CurNode != i && !NodeFlag[i] && Graph[CurNode, i] < MinWeight) // не сравнивается с собой && не посищалась && текущий легче сохраненного
            {
                MinWeight = Graph[CurNode, i];  // адрес ноды с минимальным значением
                MinWeightIndex = i; // адрес ноды с минимальным значением
            }
        }
        StepCount++;
        Way += MinWeight;
        Console.Write($"//Шаг {StepCount}. Переход от ноды {CurNode} к ноде {MinWeightIndex} на расстоянии {MinWeight}. Общий путь: {Way}\r\n");
        Console.Write($"Canvas->LineTo({NodeX[MinWeightIndex]},{NodeY[MinWeightIndex]});\r\n");
        CurNode = MinWeightIndex;
    }



    //Report
    Console.WriteLine($"Вусь путь пройден за {Way}\r\n");
    Console.WriteLine("    Таблица веса ребер");
    Console.WriteLine("\t0\t1\t2\t3");
    Console.WriteLine("\t______________________________________");
    for (int Y = 0; Y < NodeAmount; Y++)
    {
        Console.Write(Y + " |");
        for (int X = 0; X < NodeAmount; X++)
        {
            if (Graph[X, Y] >= 100)
                Console.Write($"\t{Graph[X, Y]}");
            else if (Graph[X, Y] >= 10 && (Graph[X, Y] < 100))
                Console.Write($"\t{Graph[X, Y]}");
            else Console.Write($"\t{Graph[X, Y]}");
        }
        Console.WriteLine("");
    }
    Console.WriteLine("");
    for (int i = 0; i < NodeAmount; i++)
        Console.WriteLine($"{i} нода: {NodeX[i]} x {NodeY[i]}");
// Var 2 перебор всех комбинаций
//CurNode = 0; // текущая нода
//Way = 0; // весь путь
//StepCount = 0;

}


void AddDiffTask2()
{
    //
}

void AddDiffTask3()
{
    //
}
// Задача 4. Дан массив средних температур (массив заполняется случайно) за последние 10 лет. На ввод подают номер месяца и год начали и конца.
void AddDiffTask4()
{
    //for(int i = 0;)
}
// Задача 5. На вход подаётся число n > 4, указывающее длину пароля. Создайте метод, 
// генерирующий пароль заданной длины. В пароле обязательно использовать цифру, букву и специальный знак.
void AddDiffTask5(int Length)
{
    // var 1
    string Characters = "1234567890AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz!?@#$%^&*()";
    Random Rnd = new Random();
    string Password = "";
    for (int i = 0; i < Length; i++)
    {
        Password += Characters.Substring(Rnd.Next(0, Characters.Length), 1);
    }
    Console.WriteLine($"Сгенерирован пароль длинною {Length} символов: {Password}");
}

void AddDiffTask6()
{
    //
}
//Задача 7. Массив из ста элементов заполняется случайными числами от 1 до 100. Удалить из массива все элементы, содержащие цифру 3. Вывести в консоль новый массив и количество удалённых элементов.
void AddDiffTask7()
{
    // Вариант с удалением значения в массиве
    /*
    int[] Arr = new int[100];
    int[] ArrOut = new int[100];
    Random Rnd = new Random();
    for (int i = 0; i < Arr.Length; i++)
        Arr[i] = Rnd.Next(1, 100);
    int DelCount = 0;
    for (int i = 0; i < Arr.Length; i++)
    {
        if (Arr[i] != 3)
            ArrOut[i] = Arr[i];
        else DelCount++;
    }

    for (int i = 0; i < ArrOut.Length; i++)
        Console.Write($"{ArrOut[i]} ");
    Console.WriteLine($"\r\n Удалено троек: {DelCount}");
    */
    // Вариант с удалением элемента массива (уменьшение размера массива)
    int[] Arr = new int[100];

    int TCount = 0;
    Random Rnd = new Random();
    for (int i = 0; i < Arr.Length; i++)
    {
        Arr[i] = Rnd.Next(1, 100);
        if (Arr[i] == 3)
            TCount++;
    }
    int[] ArrOut = new int[Arr.Length - TCount];
    int DelCount = 0;
    for (int i = 0, j = 0; i < Arr.Length; i++)
    {
        if (Arr[i] != 3)
        {
            ArrOut[j] = Arr[i];
            j++;
        }
        else DelCount++;
    }

    for (int i = 0; i < ArrOut.Length; i++)
        Console.Write($"{ArrOut[i]} ");
    Console.WriteLine($"\r\n\r\nУдалено троек: {DelCount}");
    Console.WriteLine($"Новая длина массива: {ArrOut.Length}");
}
Console.Clear();

void AddDiffTask8()
{
    //
}

void AddDiffTask9()
{
    //
}



//Task19(123454321);
//Task21(10, 20, 30, 40, 50, 60);
//Task23(23);
//AddDiffTask5(20);
//AddDiffTask7();
AddDiffTask1(1);
