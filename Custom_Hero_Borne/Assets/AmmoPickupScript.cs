using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupScript : MonoBehaviour
{
    public GameBehavior gameManager;
    public int AmmoAmount = 5;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("I have been collided!");
        if (col.gameObject.name == "Player")
        {
            Debug.Log("Item Collected");
            gameManager.Ammo += AmmoAmount;
            Destroy(gameObject);
        }

    }
}
