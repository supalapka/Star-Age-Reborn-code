using Assets.Scipts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; set; }
    private int maxHealth = Core.spaceship.MaxHP;
    private int currentHealth = Core.spaceship.MaxHP;
    private int maxExp = 100; // temp
    private int currentExp = 0; //temp

    public HealthBar HP_Bar;
    public ExpBar Exp_Bar;

    public void Start()
    {
        Name = GetComponentInChildren<Collider>().name;
        Debug.Log(Name);
        Exp_Bar.SetExp(currentExp);
        PlayersOnMap.Players.Add(this);
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        HP_Bar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            //destroy
        }
    }

    public void AddExp(int exp)
    {
        currentExp += exp;
        Exp_Bar.SetExp(currentExp);
        if (currentExp >= maxExp)
        {
            //lvl up
        }
    }

    public int GetHealth() { return currentHealth; }
    public int GetMaxHealth() { return maxHealth; }
    public int GetExp() { return currentExp; }

}
