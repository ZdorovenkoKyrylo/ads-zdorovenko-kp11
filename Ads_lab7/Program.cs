// See https://aka.ms/new-console-template for more information
using ADS_Hashtable;

class Program
{
    public static void Main(String[] args)
    {
        while (true)
        {
            Console.WriteLine("\n1-Control example");
            Console.WriteLine("2-Manual mode");
            Console.WriteLine("3-Clear console");
            Console.WriteLine("4-Exit");

            string command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    ControlExample();
                    break;
                case "2":
                    ManualMode();
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid command. Try again");
                    break;
            }
        }
    }

    public static void ControlExample()
    {
        HashTable table = new HashTable();
        Console.WriteLine("Insert 5 different entries which can cause collision");
        table.insertEntry(new Key("abc"), new Value("qweewq", "asd@gmail.com", new Date(06, "Лютого", 2020)));
        table.insertEntry(new Key("asdff"), new Value("qwq", "ndfbkjb@mgail.com", new Date(01, "Липня", 2019)));
        table.insertEntry(new Key("bca"), new Value("fdgsdf", "tyu@gmail.com", new Date(11, "Листопада", 2019)));
        table.insertEntry(new Key("dsgd"), new Value("nbuejcd", "calculus@gmail.com", new Date(23, "Квітня", 2019)));
        table.insertEntry(new Key("cba"), new Value("zxcv", "dfgfdg@gmail.com", new Date(21, "Листопада", 2019)));
        table.insertEntry(new Key("dsgd"), new Value("xcvssde", "sdvcasd@gmail.com", new Date(9,"Березня", 2019)));
        Console.WriteLine("See the result of inserting");
        printTable(table);
        Console.WriteLine("Insert 4 more other entries which must cause rehashing and collision");
        table.insertEntry(new Key("cba"), new Value("zxcv", "tyu@gmail.com", new Date(22, "Травня", 2019)));
        table.insertEntry(new Key("ac"), new Value("gdfew", "iuukuyk@gmail.com", new Date(06, "Вересня", 2020)));
        table.insertEntry(new Key("adff"), new Value("zxcsdf", "fdgdfg@gmail.com", new Date(01, "Серпня", 2019)));
        table.insertEntry(new Key("ca"), new Value("hghjjhg", "vbcxxz@gmail.com", new Date(11, "Грудня", 2019)));
        table.insertEntry(new Key("chgf"), new Value("ytryetr", "ewfwq@gmail.com", new Date(21, "Лютого", 2019)));
        printTable(table);
        Console.WriteLine("Try to find some user\n");
        var entry = table.findEntry(new Key("adff"));
        Console.WriteLine($"Username{entry.Key.username,5}\t\tPassword{entry.Value.Password,5}\t\tEmailAddress{entry.Value.EmailAdress,15}\tLastLoginDate\t{entry.Value.LastLoginDate,9}");
        Console.WriteLine("\nTry to remove some user");
        table.removeEntry(new Key("cba"));
        printTable(table);
        Console.WriteLine("\nTry to Deativate user which was not here for more than 60 days\n");
        ControExampleDeactivate(table);
        printTable(table);
    }
    public static void ManualMode()
    {
        var table = new HashTable();

        while (true)
        {
            Console.WriteLine("a - Insert entry");
            Console.WriteLine("b - Remove entry");
            Console.WriteLine("c - Find entry");
            Console.WriteLine("d - Display hashtable");
            Console.WriteLine("e - Authorisation");
            Console.WriteLine("f - Account deactivation");
            Console.WriteLine("g - Exit");

            Console.Write("Input command: ");

            string command = Console.ReadLine();

            switch (command)
            {
                case "a":
                    Insert(table);
                    break;
                case "b":
                    Remove(table);
                    break;
                case "c":
                    Find(table);
                    break;
                case "d":
                    printTable(table);
                    break;
                case "e":
                    Authorization(table);
                    break;
                case "f":
                    Deactivation(table);
                    break;
                case "g":
                    return;
                default:
                    Console.WriteLine("\nInvalid command");
                    break;
            }
            Console.WriteLine();
        }
    }

    private static Entry requireInput(bool value) //false - only key, true - key and value
    {
        Console.Write("Enter username(only lowercase letters & numbers): ");
        string username = Console.ReadLine().Trim();

        if (value)
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine().Trim();

            Console.Write("Enter password: ");
            string password = Console.ReadLine().Trim();

            Console.Write("Enter last login date(format: day month year) or \"rand\" to generate the date automatically\nExample: 10 Вересня 2022\nDate: ");
            string inputDate = Console.ReadLine().Trim();

            if (inputDate.Trim() == "rand")
            {
                string[] months = new string[] { "Січня", "Лютого", "Березня", "Квітня", "Травня", "Червня", "Липня", "Серпня", "Вересня", "Жовтня", "Листопада", "Грудня" };
                inputDate = new Random().Next(1, 29) + " " + months[new Random().Next(0, 12)] + " " + new Random().Next(2019, 2023);
            }
            var temp = inputDate.Split(" ");

            var date = new Date(int.Parse(temp[0]), temp[1], int.Parse(temp[2]));

            return new Entry(new Key(username), new Value(password, email, date));
        }

        return new Entry(new Key(username), new Value());
    }

    public static void Insert(HashTable table)
    {
        var input = requireInput(true);

        table.insertEntry(input.Key, input.Value);
        Console.WriteLine("Inserted successful\n");
    }

    public static void Remove(HashTable table)
    {
        var key = requireInput(false).Key;

        var removed = table.removeEntry(key);
        Console.WriteLine("Removal successful: " + removed);
    }

    public static void Find(HashTable table)
    {
        var key = requireInput(false).Key;

        var found = table.findEntry(key);

        Console.Write("\nFound entry: ");
        if (found == null)
            Console.WriteLine("none\n");
        else
            Console.WriteLine($"Username: {found.Key.username}\tEmail: {found.Value.EmailAdress}\tPassword: {found.Value.Password}\tLast login date: {found.Value.LastLoginDate}\n");
    }

    public static void Authorization(HashTable table)
    {
        Console.WriteLine("\nAuthorisation section:\n");

        var username = requireInput(false).Key.username;

        Console.Write("Enter password: ");
        var password = Console.ReadLine().Trim();

        var found = table.findEntry(new Key(username));

        if (found == null || found.Key.username == "DELETED")
            Console.WriteLine("\nEntry was not found\n");
        else if (found.Value.Password == "" + table.passwordHash(password))
        {
            Console.WriteLine("\nEntry found:");
            Console.WriteLine($"Username: {found.Key.username}\tEmail: {found.Value.EmailAdress}\tPassword: {found.Value.Password}\tLast login date: {found.Value.LastLoginDate}\n");
        }
        else
            Console.WriteLine("\nIncorrect password");
    }
    public static void ControExampleDeactivate(HashTable table)
    {
        Console.WriteLine("The entry is being deleted\n");
        table.removeEntry(new Key("asdff"));
    }
    private static void Deactivation(HashTable table)
    {
        Console.WriteLine("Account deactivation section:");
        var username = requireInput(false).Key.username;

        var entry = table.findEntry(new Key(username));

        if (entry == null)
        {
            Console.WriteLine("Such account was not found");
            return;
        }

        Console.WriteLine("Amount of days since the last login: ");

        int difference = Date.getDifference(entry.Value.LastLoginDate, new Date(DateTime.Now.Day, "Червня", 2022));

        Console.Write($"Last login date was {difference} day(s) ago. ");

        if (difference >= 60)
        {
            Console.WriteLine("The entry is being deleted\n");
            table.removeEntry(new Key(username));
        }
    }

    public static void printTable(HashTable table)
    {
        Console.WriteLine($"\n{"HashTable contents:",70}\n");
        Console.WriteLine($"{"Index",5}{"Username",22}\t{"Password",20}\t{"EmailAddress",20}\t{"LastLoginDate",20}");
        var arr = table.getTable();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == null)
                continue;
            Console.WriteLine($"{i,5}\t{arr[i].Key.username,20}\t{arr[i].Value.Password,20}\t{arr[i].Value.EmailAdress,20}\t{arr[i].Value.LastLoginDate,20}");
            
        }
        Console.WriteLine($"\t\t\t\tSize{table.Size,4}\t\t\tCapacity{table.Table.Length,4}\t\t\tLoadness {Math.Round(table.Loadness,4),4}");
        Console.WriteLine("\n");
    }
}