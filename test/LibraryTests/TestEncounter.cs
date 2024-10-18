using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
namespace LibraryTests;

public class TestEncounter
{
    [Test]
    public void HeroAttacksEnemy()
    {
        ICharacter hero = new Dwarf("Enano");
        IEnemy enemy = new Enemy1("enemigo");
        int expected = enemy.Health - hero.AttackValue;
        enemy.ReceiveAttack(hero.AttackValue);
        Assert.That(expected, Is.EqualTo(enemy.Health));
    }

    [Test]
    public void EnemyAttacksHero()
    {
        ICharacter hero = new Dwarf("Enano");
        IEnemy enemy = new Enemy1("enemigo");
        int expected = hero.Health - enemy.AttackValue;
        hero.ReceiveAttack(enemy.AttackValue);
        Assert.That(expected, Is.EqualTo(hero.Health));
    }

    [Test]
    public void HeroDies_RemoveFromList()
    {
        List<ICharacter> hero = new List<ICharacter>{new Knight("Caballero")};
        List<IEnemy> enemies = new List<IEnemy> { new Enemy2("enemy") };
        Encounter encounter = new Encounter(hero, enemies);
        Staff staff = new Staff();
        enemies[0].AddItem(staff);
        encounter.DoEncounter();
        Assert.That(0, Is.EqualTo(hero[0].Health));
    }

    [Test]
    public void EnemyDies_RemoveFromList()
    {
        List<ICharacter> hero = new List<ICharacter> { new Wizard("Mago") };
        List<IEnemy> enemies = new List<IEnemy> { new Enemy1("enemy") };
        Encounter encounter = new Encounter(hero, enemies);
        Axe axe = new Axe();
        hero[0].AddItem(axe);
        encounter.DoEncounter();
        Assert.That(0, Is.EqualTo(enemies[0].Health));
    }

    [Test]
    public void HeroWins_GainsVictoryPoints()
    {
        List<ICharacter> hero = new List<ICharacter> { new Archer("Arquero") };
        List<IEnemy> enemy = new List<IEnemy> { new Enemy1("enemy") };
        Encounter encounter = new Encounter(hero, enemy);
        Staff staff = new Staff();
        hero[0].AddItem(staff);
        encounter.DoEncounter();
        Assert.That(5, Is.EqualTo(hero[0].VictoryPoints));
    }

    [Test]
    public void HeroCuresWith5VictoryPoint()
    {
        List<ICharacter> hero = new List<ICharacter> { new Archer("Arquero") };
        List<IEnemy> enemy = new List<IEnemy> { new Enemy1("enemy") };
        Encounter encounter = new Encounter(hero, enemy);
        Staff staff = new Staff();
        hero[0].AddItem(staff);
        encounter.DoEncounter();
        Assert.That(100, Is.EqualTo(hero[0].Health));
    }
}