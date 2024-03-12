using System.Reflection.Metadata.Ecma335;

namespace Program_for_Notes
{
    internal class Program
    {
        static string[] menuOptions = { "New Note", "Edit Note", "See Notes" };
        static char[] PointerArray = new char[menuOptions.Length];
        static int menuSelection = 0;
        static void Main(string[] args)
        {
            //Variables
            for (int i = 0; i < PointerArray.Length; i++)
            {
                PointerArray[i] = ' ';
            }
            char Pointer = '>';
            bool isUsingMenu = true;
            PointerArray[0] = Pointer;

            //Program
            DisplayMenu();

            while (isUsingMenu == true)
            {
                ConsoleKeyInfo KeyData = GetKey();
                if (KeyData.Key.Equals(ConsoleKey.UpArrow) || KeyData.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (KeyData.Key.Equals(ConsoleKey.UpArrow))
                    {
                        PointerArray[menuSelection] = ' ';
                        menuSelection--;
                        if (menuSelection <= 0)
                        {
                            menuSelection = 0;
                        }
                        PointerArray[menuSelection] = Pointer;
                    }
                    if (KeyData.Key.Equals(ConsoleKey.DownArrow))
                    {
                        PointerArray[menuSelection] = ' ';
                        menuSelection++;
                        if (menuSelection >= 3)
                        {
                            menuSelection = menuOptions.Length - 1;
                        }
                        PointerArray[menuSelection] = Pointer;
                    }
                    DisplayMenu();
                }



            }
        }
        static void moveText(string textInput, int offset = 0)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(3, currentLineCursor + offset);
            Console.WriteLine(textInput);

        }

        static ConsoleKeyInfo GetKey()
        {
            ConsoleKeyInfo KeyData = Console.ReadKey(true);
            return KeyData;
        }

        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Programm for Notes\n");

            Console.WriteLine("{0} {1}", PointerArray[0], menuOptions[0]);
            Console.WriteLine("{0} {1}", PointerArray[1], menuOptions[1]);
            Console.WriteLine("{0} {1}", PointerArray[2], (menuOptions[2]));

            /*
            moveText(menuOptions[0], 1);
            moveText(menuOptions[1]);
            moveText(menuOptions[2]);
            */
        }

    }
}