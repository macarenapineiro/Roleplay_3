
using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class TestDwarf
{
    [Test]
    public void TestAttackValue()
    {
        const string name = "Enano";
        Dwarf enano = new Dwarf(name);
        Axe axe = new Axe();
        int attack = axe.AttackValue;
        Assert.That(attack,  Is.EqualTo(enano.AttackValue));
      
    }

    [Test]
    public void TestDeffenseValue()
    {
        const string name = "Enano";
        Dwarf enano = new Dwarf(name);
        Helmet helmet = new Helmet();
        int defense = helmet.DefenseValue;
        Assert.That(defense,  Is.EqualTo(enano.DefenseValue));
    }
    [Test]
    
    public void TestReciveAttackKnight()
    {
        const string name1 = "Enano";
        Dwarf dwarf = new Dwarf(name1);
        Helmet helmet = new Helmet();
        Knight knight = new Knight("Caballero");
        Sword sword = new Sword();
        int expectedhealth = dwarf.Health - (sword.AttackValue - helmet.DefenseValue);
        dwarf.ReceiveAttack(knight.AttackValue);
        Assert.That(dwarf.Health, Is.EqualTo(expectedhealth));
    }

    [Test]
    public void TestReciveAttackArcher()
    {
        const string name1 = "Enano";
        Dwarf dwarf = new Dwarf(name1);
        Helmet helmet = new Helmet();
        Archer archer = new Archer("Arquero");
        Bow bow = new Bow();
        int expectedhealth = dwarf.Health - (bow.AttackValue - helmet.DefenseValue);
        if (expectedhealth > 100)
        {
            expectedhealth = 100;
        }
        dwarf.ReceiveAttack(archer.AttackValue);
        Assert.That(dwarf.Health, Is.EqualTo(expectedhealth));
    }
    [Test]
    public void TestReciveAttackWizard()
    {
        const string name = "Enano";
        Dwarf dwarf = new Dwarf(name);
        Helmet helmet = new Helmet();
        const string name1 = "Mago";
        Wizard wizard = new Wizard(name1);
        Staff staff = new Staff();
        int expectedhealth = dwarf.Health - (staff.AttackValue - helmet.DefenseValue);
        dwarf.ReceiveAttack(wizard.AttackValue);
        Assert.That(dwarf.Health, Is.EqualTo(expectedhealth));
    }

}