using System;

class Program
{
    int[][] white = new int[][]
    {
        // белые клавиши
        new int[] {262, 294, 330, 349, 392, 440, 494, 523, 587, 659}, // 4 октава
        new int[] {523, 587, 659, 698, 784, 880, 988, 1046, 1175, 1319}, // 5 октава
        new int[] {1046, 1175, 1319, 1397, 1568, 1760, 1976, 2093, 2349, 2637} // 6 октава
    };

    int[][] black = new int[][]
    {
        // черные клавиши
        new int[] {277, 311, 370, 415, 466},
        new int[] {554, 622, 740, 831, 932},
        new int[] {1109, 1245, 1480, 1661, 1865}
    };
    // хранение текущей октавы
    int Octave = 0;

    static void Main()
    {
        var program = new Program();
        program.Menu();
    }

    void Menu()
    {
        bool run = true;
        while (run)
        {
            Console.WriteLine("Менюшка:");
            Console.WriteLine("1 - Начать играть на пианино");
            Console.WriteLine("2 - Выйти");
            Console.Write("Выберите опцию:");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    start();
                    break;
                case "2":
                    run = false;
                    break;
                default:
                    Console.WriteLine("Неизвестная опция. Не получилось не фортануло.");
                    break;
            }
        }
    }

    void start()
    {
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                return;
            }
            else if (keyInfo.Key >= ConsoleKey.F1 && keyInfo.Key <= ConsoleKey.F3)
            {
                SwitchO(keyInfo.Key - ConsoleKey.F1);
            }
            else if (keyInfo.Key >= ConsoleKey.A && keyInfo.Key <= ConsoleKey.L)
            {
                int frequency = white[Octave][keyInfo.Key - ConsoleKey.A];
                Sound(frequency, 300);
            }
            else if (keyInfo.Key >= ConsoleKey.Q && keyInfo.Key <= ConsoleKey.T)
            {
                int frequency = black[Octave][keyInfo.Key - ConsoleKey.Q];
                Sound(frequency, 300);
            }
        }
    }
    // переключение октав
    void SwitchO(int octave)
    {
        if (octave >= 0 && octave < white.Length)
        {
            Octave = octave;
            Console.WriteLine($"Переключено на октаву {Octave + 4}");
            // пишет какая октава была выбрана
        }
        else
        {
            Console.WriteLine($"Октава {octave + 4} не доступна");
            // пишет если нету такой октавы
        }
    }

    void Sound(int frequency, int duration)
    {
        if (frequency < 37 || frequency > 32767)
        {
            Console.WriteLine($"Невозможно воспроизвести звук на частоте {frequency} Гц. Допустимый диапазон: от 37 до 32767 Гц.");
            return;
        }
        // звук
        Console.Beep(frequency, duration);
    }
}