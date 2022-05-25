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
        public string Id { get; set; }
        public GameObject minerGameObject;
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public Transform transform { get; set; }
        float moveSpeed = 0.4f;
        public HealthBar HealthBar { get; set; } //remove
        public bool canFollow = false;


        public Miner()
        {
            SetMaxHealth(100);
        }

        public void SetMaxHealth(int h)
        {
            MaxHealth = h;
            CurrentHealth = h;
        }

        public void Damage(string damagedBy, int dmg)
        {
            CurrentHealth -= dmg;
            Debug.Log(CurrentHealth);
            if (CurrentHealth <=0)
            {
                destroy();
                PlayersOnMap.AddExpToPlayer(damagedBy, 10);
            }
        }
        private void destroy()
        {
            minerGameObject.transform.position = new Vector3(0, 5000, 0);
            System.Threading.Thread.Sleep(200);
            minerGameObject.SetActive(false);
            MinersOnMap.RemoveMiner(this);
        }

        public void  Follow(Vector3 targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
