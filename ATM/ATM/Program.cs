//library used
using System;
using System.Collections.Generic;
using System.IO;

//class (main role)
public class cardHolder
{
    String firstName;
    String lastName;
    String cardNum;
    int pincode;
    double balance;

    //function, make functionality
    //this > declare current instance of the program
    public cardHolder(String cardNum, int pincode, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pincode = pincode;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //getters to request data
    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pincode;
    }

    public String getFirst()
    {
        return firstName;
    }

    public String getLast()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    //setter to insert or set data
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String NewLastName)
    {
        lastName = NewLastName;
    }

    public void setPin(int newPincode)
    {
        pincode = newPincode;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Select an option");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("how much $ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());

            //currentUser.setBalance() == currentUser.getBalance + deposit;
            currentUser.setBalance(currentUser.getBalance() + deposit);
            
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("how much $ would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());


            //check balance if they can withdraw
            if (currentUser.getBalance() < withdraw)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("Here you go");

            }


        }
        void showBalance(cardHolder currentUser)
        {
            Console.WriteLine("Your balance is $" + currentUser.getBalance());
        }

        //List of users, a test Database
        List<cardHolder> cardHolders = new List<cardHolder>();

        cardHolders.Add(new cardHolder("12341234", 1234, "John", "Doe", 50.00));
        cardHolders.Add(new cardHolder("11111111", 2222, "Johny", "Doe", 0.00));
        cardHolders.Add(new cardHolder("22222222", 2222, "Brock", "Pewter", 180.35));
        cardHolders.Add(new cardHolder("33333333", 1337, "Misty", "Test", 30.35));
        cardHolders.Add(new cardHolder("99999999", 4123, "Misty", "Test", 2230.35));
        cardHolders.Add(new cardHolder("12344321", 2221, "Misty", "Test", 20.00));


        // Prompt user
        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your card number");

        //First operation, read card / cardnumber

        String debitCard = "";
        cardHolder currentUser;
        while (true)
        {
            try
            {
                debitCard = Console.ReadLine();

                //searches the list of cardHolders and takes everything from the first match, in this case cardnumber
                //then compare the given debitcard to cardnumber in database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCard);


                //if user isn't nothing, continue code
                if (currentUser != null)
                {
                    break;
                }
                else { Console.WriteLine("Card unrecognized please try again."); }

            }
            catch
            {
                Console.WriteLine("Card unrecognized please try again.");
            }

        }

        //Second operation, validate pincode

        int pincode;
        Console.WriteLine("Please insert your pincode");

        while (true)
        {
            try
            {
                pincode = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == pincode)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin please try again");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect pin please try again");
            }

        }

        //Third operation, user is logged in and wants to use the ATM

        Console.WriteLine("Welcome " + currentUser.getFirst());
        int option = 0;

        //Do something untill you get to while
        do
        {
            //show user options to enter
            printOptions();
            try {
                option = int.Parse(Console.ReadLine());
            } catch {
            }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2){ withdraw(currentUser); }
            else if(option == 3){ showBalance(currentUser); }
            else if(option == 4){ break; }
            //prevents wrong input, resets back to main menu
            else{ option = 0; }


        } while (option != 4);
        Console.WriteLine("Thank you, have a nice day");



    }
}


