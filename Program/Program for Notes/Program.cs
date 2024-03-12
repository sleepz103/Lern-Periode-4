using System.Reflection.Metadata.Ecma335;

namespace Program_for_Notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int menuSelection = 0;
            
            //Program
            Console.WriteLine("Programm for Notes");
            

            moveText("New Note",1);
            moveText("Edit Note");
            moveText("See Notes");

            GetKey();
            
            


            

        }
        static void moveText(string textInput, int offset = 0)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(3,currentLineCursor + offset);
            Console.WriteLine(textInput);

        }

        static void GetKey()
        {
            System.ConsoleKey DownArrow = ConsoleKey.DownArrow;
            System.ConsoleKey UpArrow = ConsoleKey.UpArrow;

            ConsoleKeyInfo KeyData = Console.ReadKey(true);
            if(KeyData.Key.Equals(UpArrow))
            {
                Console.WriteLine("Input was Up Arrow");
            }
            if (KeyData.Key.Equals(DownArrow))
            {
                Console.WriteLine("Input was Down Arrow");
            }

        }




    }
}