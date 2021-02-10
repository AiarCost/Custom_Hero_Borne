using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {

        if (col.name == "Player")
            Debug.Log("Player Detected - attack!");
        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.name == "Player")
            Debug.Log("Player out of range, resume patrol");

    }

}
