using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
using Library;
namespace LibraryTests;

public class TestEncounter
{
    [Test]
    public void HeroAttacksEnemy()
    {
        List<ICharacter> hero = new List<ICharacter> { new Dwarf("Enano") };
        List<IEnemy> enemy = new List<IEnemy> { new Enemy1("enemigo") };
        Encounter encounter = new Encounter(hero, enemy);
        int expectedhealth = 0;
        encounter.DoEncounter();
        Assert.That(expectedhealth, Is.EqualTo(enemy[0].Health));
    }


    [Test]
    public void EnemyAttacksHero()
    {
        List<ICharacter> hero = new List<ICharacter> {new Archer("Arquero")};
        List<IEnemy> enemy = new List<IEnemy> { new Enemy2("enemigo") };
        Encounter encounter = new Encounter(hero, enemy);
        int expectedhealth = 0;
        encounter.DoEncounter();
        Assert.That(expectedhealth, Is.EqualTo(hero[0].Health));
    }

    [Test]
    public void HeroWins_GainsVictoryPoints()
    {
        List<ICharacter> hero = new List<ICharacter> { new Dwarf("Caballero") };
        List<IEnemy> enemy = new List<IEnemy> { new Enemy1("enemy") };
        Encounter encounter = new Encounter(hero, enemy);
        encounter.DoEncounter();
        Assert.That(5, Is.EqualTo(hero[0].VictoryPoints));
    }

    [Test]
    public void HeroCuresWith5VictoryPoint()
    {
        List<ICharacter> hero = new List<ICharacter> { new Dwarf("Caballero") };
        List<IEnemy> enemy = new List<IEnemy> { new Enemy1("enemy") };
        Encounter encounter = new Encounter(hero, enemy);
        encounter.DoEncounter();
        Assert.That(100, Is.EqualTo(hero[0].Health));
    }
}