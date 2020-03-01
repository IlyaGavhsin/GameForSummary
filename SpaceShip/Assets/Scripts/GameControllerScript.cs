using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public int Health;

    public GameObject firsIconHealth;
    public GameObject secondIconHealth;
    public GameObject thirdIconHealth;

    public UnityEngine.UI.Text scoreTextElemnt;
    public UnityEngine.UI.Button startButton;
    public GameObject menu;

    public UnityEngine.UI.Text gameOverText;
    public GameObject gameObGameOver;
    public Transform startPosGameOverText;
    private bool IsDestroy = false;

    public UnityEngine.UI.Button RestartBotton;
    public GameObject RestartBottonGO;

    public GameObject player;
    public Transform startPositionPlayer;

    private int score = 0;

    public BorderSpown fallenIconOb;
    

    private bool getStarted;
     void Start()
    {
        scoreTextElemnt.text = "Score: ";
        startButton.onClick.AddListener(delegate
        {
            getStarted = true;
            menu.SetActive(false);
        });
        RestartBotton.onClick.AddListener(delegate
        {

            getStarted = true;
            score = 0;
            scoreTextElemnt.text = "Score:" + score;
            RestartBottonGO.SetActive(false);
            Instantiate(player,this.startPositionPlayer.position, Quaternion.identity);
            gameObGameOver.SetActive(false);
            gameObGameOver.transform.position = this.startPosGameOverText.position;
            Health = 99;
            InistiateIconHEalth(1);
            InistiateIconHEalth(2);
            InistiateIconHEalth(3);
            
        });
    }
     void Update()
    {
        AnimationGAmeOverText();
    }
    public void increasScore(int increment)
    {
        score += increment;
        scoreTextElemnt.text = "Score:" + score;
    }
    public bool getIsStarted()
    {
        return getStarted;
    }
    public void ChangeBool(bool a)
    {
        getStarted = a;
    }
    public void ActiveGameOverText()
    {
        gameObGameOver.SetActive(true);
    }
    public void AnimationGAmeOverText()
    {
        if(gameOverText.rectTransform.position.y < 0f & IsDestroy == false)
        {
            Destroy(gameOverText);
            IsDestroy = true;
        }
    }
    public void MinusHealth(int minus)
    {
        Debug.Log("--------------------------------------");
        Debug.Log(Health);
        Health = Health - minus;
        Debug.Log(Health);
        Debug.Log(minus);
        Debug.Log("--------------------------------------");

    }
    public void DestroyIconHEalth(int numbIcon)
    {
        switch (numbIcon)
        {
            case 1:
                firsIconHealth.SetActive(false);
                break;
            case 2:
                secondIconHealth.SetActive(false);
                break;
            case 3:
                thirdIconHealth.SetActive(false);
                break;
        }
    }
    public void InistiateIconHEalth(int numbIcon)
    {
        switch (numbIcon)
        {
            case 1:
                firsIconHealth.SetActive(true);
                break;
            case 2:
                secondIconHealth.SetActive(true);
                break;
            case 3:
                thirdIconHealth.SetActive(true);
                break;
        }
    }

}
