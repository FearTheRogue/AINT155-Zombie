using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject prefabToSpawn;
    //public GameObject prefabBoss;

    public float adjustmentAngle = 0;

    public int InfectedMaxCount = 10;
    public int CurrentInfectedNum = 0;

    public float boundX = 1.2f;
    public float boundY = 1.2f;

    public void Spawn()
    {
        Vector3 rotationInDegrees = transform.eulerAngles;
        rotationInDegrees.z += adjustmentAngle;

        Quaternion rotationInRadians = Quaternion.Euler(rotationInDegrees);

        if(InfectedMaxCount > CurrentInfectedNum)
        {
            Instantiate(prefabToSpawn, transform.position, rotationInRadians);
            CurrentInfectedNum++;

            if (CurrentInfectedNum == 5)
            {
                //Instantiate(prefabBoss, transform.position, rotationInRadians);
            }

        } 
        //{
        //    Instantiate(prefabToSpawn, transform.position, rotationInRadians);
        //}
    }
} // Spawner
