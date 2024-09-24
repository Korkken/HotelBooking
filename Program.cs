// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

MainProgram();
void MainProgram()
{
    Console.WriteLine("Hej, vad är ditt för och efternamn");
    string? namn = Console.ReadLine();
    Console.WriteLine("Vad är din epost adress");
    string email = Console.ReadLine();
    Console.WriteLine("Vad är ditt telefonnummer?");
    string nummer = Console.ReadLine();
    Person person = new Person(namn, email, nummer);

    Console.WriteLine("Från när vill du boka hotelrummet?");
    DateTime startDate;

    while (!DateTime.TryParse(Console.ReadLine(), out startDate))
    {
        Console.WriteLine("Skriv in i formatet ÅÅÅÅ-MM-DD");
    }

    Console.WriteLine("Hur många dagar vill du boka?");
    int lengthOfStayInDays = int.Parse(Console.ReadLine());
    HotelBooking booking = new HotelBooking(person, startDate, lengthOfStayInDays);
    booking.ShowBookingDetails();

    Console.WriteLine("vill du ändra längden på bokningen?");
    string? updateBooking = Console.ReadLine();
    if (updateBooking?.ToLower() == "ja")
    {
        Console.WriteLine("Hur många dagar vill du ändra det till");
        lengthOfStayInDays = int.Parse(Console.ReadLine());
        HotelBooking updatedBooking = new HotelBooking(person, startDate, lengthOfStayInDays);
        updatedBooking.ShowBookingDetails();

    }
    else
    {
        Console.WriteLine("Tack för din bokning!");
    }
}

class HotelBooking
{
    public Person Person { get; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Price { get; set; }

    public HotelBooking(Person person, DateTime startDate, int lengthOfStayInDays)
    {
        Person = person;
        StartDate = startDate.Add(new TimeSpan(15, 0, 0));
        EndDate = StartDate.AddDays(lengthOfStayInDays).Date.Add(new TimeSpan(12, 0, 0));
        Price = 1999 * lengthOfStayInDays;
    }
    public void ShowBookingDetails()
    {
        Console.WriteLine($"Namn: {Person.Name}");
        Console.WriteLine($"Epost: {Person.Email}");
        Console.WriteLine($"Telefonnr: {Person.PhoneNumber}");
        Console.WriteLine($"Start datum: {StartDate}");
        Console.WriteLine($"Slut datum: {EndDate}");
        Console.WriteLine($"Priset blir: {Price}kr");

    }
}
class Person
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public Person(string name, string email, string phoneNumber ) 
        {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        }
}







