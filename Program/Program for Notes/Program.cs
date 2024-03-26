using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Program_for_Notes
{
    internal class Program
    {
        static string roamingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string[] menuOptions = { "New Note", "Edit Note", "See Notes" };
        static char[] PointerArray = new char[menuOptions.Length];
        static int menuSelection = 0;
        static void Main(string[] args)
        {
            CreatingDirectory(roamingDirectory);
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
                else if(KeyData.Key.Equals(ConsoleKey.Enter))
                {
                    switch(menuSelection)
                    {
                        case 0:
                            isUsingMenu = false;
                            NewNote();
                            break;
                        case 1:
                            isUsingMenu = false;
                            EditNote();
                            break;
                        case 2:
                            isUsingMenu = false;
                            ListNotes();
                            break;

                    }
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

        static void NewNote()
        {
            string title;
            string noteContent;
            

            
            Console.Clear();
            Console.Write("Title: ");
            int XCursorPos1 = Console.CursorLeft;
            int YCursorPos1 = Console.CursorTop;
            Console.WriteLine("\n----------------------");
            int XCursorPos2 = Console.CursorLeft;
            int YCursorPos2 = Console.CursorTop;

            Console.SetCursorPosition(XCursorPos1,YCursorPos1);
            title = Console.ReadLine();
            Console.SetCursorPosition(XCursorPos2, YCursorPos2);
            noteContent = Console.ReadLine();

            string filePath = roamingDirectory +"/" + "YourNotesWithCSharp" + "/" + title +".txt";
            File.WriteAllText(filePath, noteContent);


        }

        static void EditNote()
        {
            Console.WriteLine("Test Function");
        }
        static void ListNotes()
        {
            Console.WriteLine("Test Function");
        }

        static void CreatingDirectory(string roamingDirectory)
        {
            string folder = Path.Combine(roamingDirectory, "YourNotesWithCSharp");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public class NoteData
        {
            public string title;
            public string content;
        }

    }
}