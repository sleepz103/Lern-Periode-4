using System.Reflection.Metadata.Ecma335;

namespace Program_for_Notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int menuSelection = 0;
            bool isUsingMenu = true;
            

            //Program
            Console.WriteLine("Programm for Notes");
            

            moveText("New Note",1);
            moveText("Edit Note");
            moveText("See Notes");

            
            while (isUsingMenu == true)
            {
                ConsoleKeyInfo KeyData = GetKey();
                if (KeyData.Key.Equals(ConsoleKey.UpArrow))
                {
                    menuSelection++;
                    Console.WriteLine("Input was Up Arrow "+menuSelection);
                }
                if (KeyData.Key.Equals(ConsoleKey.DownArrow))
                {
                    menuSelection--;
                    Console.WriteLine("Input was Down Arrow " + menuSelection);
                }
            }
            


            

        }
        static void moveText(string textInput, int offset = 0)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(3,currentLineCursor + offset);
            Console.WriteLine(textInput);

        }

        static ConsoleKeyInfo GetKey()
        {
            ConsoleKeyInfo KeyData = Console.ReadKey(true);
            return KeyData;
        }




    }
}