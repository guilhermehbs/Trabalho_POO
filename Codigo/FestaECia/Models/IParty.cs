using FestaECia.Models.Enums;

namespace FestaECia.Models;

public interface IParty
{
    public void AddFood(Food food);
    public void AddDrink(Drink drink);
}