using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickupScript : MonoBehaviour
{
    public GameBehavior gameManager;
    public int AmmoAmount = 5;
    AudioSource AudioPlayer;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        AudioPlayer = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.name == "Player")
        {
            AudioPlayer.Play();
            gameManager.Ammo += AmmoAmount;
            Destroy(gameObject);
        }

    }
}
