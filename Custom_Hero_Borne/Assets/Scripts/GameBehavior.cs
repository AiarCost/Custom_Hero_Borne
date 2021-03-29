using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public string labelText = "Collect all 4 items and win your freedom!";
    public int EnemyAlive = 1;
    public bool Invulnerable = false;
    public float Timer = 0f;

    private int _EnemyKilled = 0;

    public GameObject HealthText;
    public GameObject AmmoText;
    public GameObject RestartButton;
    public GameObject LossPanel;
    public GameObject WinPanel;
    public GameObject InvulerabilityPanel;
    public Text Restart;

    SceneBehavior Scene;
    

    public void Start()
    {
        HealthText = GameObject.Find("HealthText");
        AmmoText = GameObject.Find("AmmoText");
        HealthText.GetComponent<Text>().text = _playerHP.ToString();
        AmmoText.GetComponent<Text>().text = AmmoAmount.ToString();
        Scene = GameObject.Find("SceneManager").GetComponent<SceneBehavior>();
    }

    public void FixedUpdate()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
            InvulerabilityPanel.SetActive(true);
        }
        else
        {
            InvulerabilityPanel.SetActive(false);
            Invulnerable = false;
        }
    }

    public int EnemyKilled
    {
        get { return _EnemyKilled; }

        set
        {
            _EnemyKilled = value;
            Debug.LogFormat("Killed: {0}", _EnemyKilled);

            if(_EnemyKilled >= EnemyAlive)
            {
                //Restart.text = "You've killed all the enemy!";
                //showWinScreen = true;
                //Time.timeScale = 0f;
                //WinPanel.SetActive(true);
                //RestartButton.SetActive(true);
                Scene.WinGame();
            }
            else
            {
                labelText = "Enemy kiled, only " + (EnemyAlive - _EnemyKilled) + " more to go!";
            }
        }
    }

    private int _playerHP = 10;

    public int HP
    {
        get { return _playerHP; }

        set
        {
            if (!Invulnerable)
            {
                _playerHP = value;
                HealthText.GetComponent<Text>().text = value.ToString();
                if (_playerHP <= 0)
                {
                    //Debug.Log("I lost!!!");
                    //showLossScreen = true;
                    //Time.timeScale = 0;
                    //Restart.text = "You want another life with that?".ToString();
                    //LossPanel.SetActive(true);
                    //RestartButton.SetActive(true);

                    Scene.LoseGame();
                }
            }
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

    public void RestartLevel()
    {

        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;

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
