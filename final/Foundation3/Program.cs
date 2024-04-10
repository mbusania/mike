using System;

class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public Address Address { get; set; }

    public virtual string GetMessage()
    {
        return $"Event: {Title}\nDescription: {Description}\nDate: {Date.ToShortDateString()}\nTime: {Time}\nAddress: {Address.GetFullAddress()}";
    }
}

class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public override string GetMessage()
    {
        return base.GetMessage() + $"\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

class Reception : Event
{
    public string RSVP { get; set; }

    public override string GetMessage()
    {
        return base.GetMessage() + $"\nRSVP: {RSVP}";
    }
}

class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public override string GetMessage()
    {
        return base.GetMessage() + $"\nWeather Forecast: {WeatherForecast}";
    }
}

class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    public string GetFullAddress()
    {
        return $"{StreetAddress}, {City}, {StateProvince}, {Country}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address
        {
            StreetAddress = "456 Elm St",
            City = "Los Angeles",
            StateProvince = "CA",
            Country = "USA"
        };

        Lecture lecture1 = new Lecture
        {
            Title = "Introduction to Programming",
            Description = "Learn the basics of programming.",
            Date = new DateTime(2024, 4, 15),
            Time = new TimeSpan(9, 0, 0),
            Address = address1,
            Speaker = "John Doe",
            Capacity = 100
        };

        Reception reception1 = new Reception
        {
            Title = "Networking Mixer",
            Description = "Meet and greet with professionals.",
            Date = new DateTime(2024, 5, 20),
            Time = new TimeSpan(18, 0, 0),
            Address = address1,
            RSVP = "example@example.com"
        };

        OutdoorGathering gathering1 = new OutdoorGathering
        {
            Title = "Summer Picnic",
            Description = "Enjoy food and games outdoors.",
            Date = new DateTime(2024, 7, 4),
            Time = new TimeSpan(12, 0, 0),
            Address = address1,
            WeatherForecast = "Sunny"
        };

        Console.WriteLine(lecture1.GetMessage());
        Console.WriteLine();
        Console.WriteLine(reception1.GetMessage());
        Console.WriteLine();
        Console.WriteLine(gathering1.GetMessage());
    }
}
