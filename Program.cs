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
        for (int i = 1, c =3; i < 999; i *= 10, c--)
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
    for(int i = 0; i < Arr.Length; i++)
        Arr[i] = i+1;
    Console.WriteLine(string.Join(" ", Arr));  
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
                                "7"
                                };
string[] TaskName = new string[]{"Задача 19",
                                "Задача 21",
                                "Задача 23",
                                "Задача 1",
                                "Задача 2",
                                "Задача 3",
                                "Задача 4"
                                };
string[] TaskDescription = new string[]{"Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.",
                                       "Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.",
                                        "Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.",
                                        "Доп. задание: Рассчитать значение y при заданном x по формуле",
                                        "Доп. задание: Дано трёхзначное число N. Определить кратна ли трём сумма всех его цифр.",
                                        "Доп. задание: Дано трёхзначное число N. Определить, есть ли среди его цифр 4 или 7.",
                                        "Доп. задание: Дан массив длиной 10 элементов. Заполнить его последовательно числами от 1 до 10."
                                };
string[] TaskNote = new string[]{"Введите пятизначное число: ",
                                "Введите координаты двух точек в 3D пространстве в формате x1 y1 z1 x2 y2 z2: ",
                                "Введите число: ",
                                "Введите x: ",
                                "Введите трехзначное число : ",
                                "Введите трехзначное число : ",
                                "Enter для продолжения : "
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