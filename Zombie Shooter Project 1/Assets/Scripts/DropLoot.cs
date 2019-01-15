using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLoot : MonoBehaviour {

    [System.Serializable]
    public class DropItem
    {
        public string name;
        public GameObject pickUps;
        public int dropRarity;
    }

    public List<DropItem> loot = new List<DropItem>();
    public int dropChance;

    public void calculateLoot()
    {
        // Calculates the drop chance between 1 to 100
        int calc_DropChance = Random.Range(0, 101);

        if (calc_DropChance > dropChance) 
        {
            Debug.Log(calc_DropChance);
            return;
        }

        if (calc_DropChance <= dropChance) 
        {
            int itemRarity = 0;

            for (int i = 0; i < loot.Count; i++)
            {
                itemRarity += loot[i].dropRarity;
            }
            Debug.Log("ItemRarity = " + itemRarity);

            int randomValue = Random.Range(0, itemRarity);

            for (int j = 0; j < loot.Count; j++)
            {
                if (randomValue <= loot[j].dropRarity)
                {
                    Instantiate(loot[j].pickUps, transform.position, Quaternion.identity);
                    return;
                }
                randomValue -= loot[j].dropRarity;
                Debug.Log("Random Value Decreased = " + randomValue);
            }
        }
    }
}
