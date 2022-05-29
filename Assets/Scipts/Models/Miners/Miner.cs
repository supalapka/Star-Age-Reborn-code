using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Models.Miners
{
    public abstract class Miner
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
        protected List<Item> dropItems = new List<Item>();

        public void SetMaxHealth(int h)
        {
            MaxHealth = h;
            CurrentHealth = h;
        }

        public void Damage(string damagedBy, int dmg)
        {
            CurrentHealth -= dmg;
            healthBar.SetHealth(CurrentHealth);
            if (CurrentHealth <= 0)
            {
                destroy();
                PlayersOnMap.AddExpToPlayer(damagedBy, 10);
            }
        }
        private void destroy()
        {
            var saveMinerPosition = minerGameObject.transform.position;
            minerGameObject.transform.position = new Vector3(0, 5000, 0);
            MinersOnMap.RemoveMiner(this);

            //drop settings
            var drop = new GameObject();

            //box collider for drop
            BoxCollider boxCollider = drop.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            boxCollider.size = new Vector3(5f, 5f, 5f); 
            drop.tag = "Item";

            //rigid body for drop
            Rigidbody dropRB = drop.AddComponent<Rigidbody>();
            dropRB.useGravity = false;

            //image for drop
            SpriteRenderer renderer = drop.AddComponent<SpriteRenderer>();
            renderer.sprite = dropItems[0].Image;

            BotLvl1.DropItemsAfterDeath(drop, saveMinerPosition);
            minerGameObject.SetActive(false);

        }

        public void Follow(Vector3 targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
