using System;

public class Customer
{
    public int CustomerID { get; set; }
    public string Work { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public void MakePayment(Tour tour, decimal discountRate)
    {
        decimal finalPrice = tour.Price * (1 - discountRate);
        Console.WriteLine($"{Name} согласился на  \"{tour.TourType}\" на должность {Work}.");
    }

    public void SelectTour(Tour tour)
    {
        Console.WriteLine($"{Name} выбрал должность пилота \"{tour.TourType}\".");
    }
}

public class Tour
{
    public int TourID { get; set; }
    public decimal Price { get; set; }
    public string TourType { get; set; }
    public bool IsHotTour { get; set; }

    public void GetDetails()
    {
        string hotTourStatus = IsHotTour ? "Неактивна" : "Активна";
        Console.WriteLine($"ID заявки: {TourID}, Цена подачи: {Price}, Время работы: {TourType}, Статус: {hotTourStatus}");
    }
}

public class Agent
{
    public int AgentID { get; set; }
    public string Name { get; set; }

    public void DefineHotTour(Tour tour)
    {
        tour.IsHotTour = true;
        Console.WriteLine($"Работник Авиакомпании {Name} принял заявку \"{tour.TourType}\" на рассмотрение.");
    }

    public void SetDiscountRate(Customer customer, Tour tour, decimal discountRate)
    {
        if (tour.IsHotTour)
        {
            Console.WriteLine($"Работник Авиакомпании {Name} одобрил портфолио и назначил на должность {customer.Name}.");
        }
    }
}

class Program
{
    static void Main()
    {
        Customer customer = new Customer
        {
            CustomerID = 1,
            Work = "Пилот",
            Name = "Матвей Ефимов",
            PhoneNumber = "123-456-7890"
        };

        Tour tour = new Tour
        {
            TourID = 101,
            Price = 100,
            TourType = "срок работы год"
        };

        Agent agent = new Agent
        {
            AgentID = 4001,
            Name = "Администратор Олег"
        };

        customer.SelectTour(tour);
        tour.GetDetails();

        agent.DefineHotTour(tour);
        agent.SetDiscountRate(customer, tour, 0.15m);

        customer.MakePayment(tour, 0.15m);

        Console.ReadLine();
    }
}