internal class User
{

    public string CardNum { get; private set; }

    public int Pin { get; private set; }

    public string FirstName { get; private set;}

    public string LastName { get; private set;}

    public double Balance { get; private set; }

    public User(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose an option");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.Withdraw");
            Console.WriteLine("3.Show Balance");
            Console.WriteLine("4.Exit");
        }


        void deposit(User user)
        {
            Console.WriteLine("How much money are you depositing?");
            double deposit = 0;
            if (!double.TryParse(Console.ReadLine(), out deposit))
            {
                Console.WriteLine("Invalid amount entered!");
                return;
            }
            user.Balance += deposit;
            Console.WriteLine($"Thank you for depositing ${deposit}. Your new balance is ${user.Balance}");
        }

        void withdraw(User user)
        {
            Console.WriteLine("How much money are you withdrawing?");
            double withdraw = 0;
            if (!double.TryParse(Console.ReadLine(), out withdraw))
            {
                Console.WriteLine("Invalid amount entered!");
                return;
            }
            if (user.Balance < withdraw)
            {
                Console.WriteLine("Insufficient funds!");
                return;
            }
            user.Balance -= withdraw;
            Console.WriteLine($"Here you go! Your new balance is ${user.Balance}");
        }

        void balance(User user)
        {
            Console.WriteLine($"Current balance: ${user.Balance}");
        }

        List<User> Users = new List<User>();

            Users.Add(new User("1029384785", 1234, "Josh", "Smith", 6000.14));
            Users.Add(new User("456783456", 4321, "Jeff", "Jones", 9000.59));
            Users.Add(new User("091472984", 4587, "Steve", "Cartel", 7000.54));
            Users.Add(new User("909823276", 9568, "Sara", "Toma", 3000.84));
            Users.Add(new User("001287419", 3258, "Willy", "Nelson", 60.04));

        Console.WriteLine("Welcome to Console ATM");
        Console.Write("Please insert your debit card number: ");
        string debitCardNum = "";
        User currentUser;

        while (true)
        {
            try
            {
                debitCardNum= Console.ReadLine();
                currentUser = Users.FirstOrDefault(a=>a.CardNum==debitCardNum);
                if(currentUser!= null) 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized");
                }
            }
            catch
            {
                Console.WriteLine("Card not recognized");
            }
        }
        Console.Write("Please enter your 4 digit pin:");
        int userPin = 0;
        while (true)
        {
            try
            {
                if (!int.TryParse(Console.ReadLine(), out userPin))
                {
                    Console.WriteLine("Invalid pin entered!");
                    continue;
                }
                if(currentUser.Pin==userPin)
                {
                    break;
                }
            }
            catch
            {
                Console.WriteLine("Pin not recognized, try again");
            }
        }
        Console.WriteLine($"Welcome {currentUser.FirstName}");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                
            }
            if(option ==1) 
            { 
                deposit(currentUser); 
            }
            else if(option ==2) 
            { 
                withdraw(currentUser); 
            }
            else if(option ==3) 
            {
                Console.WriteLine($"{currentUser.Balance}");
            }
            else if (option == 4)
            {
                break ;
            }
            else
            {
                option = 0;
            }
        }
        while (option != 4);

        Console.WriteLine($"Thank You {currentUser.FirstName}, have a nice day!");
    }
}