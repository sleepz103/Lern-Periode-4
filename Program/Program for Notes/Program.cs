using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Program_for_Notes
{
    internal class Program
    {
        static string roamingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string[] menuOptions = { "New Note", "Tagged Notes", "See Notes" };
        static char[] PointerArray = new char[menuOptions.Length];

        //get names of the files into Array
        static string folder = Path.Combine(roamingDirectory, "YourNotesWithCSharp");
        static string[] filesArray = Directory.GetFiles(folder);
        //create i-PointerArray
        static char[] PointerArrayI = new char[filesArray.Length];
        static char PointerI = '>';
        static int menuSelectionI = 0;
        static int menuSelection = 0;

        static string[] noteTags = { "School", "Food", "1" };
        static char[] PointerArrayII = new char[noteTags.Length];
        static char PointerII = '>';
        static int menuSelectionII = 0;
        static void Main()
        {
            CreatingDirectory(roamingDirectory);

            //Variables
            for (int i = 0; i < PointerArray.Length; i++)
            {
                PointerArray[i] = ' ';
            }
            char Pointer = '>';
            bool isUsingMenu = true;
            PointerArray[menuSelection] = Pointer;

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
                            TaggedNotes();
                            break;
                        case 2:
                            isUsingMenu = false;
                            ListNotes();
                            break;

                    }
                }
            }
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
            Console.WriteLine("{0} {1}", PointerArray[2], menuOptions[2]);

        }

        static void NewNote()
        {
            string noteTitle;
            string noteTag;
            string noteContent;

            Console.Clear();
            Console.Write("Title: ");
            int XCursorPos1 = Console.CursorLeft;
            int YCursorPos1 = Console.CursorTop;
            Console.WriteLine("\n----------------------");
            int XCursorPos2 = Console.CursorLeft;
            int YCursorPos2 = Console.CursorTop;

            Console.SetCursorPosition(XCursorPos1,YCursorPos1);
            noteTitle = Console.ReadLine();
            Console.SetCursorPosition(XCursorPos2, YCursorPos2);
            noteContent = Console.ReadLine();

            Console.Write("Tag: ");
            noteTag = Console.ReadLine();

            string filePath = roamingDirectory +"/" + "YourNotesWithCSharp" + "/" + noteTitle + ".txt";
            var NoteData = new NoteData
            {
                title = noteTitle,
                content = noteContent,
                tag = noteTag
            };
            string serializedNoteData = JsonSerializer.Serialize(NoteData);
            File.WriteAllText(filePath, serializedNoteData);
            Main();
        }

        static void TaggedNotes()
        {
            DisplayTags();
            bool isUsingMenu = true;
            for (int i = 0; i < PointerArrayII.Length; i++)
            {
                PointerArrayII[i] = ' ';
            }
            while (isUsingMenu == true)
            {
                ConsoleKeyInfo KeyData = GetKey();
                if (KeyData.Key.Equals(ConsoleKey.UpArrow) || KeyData.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (KeyData.Key.Equals(ConsoleKey.UpArrow))
                    {
                        PointerArrayII[menuSelectionII] = ' ';
                        menuSelectionII--;
                        if (menuSelectionII <= 0)
                        {
                            menuSelectionII = 0;
                        }
                        PointerArrayII[menuSelectionII] = PointerII;
                    }
                    if (KeyData.Key.Equals(ConsoleKey.DownArrow))
                    {
                        PointerArrayII[menuSelectionII] = ' ';
                        menuSelectionII++;
                        if (menuSelectionII >= PointerArrayII.Length)
                        {
                            menuSelectionII = PointerArrayII.Length - 1;
                        }
                        PointerArrayII[menuSelectionII] = PointerII;
                    }
                    DisplayTags();
                }
                if (KeyData.Key.Equals(ConsoleKey.Tab))
                {
                    Main();
                    isUsingMenu = false;
                    break;
                }
                if (KeyData.Key.Equals(ConsoleKey.Enter))
                {
                    string tagSelected = noteTags[menuSelectionII];
                    List<int> tagMatch = new List<int>();

                    for (int i = 0; i < filesArray.Length; i++)
                    {
                        string fileContent = File.ReadAllText(filesArray[i]);
                        NoteData noteData = JsonSerializer.Deserialize<NoteData>(fileContent);
                        string noteTag = noteData.tag;
                        if (noteTag == tagSelected)
                        {
                            tagMatch.Add(i);
                        }
                    }

                    Console.Clear();
                    Console.WriteLine("Found Matches: " + tagMatch.Count + "\n");

                    for (int i = 0; i < tagMatch.Count; i++)
                    {
                        Console.WriteLine(tagMatch[i]);
                    }

                    for (int i = 0; i < tagMatch.Count; i++)
                    {
                        int n = tagMatch[i];
                        string fileContent = File.ReadAllText(filesArray[n]);
                        NoteData noteData = JsonSerializer.Deserialize<NoteData>(fileContent);
                        Console.WriteLine(noteData.title);
                        Console.WriteLine("----------------------");
                        Console.WriteLine(noteData.content);
                        Console.WriteLine("\n\n\n=end of note==========\n");
                    }
                    Console.WriteLine("Press Tab to leave");

                    while (isUsingMenu == true)
                    {
                        ConsoleKeyInfo KeyDataInTag = GetKey();
                        if (KeyDataInTag.Key.Equals(ConsoleKey.Tab))
                        {
                            isUsingMenu = false;
                            break;
                        }
                    }
                    isUsingMenu = false;
                    TaggedNotes();

                }
            }



        }
        static void ListNotes()
        {
            DisplayNotes();
            bool isUsingMenu = true;
            for (int i = 0; i < PointerArrayI.Length; i++)
            {
                PointerArrayI[i] = ' ';
            }

            //get key Info, either up or down
            while (isUsingMenu == true)
            {
                ConsoleKeyInfo KeyData = GetKey();
                if (KeyData.Key.Equals(ConsoleKey.UpArrow) || KeyData.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (KeyData.Key.Equals(ConsoleKey.UpArrow))
                    {
                        PointerArrayI[menuSelectionI] = ' ';
                        menuSelectionI--;
                        if (menuSelectionI <= 0)
                        {
                            menuSelectionI = 0;
                        }
                        PointerArrayI[menuSelectionI] = PointerI;
                    }
                    if (KeyData.Key.Equals(ConsoleKey.DownArrow))
                    {
                        PointerArrayI[menuSelectionI] = ' ';
                        menuSelectionI++;
                        if (menuSelectionI >= PointerArrayI.Length)
                        {
                            menuSelectionI = PointerArrayI.Length - 1;
                        }
                        PointerArrayI[menuSelectionI] = PointerI;
                    }
                    DisplayNotes();
                }
                if (KeyData.Key.Equals(ConsoleKey.Tab))
                {
                    Main();
                    isUsingMenu = false;
                    break;
                }
                if (KeyData.Key.Equals(ConsoleKey.Enter))
                {
                    Console.Clear();
                    string fileContent = File.ReadAllText(filesArray[menuSelectionI]);
                    NoteData noteData = JsonSerializer.Deserialize<NoteData>(fileContent);

                    NoteFormat(noteData.title,noteData.content,noteData.tag);


                    while (true)
                    {
                        ConsoleKeyInfo KeyDataInNote = GetKey();
                        if (KeyDataInNote.Key.Equals(ConsoleKey.Tab))
                        {
                            ListNotes();
                            break;
                        }
                    }
                    isUsingMenu = false;

                }
            }
        }

        static void DisplayNotes()
        {
            for (int i = 0; i < PointerArrayI.Length; i++)
            {
                PointerArrayI[i] = ' ';
            }
            PointerArrayI[menuSelectionI] = PointerI;


            Console.Clear();
            Console.WriteLine("Your stored Notes\n");
            for (int i = 0; i < filesArray.Length; i++)
            {
                Console.WriteLine("{0} {1}", PointerArrayI[i], Path.GetFileName(filesArray[i]));
            }
            Console.WriteLine("\nPress Tab to leave");
        }

        static void DisplayTags()
        {
            for (int i = 0; i < PointerArrayII.Length; i++)
            {
                PointerArrayII[i] = ' ';
            }
            PointerArrayII[menuSelectionII] = PointerII;
            Console.Clear();
            Console.WriteLine("Tags\n");
            for (int i = 0; i < noteTags.Length; i++)
            {
                Console.WriteLine("{0} {1}", PointerArrayII[i], noteTags[i]);
            }
            Console.WriteLine("\nPress Tab to leave");
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
            public string title { get; set; }
            public string content { get; set; }
            public string tag { get; set; }

        }

        static void NoteFormat(string title, string content, string tag)
        {
            Console.WriteLine(title);
            Console.WriteLine("----------------------");
            Console.WriteLine(content);
            Console.WriteLine($"\nTag: {tag}");
        }
    }
}