﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviorScript : MonoBehaviour
{
    public Transform player;

    public Transform patrolRoute;
    public List<Transform> locations;
    private int locationIndex = 0;
    private NavMeshAgent agent;
    private GameBehavior GameManager;
    public bool Attacking = false;

    private int _lives = 3;
    public int EnemyLives
    {
        get { return _lives; }

        private set
        {
            _lives = value;

            if(_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("EnemyDown");
                GameManager.EnemyKilled += 1;
            }
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        GameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    private void Update()
    {
        if(agent.remainingDistance<0.2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in patrolRoute)
        {
            locations.Add(child);
        }

    }

    void MoveToNextPatrolLocation()
    {
        if (Attacking)
        {
            agent.destination = player.position;
        }
        else
        {
            if (locations.Count == 0)
            {
                return;
            }
            agent.destination = locations[locationIndex].position;

            locationIndex = (locationIndex + 1) % locations.Count;
        }
    }


    void OnTriggerEnter(Collider col)
    {
        Attacking = true;
        agent.destination = player.position;
        if (col.name == "Player")
            Debug.Log("Player Detected - attack!");
        
    }

    void OnTriggerExit(Collider col)
    {
        Attacking = false;
        if (col.name == "Player")
            Debug.Log("Player out of range, resume patrol");

    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical Hit!");
        }
    }

}
