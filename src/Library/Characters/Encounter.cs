using Ucu.Poo.RoleplayGame;
using System.Runtime.CompilerServices;
namespace Library;


public class Encounter
{
    /// <summary>
    /// Crea una lista con los heroes y otra con los enemigos
    /// </summary>
    private List<ICharacter> heroes;

    private List<IEnemy> enemies;

    public Encounter(List<ICharacter> heroes, List<IEnemy> enemies)
    {
        this.heroes = heroes;
        this.enemies = enemies;
    }

    /// <summary>
    /// Mientras que hayan heroes y enemigos vivos primero ataca el enemigo y luego el heroe y verifica si alguno se quedó sin vida
    /// </summary>
    public void DoEncounter()
    {
        while (HeroesVivos() && EnemiesVivos())
        {
            EnemyAttack();
            HeroAttack();
        }
    }

    public bool HeroesVivos()
    {
        foreach (ICharacter hero in heroes)
        {
            if (hero.Health > 0)
            {
                return true;
            }
        }
        return false;
    }
    public bool EnemiesVivos()
    {
        foreach (IEnemy enemy in enemies)
        {
            if (enemy.Health > 0)
            {
                return true;
            }
        }
        return false;
    }

    public void EnemyAttack()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            IEnemy enemywhoattack = enemies[i];
            // i % heroes.Count se utiliza si la cantidad de heroes es menor a las de enemigos no quede fuera de rango
            ICharacter hero = heroes[i % heroes.Count];
            if (enemywhoattack.Health > 0)
            {
                hero.ReceiveAttack(enemywhoattack.AttackValue);
            }
        }
    }

    private void HeroAttack()
    {
        for(int i = 0; i < heroes.Count; i++)
        {
            ICharacter hero = heroes[i];
            if (hero.Health > 0)
            { 
                for(int e = 0; e < enemies.Count; e++)
                {
                    IEnemy enemy = enemies[e];
                    if (enemy.Health > 0)
                    {
                        enemy.ReceiveAttack(hero.AttackValue);
                    }

                    if (enemy.Health == 0)
                    {
                        hero.AddVictoryPoint(enemy.VictoryPoints);
                        if (hero.VictoryPoints >= 5)
                        {
                            hero.Cure();
                        }
                    }
                }
            }
        }
    }
}
