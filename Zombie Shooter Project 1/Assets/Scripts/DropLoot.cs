using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour {

    // Makes it accessable in the inspector 
    [System.Serializable]
    public class DropItem
    {
        public string name;
        public GameObject pickUps;
        public int dropRarity;
    }

    // creates a new list
    public List<DropItem> loot = new List<DropItem>();
    // creates an int 
    public int dropChance;

    public void calculateLoot()
    {
        // Calculates the drop chance between 1 to 100
        int calc_DropChance = Random.Range(0, 101);

        // if the calc_dropChance is bigger than the dropchance (set in the inspector) nothing will spawn
        if (calc_DropChance > dropChance) 
        {
            return;
        }

        // if the calc_dropchance is less than or = to the dropchance
        if (calc_DropChance <= dropChance) 
        {
            int itemRarity = 0;

            // Cycles through the list 
            for (int i = 0; i < loot.Count; i++)
            {
                // adds the dropRarity, that is set in the inspector, and adds it up 
                itemRarity += loot[i].dropRarity;
            }
            // creates a random value between 0 and the itemRarity(that was added up)
            int randomValue = Random.Range(0, itemRarity);

            // goes through again
            for (int j = 0; j < loot.Count; j++)
            {
                // if the randomValue is less than or = to the items dropRarity it spawns that item 
                if (randomValue <= loot[j].dropRarity)
                {
                    //then returns if none of the items rarity is less than the value
                    Instantiate(loot[j].pickUps, transform.position, Quaternion.identity);
                    return;
                }
                randomValue -= loot[j].dropRarity;
            }
        }
    }
}
