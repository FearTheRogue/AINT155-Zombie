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

    public Transform t;
    //public Text CurrentSpawnedText;

    public void Start()
    {

        t = transform.GetComponent<Transform>();
        
    }
    public void Spawn()
    {
        if (InfectedMaxCount >= CurrentInfectedNum + 1)
        {
            Vector3 rotationInDegrees = transform.eulerAngles;
            rotationInDegrees.z += adjustmentAngle;

            Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);
            GameObject obj = Instantiate(prefabToSpawn, transform.position, rotationInRadians);

            obj.transform.parent = transform;
            
            SendCurrentEnemyNum(CurrentInfectedNum);

            CurrentInfectedNum++;
            
        }
        //Counter();
    }

    public void Dead()
    {
        //CurrentInfectedNum--;
        //Counter();
    }

    public void Update()
    {
        //updatenum = CurrentInfectedNum;

        //CurrentSpawned = transform.childCount;

        //if (CurrentSpawnedText != null)
        //    CurrentSpawnedText.text = "Infected Left: " + CurrentSpawned;
    }

    public void FixedUpdate()
    {
        updatenum = CurrentInfectedNum;

        CurrentSpawned = transform.childCount;

        //if (CurrentSpawnedText != null)
          //  CurrentSpawnedText.text = "Infected Left: " + CurrentSpawned;
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

        //if(CurrentSpawnedText != null)
        //CurrentSpawnedText.text = "Infected Left: " + CurrentSpawned;
        //print(CurrentSpawned);
    }


} // Spawner
