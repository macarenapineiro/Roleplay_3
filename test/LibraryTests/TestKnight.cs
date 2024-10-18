
using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;
public class TestKnight
{
    [Test]
    public void TestAttackValue()
    {
        const string name = "Caballero";
        Knight knight = new Knight(name);
        Sword sword = new Sword();
        int attack = sword.AttackValue;
        Assert.That(attack,  Is.EqualTo(knight.AttackValue));
    }

    [Test]
    public void TestDeffenseValue()
    {
        const string name = "Caballero";
        Knight knight = new Knight(name);
        Armor armor = new Armor();
        Shield shield = new Shield();
        int defense = armor.DefenseValue + shield.DefenseValue;
        Assert.That(defense,  Is.EqualTo(knight.DefenseValue));
    }
    
    [Test]
    public void TestReciveAttackDwarf()
    {
        Knight knight = new Knight("Caballero");
        Armor armor = new Armor();
        Shield shield = new Shield();
        const string name1 = "Enano";
        Dwarf dwarf = new Dwarf(name1);
        Axe axe = new Axe();
        int expectedhealth = knight.Health - (axe.AttackValue - (armor.DefenseValue + shield.DefenseValue));
        if (expectedhealth > 100)
        {
            expectedhealth = 100;
        }
        knight.ReceiveAttack(dwarf.AttackValue);
        Assert.That(knight.Health, Is.EqualTo(expectedhealth));
    }
    [Test]
    public void TestReciveAttackArcher()
    {
        Knight knight = new Knight("Caballero");
        Armor armor = new Armor();
        Shield shield = new Shield();
        Archer archer = new Archer("Arquero");
        Bow bow = new Bow();
        int expectedhealth = knight.Health - (bow.AttackValue - (armor.DefenseValue + shield.DefenseValue));
        if (expectedhealth > 100)
        {
            expectedhealth = 100;
        }
        knight.ReceiveAttack(archer.AttackValue);
        Assert.That(knight.Health, Is.EqualTo(expectedhealth));
    }
    [Test]
    public void TestAttackWizard()
    {
        Knight knight = new Knight("Caballero");
        Armor armor = new Armor();
        Shield shield = new Shield();
        const string name1 = "Mago";
        Wizard wizard = new Wizard(name1);
        Staff staff = new Staff();
        int expectedhealth = knight.Health - (staff.AttackValue - (armor.DefenseValue + shield.DefenseValue));
        knight.ReceiveAttack(wizard.AttackValue);
        Assert.That(knight.Health, Is.EqualTo(expectedhealth));
    }

}
