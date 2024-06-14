using FestaECia.Models.Enums;

namespace FestaECia.Models;

public abstract class Party : IParty
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public int NumberOfGuests { get; private set; }
    public Space Space { get; private set; }
    public PartyType Type { get; private set; }
    public double Price { get; private set; }
    public List<Food> Foods { get; private set; }
    public List<Drink> Drinks { get; private set; }
    
    public Party(int id, DateTime date, int numberOfGuests, Space space, PartyType type, double price)
    {
        Id = id;
        Date = date;
        NumberOfGuests = numberOfGuests;
        Space = space;
        Type = type;
        Price = price;
        Foods = new List<Food>();
        Drinks = new List<Drink>();
    }

    public void AddFood(Food food)
    {
        Foods.Add(food);
    }

    public void AddDrink(Drink drink)
    {
        Drinks.Add(drink);
    }
}