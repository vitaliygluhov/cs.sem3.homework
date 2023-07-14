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
//------------------------------------------------------------------------------------------------------------------
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
        Console.Write($"{i} ^ 3 = {(Math.Pow(i, 3))} /r/n");

    }
}

//---------------------------------------------------------------------------------------------------------------------------
//              ДОПОЛНИТЕЛЬНЫЕ ЗАДАНИЯ
// Задача 1. Рассчитать значение y при заданном x по формуле
void AddTask1(double x)
{
    double y;
    if (x > 0)
        y = Math.Pow(Math.Sin(x), 2);
    else y = 1 - 2 * Math.Sin(Math.Pow(x, 2));
    Console.WriteLine($"При x = {x} по заданной формуле y = {y}");
}
// Задача 2. Дано трёхзначное число N. Определить кратна ли трём сумма всех его цифр.
void AddTask2(int InputNumber)
{
    if (InputNumber < 1000 && InputNumber > 99)
    {
        int Sum = 0;
        for (int i = 1; i < 999; i *= 10)
            Sum += InputNumber / i % 10;
        if (Sum % 3 == 0)
            Console.WriteLine($"Сумма цифр числа {InputNumber} равна {Sum} и кратна трем.");
        else Console.WriteLine($"Сумма цифр числа {InputNumber} равна {Sum} и НЕ кратна трем.");
    }
    else Console.WriteLine($"Число {InputNumber} не соответствует заданным критериям.");
}
// Задача 3. Дано трёхзначное число N. Определить, есть ли среди его цифр 4 или 7.
void AddTask3(int InputNumber)
{
    Console.WriteLine($"Вариант исполнения I");
    if (InputNumber < 1000 && InputNumber > 99)
    {
        bool tmp = false;
        for (int i = 1; i < 999 && !tmp; i *= 10)
            if (InputNumber / i % 10 == 4 || InputNumber / i % 10 == 7)
                tmp = true;
        if (tmp)
            Console.WriteLine($"Число {InputNumber} содержит в себе цифру 4 или 7");
        else Console.WriteLine($"Число {InputNumber} НЕ содержит в себе цифру 4 или 7");
    }
    else Console.WriteLine($"Число {InputNumber} не соответствует заданным критериям.");
    Console.WriteLine($"\r\nВариант исполнения II");
    if (InputNumber < 1000 && InputNumber > 99)
    {
        Console.WriteLine($"Число {InputNumber} содержит в себе цифры: ");
        for (int i = 1, c = 3; i < 999; i *= 10, c--)
        {
            if (InputNumber / i % 10 == 4)
                Console.WriteLine($"4 в позиции {c}");
            if (InputNumber / i % 10 == 7)
                Console.WriteLine($"7 в позиции {c}");
        }
    }
    else Console.WriteLine($"Число {InputNumber} не соответствует заданным критериям.");
}
// Задача 4. Дан массив длиной 10 элементов. Заполнить его последовательно числами от 1 до 10.
void AddTask4()
{
    int[] Arr = new int[10];
    for (int i = 0; i < Arr.Length; i++)
        Arr[i] = i + 1;
    Console.WriteLine(string.Join(" ", Arr));
}

//---------------------------------------------------------------------------------------------------------------------------
//              ЗАДАНИЯ ПОВЫШЕННОЙ СЛОЖНОСТИ

//Задача 1. На ввод подаётся номер четверти. Создаются 3 случайные точки в этой четверти. Определите самый оптимальный маршрут для торгового менеджера, который выезжает из центра координат.
void AddDiffTask1(int Quarter)//Решение нменя не удовлетворило. есть изъяны. Маршрут не всегда самый короткий. Не учитывается расстояние на возврат. Принцип основан на приоритете перехода в узел по наименьшему весу ребра.
{
    int NodeAmount = 4; // количество узлов

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
        //Console.Write($"Canvas->LineTo({NodeX[MinWeightIndex]},{NodeY[MinWeightIndex]});\r\n"); для визуализации в C++ Builder
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


}
// Задача 5. На вход подаётся число n > 4, указывающее длину пароля. Создайте метод, 
// генерирующий пароль заданной длины. В пароле обязательно использовать цифру, букву и специальный знак.
void AddDiffTask5(int PassLength)
{
    if (PassLength < 4) PassLength = 4;
    // var 1
    Console.WriteLine($"\r\n\tВариант исполнения I \r\nИмеет шанс несоблюдения всех условий");
    string Chars = "1234567890AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz!?@#$%^&*()";
    Random Rnd = new Random();
    string Password = "";
    for (int i = 0; i < PassLength; i++)
        Password += Chars.Substring(Rnd.Next(0, Chars.Length), 1);
    Console.WriteLine($"Сгенерирован пароль длинною {PassLength} символов: {Password}");
    Password = "";
    // var 1
    Console.WriteLine($"\r\n\tВариант исполнения II\r\nГарантировано соответствует всем условиям");
    string[] CharsLettL ={
         "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
    string[] CharsLettU ={
        "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    string[] CharNum ={
        "1","2","3","4","5","6","7","8","9","0"};
    string[] CharSymb ={
        "!","?","@","#","$","%","^","&","*","(",")","+","-","_","="};
    string[] TempPassword = new string[PassLength];
    //выполнение обязательных условий
    TempPassword[0] = CharsLettL[Rnd.Next(0, CharsLettL.Length)];
    TempPassword[1] = CharsLettU[Rnd.Next(0, CharsLettU.Length)];
    TempPassword[2] = CharNum[Rnd.Next(0, CharNum.Length)];
    TempPassword[3] = CharSymb[Rnd.Next(0, CharSymb.Length)];

    for (int i = 4; i < PassLength; i++)
    {
        switch (Rnd.Next(4))
        {
            case 0:
                TempPassword[i] = CharsLettL[Rnd.Next(0, CharsLettL.Length)];
                break;
            case 1:
                TempPassword[i] = CharsLettU[Rnd.Next(0, CharsLettL.Length)];
                break;
            case 2:
                TempPassword[i] = CharNum[Rnd.Next(0, CharNum.Length)];
                break;
            case 3:
                TempPassword[i] = CharSymb[Rnd.Next(0, CharSymb.Length)];
                break;
        }

    }
    // перемешаем для большей непредсказуемости
    for (int i = 0, rand; i < TempPassword.Length;)
    {
        rand = Rnd.Next(TempPassword.Length);
        if (TempPassword[rand] != "")
        {
            Password += TempPassword[rand];
            TempPassword[rand] = "";
            i++;
        }
    }
    Console.WriteLine($"Сгенерирован пароль длинною {PassLength} символов: {Password}");
}
//Задача 7. Массив из ста элементов заполняется случайными числами от 1 до 100. Удалить из массива все элементы, содержащие цифру 3. Вывести в консоль новый массив и количество удалённых элементов.
void AddDiffTask7()
{
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

    Console.WriteLine("Оригинальный массив: ");
    Console.WriteLine(string.Join(" ", Arr));
    Console.WriteLine("Новый массив: ");
    Console.WriteLine(string.Join(" ", ArrOut));
    Console.WriteLine($"\r\n\r\nУдалено троек: {DelCount}");
    Console.WriteLine($"Новая длина массива: {ArrOut.Length}");
}
//Задача 8. Напишите программу, который выводит на консоль таблицу умножения от 1 до n, 
//          где n задаётся случайно от 2 до 100.
void AddDiffTask8()
{
    Random Rnd = new Random();
    int n = Rnd.Next(2,101);
    for(int i = 1; i<=n; i++)
    {
        for(int j = 1; j<=10; j++)
        {
            Console.WriteLine($"{i} * {j} = {i*j}");
        }
        Console.WriteLine();
    }
    Console.WriteLine($"Случайное число - {n}");
}

//---------------------------------------------------------------------------------------------------------------------------
//                   МЕНЮ
// переменные меню
string[] TaskKey = new string[]{"1",
                                "2",
                                "3",
                                "4",
                                "5",
                                "6",
                                "7",
                                "8",
                                "9",
                                "10",
                                "11",
                                "12",
                                "13",
                                "14",
                                "15",
                                "16"
                                };
string[] TaskName = new string[]{"Задача 19",
                                "Задача 21",
                                "Задача 23",
                                "Задача 1",
                                "Задача 2",
                                "Задача 3",
                                "Задача 4",
                                "Задача пов.cлож. 1",
                                "Задача пов.cлож. 2",
                                "Задача пов.cлож. 3",
                                "Задача пов.cлож. 4",
                                "Задача пов.cлож. 5",
                                "Задача пов.cлож. 6",
                                "Задача пов.cлож. 7",
                                "Задача пов.cлож. 8",
                                "Задача пов.cлож. 9"
                                };
string[] TaskDescription = new string[]{"Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.",
                                       "Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.",
                                        "Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.",
                                        "Доп. задание: Рассчитать значение y при заданном x по формуле",
                                        "Доп. задание: Дано трёхзначное число N. Определить кратна ли трём сумма всех его цифр.",
                                        "Доп. задание: Дано трёхзначное число N. Определить, есть ли среди его цифр 4 или 7.",
                                        "Доп. задание: Дан массив длиной 10 элементов. Заполнить его последовательно числами от 1 до 10.",
                                        "На ввод подаётся номер четверти. Создаются 3 случайные точки в этой четверти. Определите самый оптимальный маршрут для торгового менеджера, который выезжает из центра координат.",
                                        "\t\tЕЩЕ НЕ РЕШЕНА",
                                        "\t\tЕЩЕ НЕ РЕШЕНА",
                                        "\t\tЕЩЕ НЕ РЕШЕНА",
                                        "На вход подаётся число n > 4, указывающее длину пароля. Создайте метод, генерирующий пароль заданной длины. В пароле обязательно использовать цифру, букву и специальный знак.",
                                        "\t\tЕЩЕ НЕ РЕШЕНА",
                                        "Массив из ста элементов заполняется случайными числами от 1 до 100. Удалить из массива все элементы, содержащие цифру 3. Вывести в консоль новый массив и количество удалённых элементов.",
                                        "Напишите программу, который выводит на консоль таблицу умножения от 1 до n, где n задаётся случайно от 2 до 100.",
                                        "\t\tЕЩЕ НЕ РЕШЕНА"
                                };
string[] TaskNote = new string[]{"Введите пятизначное число: ",
                                "Введите координаты двух точек в 3D пространстве в формате x1 y1 z1 x2 y2 z2: ",
                                "Введите число: ",
                                "Введите x: ",
                                "Введите трехзначное число: ",
                                "Введите трехзначное число: ",
                                "Enter для продолжения: ",
                                "Введите номер четверти (1-4): ",
                                "Press Enter> ",
                                "Press Enter> ",
                                "Press Enter> ",
                                "Введите число больше 4: ",
                                "Press Enter> ",
                                "Enter для продолжения: ",
                                "Enter для продолжения: ",
                                "Press Enter> "
                                };

void TaskExecute(int ItemIndex, string[] Arguments)
{
    // Console.WriteLine("debag point 0"); // DEBAG
    switch (ItemIndex + 1)
    {
        case 1:
            Task19(Convert.ToInt32(Arguments[0]));
            break;
        case 2:
            Task21(Convert.ToInt32(Arguments[0]),
                    Convert.ToInt32(Arguments[1]),
                    Convert.ToInt32(Arguments[2]),
                    Convert.ToInt32(Arguments[3]),
                    Convert.ToInt32(Arguments[4]),
                    Convert.ToInt32(Arguments[5]));
            break;
        case 3:
            Task23(Convert.ToInt32(Arguments[0]));
            break;
        case 4:
            AddTask1(Convert.ToDouble(Arguments[0]));
            break;
        case 5:
            AddTask2(Convert.ToInt32(Arguments[0]));
            break;
        case 6:
            AddTask3(Convert.ToInt32(Arguments[0]));
            break;
        case 7:
            AddTask4();
            break;
        case 8:
            AddDiffTask1(Convert.ToInt32(Arguments[0]));
            break;
        case 9:
            //AddDiffTask2();
            break;
        case 10:
            //AddDiffTask3();
            break;
        case 11:
            //AddDiffTask4();
            break;
        case 12:
            AddDiffTask5(Convert.ToInt32(Arguments[0]));
            break;
        case 13:
            //AddDiffTask6();
            break;
        case 14:
            AddDiffTask7();
            break;
        case 15:
            AddDiffTask8();
            break;
        case 16:
            //AddDiffTask9();
            break;

    }
}




// методы оболочки
void MenuItem(string Key, string InemName, string InemDescription)// вывод элементов меню
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(Key);
    Console.ResetColor();
    Console.WriteLine($" - {InemName}: {InemDescription}");
}
void MenuSysItem(string Key, string InemName) // вывод системных пунктов  меню
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(Key);
    Console.ResetColor();
    Console.WriteLine($" - {InemName}");
}
void ShowMainMenu() // отрисовка меню
{
    Console.Clear();
    for (int i = 0; i < TaskKey.Length; i++)
    {
        MenuItem(TaskKey[i], TaskName[i], TaskDescription[i]);
    }
    MenuSysItem("q", "Выход из программы");
    Console.Write("Введите выбраный пункт меню: ");
}

// сообщения
void ShowErrorMsg(string msg)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(msg);
    Console.ResetColor();
}

// отрисовка заданий 
void ShowTask(int ItemIndex)
{

    bool TaskActive = true; // Состояние задачи. если true, значит активна, и будет выполнятся пока состояние не изменится на false
    while (TaskActive) // повторяет задание пока  пользователь выбирает повторить
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(TaskName[ItemIndex]);
        Console.ResetColor();
        Console.WriteLine(TaskDescription[ItemIndex]);
        Console.Write(TaskNote[ItemIndex]);

        string InputText = Console.ReadLine(); // ввод пользовательских данных
        string[] InputWords = InputText.Split(" "); // парсинг введенного текста. раскладываем строку на слова
        TaskExecute(ItemIndex, InputWords);// вызывается выполнение задачи
        //tmp


        // Exit Dialog
        bool ExitDialogActive = true;
        while (ExitDialogActive) // удерживает пользователя в меню выхода пока не будет выбран один из предусмотренных пунктов.
        {
            Console.WriteLine("\r\nВыберите действие");
            MenuSysItem("r", "Повторить выполнение задания");
            MenuSysItem("m", "Вернуться в главное меню");
            MenuSysItem("q", "Завершить программу");
            Console.Write("Введите выбраный пункт: ");

            string SlectItem = Console.ReadLine().ToLower();
            if (SlectItem == "r")
            {
                TaskActive = true;
                ExitDialogActive = false;
            }
            else if (SlectItem == "m")
            {
                TaskActive = false;
                ExitDialogActive = false;
                ShowMainMenu();
            }
            else if (SlectItem == "q")
            {
                Console.Clear();
                System.Environment.Exit(0);
            }
        }
    }

}
//======================================================================================================================
ShowMainMenu(); // выводим главное меню
while (true) // выполняется пока пользователь не завершит программу 
{
    string SlectItem = Console.ReadLine(); // обработка выбора меню
    SlectItem = SlectItem.ToLower();

    if (SlectItem != "q")
    {
        int SlectItemInt; //проверка  - является ли введенное значение числом
        if (int.TryParse(SlectItem, out SlectItemInt) == true && SlectItemInt <= TaskKey.Length && SlectItemInt > 0)
        {
            ShowTask(SlectItemInt - 1); // вызываем страницу задания
        }
        else
        {
            ShowErrorMsg("Введен неверный пункт меню. попробуйте еще раз: ");
        }
    }
    else
    {
        Console.Clear();
        System.Environment.Exit(0);
    }
}