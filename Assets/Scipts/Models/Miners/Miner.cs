using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Models.Miners
{
    public class Miner
    {
        public HealthBar healthBar;
        public string Id { get; set; }
        public GameObject minerGameObject;
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public Transform transform { get; set; }
        float moveSpeed = 0.4f;
        public HealthBar HealthBar { get; set; } //remove
        public bool canFollow = false;


        public Miner(HealthBar healthBar)
        {
            MaxHealth = 100;
            SetMaxHealth(MaxHealth);
            HealthBar = healthBar;
            healthBar.SetMaxHealth(MaxHealth);
        }

        public void SetMaxHealth(int h)
        {
            MaxHealth = h;
            CurrentHealth = h;
        }

        public void Damage(string damagedBy, int dmg)
        {
            CurrentHealth -= dmg;
            healthBar.SetHealth(CurrentHealth);
            if (CurrentHealth <=0)
            {
                destroy();
                PlayersOnMap.AddExpToPlayer(damagedBy, 10);
            }
        }
        private void destroy()
        {
            minerGameObject.transform.position = new Vector3(0, 5000, 0);
            MinersOnMap.RemoveMiner(this);
            minerGameObject.SetActive(false);
        }

        public void  Follow(Vector3 targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
