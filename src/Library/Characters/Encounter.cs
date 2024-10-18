namespace Ucu.Poo.RoleplayGame;


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
        while (heroes.Count > 0 && enemies.Count > 0)
        {
            EnemiesAttack();
            if (heroes.Count > 0)
            {
                HeroesAttack();
            }
            CheckVictory();
        }
    }
    /// <summary>
    /// El enemigo 1 ataca al heroe 1 y así sucesivamente, si el heroe se qeuda sin vida se remueve de la lista
    /// </summary>
    private void EnemiesAttack()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            IEnemy enemy = enemies[i];
            // i % heroes.Count lo que hace es que si la cantidad de heroes es menor va a ir al inicio de la lista
            ICharacter Hero = heroes[i % heroes.Count];
            Hero.ReceiveAttack(enemy.AttackValue);
            if (Hero.Health == 0)
            {
                heroes.Remove(Hero);
            }
        }
    }
    /// <summary>
    /// El heroe ataca al enemigo si el enemigo se queda sin vida, el heroe gana los VictoryPoints del enemigo
    /// </summary>
    private void HeroesAttack()
    {
        foreach (ICharacter hero in heroes)
        {
            foreach (IEnemy enemy in enemies)
            {
                enemy.ReceiveAttack(hero.AttackValue);
                if (enemy.Health == 0)
                {
                    hero.AddVictoryPoint(enemy.VictoryPoints);
                    enemies.Remove(enemy);
                }
            }

            // Curar al héroe si tiene 5+ VP
            if (hero.VictoryPoints >= 5)
            {
                hero.Cure();
            }
        }
    }
    /// <summary>
    /// Si todos los heroes se quedan sin vida o todos los enemigos, muestra un mensaje diciendolo
    /// </summary>
    private void CheckVictory()
    {
        if (heroes.Count == 0)
        {
            Console.WriteLine("Todos los héroes han muerto. Los enemigos ganan.");
        }
        else if (enemies.Count == 0)
        {
            Console.WriteLine("Todos los enemigos han muerto. Los héroes ganan.");
        }
    }
}

