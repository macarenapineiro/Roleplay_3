namespace Ucu.Poo.RoleplayGame;

public class Enemy1 : Character, IEnemy
{
    public int VictoryPoints { get; }

    public Enemy1(string name) : base(name)
    {
        this.VictoryPoints = 5;
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }

    public void DefeatedBy(ICharacter character)
    {
        character.AddVictoryPoint(VictoryPoints);
    }
}