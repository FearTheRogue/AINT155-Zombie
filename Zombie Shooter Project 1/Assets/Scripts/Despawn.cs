﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour {
        
    public void ForceTimeout()
    {
        Destroy(gameObject);
    }
}
