using NUnit.Framework;
using UnityEngine;

public class CombatTest
{
    private Enemy enemy;
    private PlayerMotor player;

    [SetUp]
    public void Setup()
    {
        player = new GameObject().AddComponent<Player>();
        enemy = new GameObject().AddComponent<Enemy>();

        player.attackDamage = 10;
        enemy.health = 50;
    }

    [Test]
    public void AttackEnemy_DecreasesHealth()
    {
        player.Attack(enemy);
        Assert.AreEqual(40, enemy.health);
    }

    [Test]
    public void AttackEnemy_KillsEnemy_WhenHealthZero()
    {
        player.attackDamage = 50;
        player.Attack(enemy);
        Assert.AreEqual(0, enemy.health);
    }

    [Test]
    public void AttackEnemy_DoesNotReduceHealthBelowZero()
    {
        player.attackDamage = 100;
        player.Attack(enemy);
        Assert.AreEqual(0, enemy.health);
    }
}
