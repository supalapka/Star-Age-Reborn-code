using System.Collections.Generic;
using System.Linq;
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
            dropLoot(saveMinerPosition);
            minerGameObject.SetActive(false);

        }

        private void dropLoot(Vector3 minerPOsition)
        {
            //drop settings
            var drop = new GameObject();
            var codename = FunctionsLib.RandomString(6);
            drop.name = dropItems[0].name + codename;

            //box collider for the drop
            BoxCollider boxCollider = drop.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            boxCollider.size = new Vector3(5f, 5f, 5f);

            drop.tag = "Item";

            //scale
            drop.transform.localScale = new Vector3(0.071922f, 0.071922f, 0.071922f);

            //rigid body for the drop
            Rigidbody dropRB = drop.AddComponent<Rigidbody>();
            dropRB.useGravity = false;

            //image for the drop
            SpriteRenderer renderer = drop.AddComponent<SpriteRenderer>();
            renderer.sprite = dropItems[0].Image;

            BotLvl1.DropItemsAfterDeath(drop, minerPOsition);
        }

         
      

        public void Follow(Vector3 targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
