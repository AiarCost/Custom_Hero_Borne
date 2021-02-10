using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupScript : MonoBehaviour
{
    public GameBehavior gameManager;
    public int HealthAmount = 5;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {

            Debug.Log("Item Collected");
            gameManager.HP += HealthAmount;
            Destroy(gameObject);
        }

    }
}
