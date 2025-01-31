﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviorScript : MonoBehaviour
{

    public GameBehavior gameManager;
    AudioSource AudioPlayer;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        AudioPlayer = GetComponent<AudioSource>();

    }

    void OnTriggerEnter (Collider col)
    {

        if(col.gameObject.name == "Player")
        {

            Destroy(transform.parent.gameObject);
            Debug.Log("Item Collected");

            //gameManager.Items += 1;
        }

    }

}
