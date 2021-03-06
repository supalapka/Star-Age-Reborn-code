using Assets.Scipts;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string Name { get; set; }
    private int maxHealth = Core.spaceship.MaxHP;
    private int currentHealth = Core.spaceship.MaxHP;

    //spaceship inventory
    public Inventory _Inventory;
    public RectTransform ItemsPanel;
    public RectTransform SlotViewPanel;

    private int maxExp = 60; // temp
    private int currentExp = 0; //temp

    public HealthBar HP_Bar;
    public ExpBar Exp_Bar;

    public void Awake()
    {
        Name = GetComponentInChildren<Collider>().name;
        // Name = "supalapka";
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
