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

//---------------------------------------------------------------------------------------------------------------------------
// переменные меню
string[] TaskKey = new string[]{"1",
                                "2",
                                "3"
                                };
string[] TaskName = new string[]{"Задача 19",
                                "Задача 21",
                                "Задача 23"
                                };
string[] TaskDescription = new string[]{"Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.",
                                       "Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.",
                                        "Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N."
                                };
string[] TaskNote = new string[]{"Введите пятизначное число:",
                                "Введите координаты двух точек в 3D пространстве в формате x1 y1 z1 x2 y2 z2:",
                                "Введите число:"
                                };

void TaskExecute(int ItemIndex, string[] Arguments)
{
    // Console.WriteLine("debag point 0"); // DEBAG
    switch (ItemIndex)
    {
        case 0:
            Task19(Convert.ToInt32(Arguments[0]));
            break;
        case 1:
            Task21(Convert.ToInt32(Arguments[0]),
                    Convert.ToInt32(Arguments[1]),
                    Convert.ToInt32(Arguments[2]),
                    Convert.ToInt32(Arguments[3]),
                    Convert.ToInt32(Arguments[4]),
                    Convert.ToInt32(Arguments[5]));
            break;
        case 2:
            Task23(Convert.ToInt32(Arguments[0]));
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
            Console.WriteLine("Выберите действие");
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