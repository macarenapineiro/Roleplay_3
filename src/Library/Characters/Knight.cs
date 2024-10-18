using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Knight : Character, ICharacter
{
    public int VictoryPoints { get; set; }

    public Knight(string name) : base(name)
    {
        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
    }
    public void AddVictoryPoint(int victoryPoint)
    {
        this.VictoryPoints += victoryPoint;
    }
}