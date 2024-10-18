namespace Ucu.Poo.RoleplayGame;

public class Enemy2 : Character, IEnemy
{
    public int VictoryPoints { get; }

    public Enemy2(string name) : base(name)
    {
        this.VictoryPoints = 3;
        this.AddItem(new Bow());
        this.AddItem(new Axe());
        this.AddItem(new Helmet());
    }

    public void DefeatedBy(ICharacter character)
    {
        character.AddVictoryPoint(VictoryPoints);
    }
}