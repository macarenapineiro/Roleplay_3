using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Dwarf: Character, ICharacter
{
    public int VictoryPoints { get; set; }

    public Dwarf(string name) : base(name)
    {
        this.AddItem(new Axe());
        this.AddItem(new Helmet());
    }
    public void AddVictoryPoint(int victoryPoint)
    {
        this.VictoryPoints += victoryPoint;
    }
}
