using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public delegate void SpawnedEnemy(int theEnemyNum);
    public static event SpawnedEnemy OnSendEnemyNum;

    public GameObject prefabToSpawn;
    //public GameObject prefabBoss;
    //public Transform[] infected;

    public float adjustmentAngle = 0;

    public int updatenum;
    public int InfectedMaxCount = 10;
    public int CurrentInfectedNum = 1;

    public int CurrentSpawned;

    public void Spawn()
    {
        if (InfectedMaxCount >= CurrentInfectedNum)
        {
            Vector3 rotationInDegrees = transform.eulerAngles;
            rotationInDegrees.z += adjustmentAngle;

            Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
            GameObject obj = Instantiate(prefabToSpawn, transform.position, rotationInRadians);

            obj.transform.parent = transform;
            


            SendCurrentEnemyNum(CurrentInfectedNum);
            //print(CurrentInfectedNum + " has spawned");
            CurrentInfectedNum++;
            Counter();
        }
    }

    public void Dead()
    {
        //CurrentInfectedNum--;
        Counter();
    }

    public void Update()
    {
        updatenum = CurrentInfectedNum;

        
    }

    public void SendCurrentEnemyNum(int num)
    {
        if(OnSendEnemyNum != null)
        {
            OnSendEnemyNum(CurrentInfectedNum);
        }
    }

    public void Counter()
    {
        CurrentSpawned = transform.childCount;
        print(CurrentSpawned);
    }

} // Spawner
