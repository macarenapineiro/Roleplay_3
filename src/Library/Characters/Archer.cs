using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Archer : Character, ICharacter
{
    public int VictoryPoints { get; set; }
    public Archer(string name) : base (name)
    {
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }

    public void AddVictoryPoint(int victoryPoint)
    {
        this.VictoryPoints += victoryPoint;
    }
}
