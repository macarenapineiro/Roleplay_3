namespace Ucu.Poo.RoleplayGame;

public interface ICharacter
{
    public int VictoryPoints { get; set; }
    string Name { get; set; }

    int Health { get; }

    int AttackValue { get; }

    int DefenseValue { get; }

    void AddItem(IItem item);

    void RemoveItem(IItem item);

    void Cure();

    void ReceiveAttack(int power);
    
    void AddVictoryPoint(int victoryPoint);

}
