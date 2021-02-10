using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;

    private int _itemsCollected = 0;

    public GameObject HealthText;
    public GameObject AmmoText;

    public void Start()
    {
        HealthText = GameObject.Find("HealthText");
        AmmoText = GameObject.Find("AmmoText");
    }

    public int Items
    {
        get { return _itemsCollected; }

        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if(_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    private int _playerHP = 10;

    public int HP
    {
        get { return _playerHP; }

        set
        {
            _playerHP = value;
            HealthText.GetComponent<Text>().text = value.ToString();
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    private int AmmoAmount = 15;
    public int Ammo
    {
        get { return AmmoAmount; }

        set
        {
            AmmoAmount = value;
            AmmoText.GetComponent<Text>().text = value.ToString();
           // Debug.Log("Ammo Collected");

        }
    }

   /* void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Heath: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected " + _itemsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if(GUI.Button(new Rect(Screen.width/2 - 100, Screen.height/2-50, 200, 100), "You Win!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }

        }

    }*/
}
