
using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class TestWizard
{
    [Test]
    public void TestAttackValue()
    {
        const string name = "Mago";
        Wizard wizard = new Wizard(name);
        Staff staff = new Staff();
        SpellOne spellOne = new SpellOne();
        SpellsBook spellsBook = new SpellsBook();
        spellsBook.AddSpell(spellOne);
        wizard.AddItem(spellsBook);
        int attack = staff.AttackValue + spellsBook.AttackValue;
        Assert.That(attack,  Is.EqualTo(wizard.AttackValue));
    }
    [Test]
    public void TestDeffenseValue()
    {
        const string name = "Mago";
        Wizard wizard = new Wizard(name);
        Staff staff = new Staff();
        SpellOne spellOne = new SpellOne();
        SpellsBook spellsBook = new SpellsBook();
        spellsBook.AddSpell(spellOne);
        wizard.AddItem(spellsBook);
        int defense = staff.DefenseValue + spellsBook.DefenseValue;
        Assert.That(defense,  Is.EqualTo(wizard.DefenseValue));
    }
    
    [Test]
    public void TestReciveAttackDwarf()
    {
        const string name = "Mago";
        Wizard wizard = new Wizard(name);
        Staff staff = new Staff();
        SpellOne spellOne = new SpellOne();
        SpellsBook spellsBook = new SpellsBook();
        spellsBook.AddSpell(spellOne);
        wizard.AddItem(spellsBook);
        const string name1 = "Enano";
        Dwarf dwarf = new Dwarf(name1);
        Axe axe = new Axe();
        int expectedhealth = wizard.Health - (axe.AttackValue - (spellsBook.DefenseValue + staff.DefenseValue));
        if (expectedhealth > 100)
        {
            expectedhealth = 100;
        }
        wizard.ReceiveAttack(dwarf.AttackValue);
        Assert.That(wizard.Health, Is.EqualTo(expectedhealth));
    }
    
}