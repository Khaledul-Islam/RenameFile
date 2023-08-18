namespace RenameFile;

internal class Program
{
    private static string directoryPath;
    private static void ShowFiles()
    {

        var directory = new DirectoryInfo(directoryPath);

        if (directory.Exists)
        {
            foreach (var file in directory.GetFiles())
            {

                Console.WriteLine(file.Name);

            }
            Console.ReadKey();
            ExitMenuOption();
            ExitMenuAction();
        }
        else
        {
            Console.WriteLine("Directory not found.");
            ExitMenuOption();
            ExitMenuAction();
        }

    }

    private static void ReplaceKey()
    {
        string oldValue;
        string newValue;
        do
        {
            Console.WriteLine();
            Console.Write("Enter Key to Replace: ");
            oldValue = Console.ReadLine();
        } while (string.IsNullOrEmpty(oldValue));

        do
        {
            Console.WriteLine();
            Console.Write("Enter New Key: ");
            newValue = Console.ReadLine();
        } while (string.IsNullOrEmpty(newValue));


        var directory = new DirectoryInfo(directoryPath);

        if (directory.Exists)
        {
            foreach (var file in directory.GetFiles())
            {
                var originalName = file.Name;
                var newName = originalName
                    .Replace(oldValue, newValue).Trim();
                if (originalName != newName)
                {
                    var newPath = Path.Combine(directory.FullName, newName);
                    File.Move(file.FullName, newPath);
                    Console.WriteLine($"Renamed '{originalName}' to '{newName}'");
                }
            }

            ExitMenuOption();
            ExitMenuAction();
        }
        else
        {
            Console.WriteLine("Directory not found.");
            ExitMenuOption();
            ExitMenuAction();
        }

    }
    private static void ChangePath()
    {
        string newPath;
        do
        {
            Console.WriteLine();
            Console.Write("Enter New Directory Path: ");
            newPath = Console.ReadLine();
        } while (string.IsNullOrEmpty(newPath));

        directoryPath = newPath;
        Console.WriteLine("Directory Path Changed Successfully.");
        ExitMenuOption();
        ExitMenuAction();
    }
    private static void RemoveKey()
    {
        string keywordToRemove;
        do
        {
            Console.WriteLine();
            Console.Write("Enter Key to Remove: ");
            keywordToRemove = Console.ReadLine();
        } while (string.IsNullOrEmpty(keywordToRemove));


        var directory = new DirectoryInfo(directoryPath);

        if (directory.Exists)
        {
            foreach (var file in directory.GetFiles())
            {
                var originalName = file.Name;
                var newName = originalName.Replace(keywordToRemove, "").Trim();
                if (originalName != newName)
                {
                    var newPath = Path.Combine(directory.FullName, newName);
                    File.Move(file.FullName, newPath);
                    Console.WriteLine($"Renamed '{originalName}' to '{newName}'");
                }
            }

            ExitMenuOption();
            ExitMenuAction();
        }
        else
        {
            Console.WriteLine("Directory not found.");
            ExitMenuOption();
            ExitMenuAction();
        }

    }
    private static void DisplayOption()
    {
        Console.WriteLine();
        Console.WriteLine("####---MENU---####");
        Console.WriteLine("==================");
        Console.WriteLine("#Show Files    : 1");
        Console.WriteLine("#Remove Key    : 2");
        Console.WriteLine("#Replace Key   : 3");
        Console.WriteLine("#Change Path   : 0");
        Console.WriteLine("#Exit Program  : Q");
    }
    private static void ChooseOption()
    {
        string option;
        //choose option
        do
        {
            Console.Write("#Choose Option : ");
            option = Console.ReadLine();
        } while (string.IsNullOrEmpty(option));

        switch (option.ToLower())
        {
            case "1":
                ShowFiles();
                break;
            case "2":
                RemoveKey();
                break;
            case "3":
                ReplaceKey();
                break;
            case "0":
                ChangePath();
                break;
            case "q":
                Environment.Exit(-1);
                break;
            default:
                WrongInput();
                DisplayOption();
                ChooseOption();
                break;
        }

    }

    private static void ExitMenuOption()
    {
        Console.WriteLine();
        Console.WriteLine("#Exit Program    : Q");
        Console.WriteLine("#Goto Main Menu  : 1");

    }
    private static void ExitMenuAction()
    {
        string key;
        do
        {
            Console.Write("#Choose Option   : ");
            key = Console.ReadLine();
        } while (string.IsNullOrEmpty(key));

        switch (key.ToLower())
        {
            case "1":
                Console.WriteLine("Clearing the screen!");
                Console.Clear();
                DisplayOption();
                ChooseOption();
                break;
            case "q":
                Environment.Exit(-1);
                break;
            default:
                WrongInput();
                ExitMenuOption();
                ExitMenuAction();
                break;
        }
    }
    private static void WrongInput()
    {
        Console.WriteLine();
        Console.WriteLine("Wrong Input !!");
        Console.WriteLine("Clearing the screen!");
        Thread.Sleep(2000);
        Console.Clear();
    }
    private static void Main(string[] args)
    {
        string option;

        //choose path
        do
        {
            Console.Write("Enter File Path: ");
            directoryPath = Console.ReadLine();
        } while (string.IsNullOrEmpty(directoryPath));

        DisplayOption();
        ChooseOption();
    }
}