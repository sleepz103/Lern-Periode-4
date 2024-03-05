namespace Program_for_Notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programm for Notes");


            moveText("New Note",1);
            moveText("Edit Note");
            moveText("See Notes");

            /*
            Console.WriteLine("\nNew Note");
            Console.WriteLine("Edit Note");
            Console.WriteLine("See Notes");
            */
        }
        static void moveText(string textInput, int offset = 0)
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(3,currentLineCursor + offset);
            Console.WriteLine(textInput);

        }
    }
}