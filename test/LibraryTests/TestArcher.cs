using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;
public class TestArcher
{
    [Test]
    public void TestAttackValue()
    {
        const string name = "Arquero";
        Archer archer = new Archer(name);
        Bow bow = new Bow();
        int attack = bow.AttackValue;
        Assert.That(attack,  Is.EqualTo(archer.AttackValue));
    }

    [Test]
    public void TestDeffenseValue()
    {
        const string name = "Arquero";
        Archer archer = new Archer(name);
        Helmet helmet = new Helmet();
        int defense = helmet.DefenseValue;
        Assert.That(defense,  Is.EqualTo(archer.DefenseValue));
    }
    
    [Test]
    public void TestReciveAttackDwarf()
    {
        const string name = "Arquero";
        Archer archer = new Archer(name);
        Helmet helmet = new Helmet();
        const string name1 = "Enano";
        Dwarf dwarf = new Dwarf(name1);
        Axe axe = new Axe();
        int expectedhealth = archer.Health - (axe.AttackValue - helmet.DefenseValue);
        archer.ReceiveAttack(dwarf.AttackValue);
        Assert.That(archer.Health, Is.EqualTo(expectedhealth));
    }
    [Test]
    public void TestReciveAttackKnight()
    {
        const string name = "Arquero";
        Archer archer = new Archer(name);
        Helmet helmet = new Helmet();
        Knight knight = new Knight("Caballero");
        Sword sword = new Sword();
        int expectedhealth = archer.Health - (sword.AttackValue - helmet.DefenseValue);
        archer.ReceiveAttack(knight.AttackValue);
        Assert.That(archer.Health, Is.EqualTo(expectedhealth));
    }
    [Test]
    public void TestAttackWizard()
    {
        const string name = "Arquero";
        Archer archer = new Archer(name);
        Helmet helmet = new Helmet();
        const string name1 = "Mago";
        Wizard wizard = new Wizard(name1);
        Staff staff = new Staff();
        int expectedhealth = archer.Health - (staff.AttackValue - helmet.DefenseValue);
        archer.ReceiveAttack(wizard.AttackValue);
        Assert.That(archer.Health, Is.EqualTo(expectedhealth));
    }

}
