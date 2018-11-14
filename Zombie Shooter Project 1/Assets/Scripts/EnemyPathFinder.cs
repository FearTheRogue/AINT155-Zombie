using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPathFinder : MonoBehaviour {

    public Transform target;
    private IAstarAI ai;

	// Use this for initialization
	private void Start () {
        ai = GetComponent<IAstarAI>();
	}

	// Update is called once per frame
	private void Update () {
		if (target != null && ai != null)
        {
            ai.destination = target.position;
            ai.SearchPath();
        }
	}

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
} // EnemyPathFinder
