using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDieWin : MonoBehaviour
{
    public GameObject die;
    public GameObject fin;
    public GameObject player;
    [HideInInspector]
    static public bool dieP = false;
    static public bool finP = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dieP = false;
        finP = false;
    }
    private void Update()
    {
        if(player == null)
        {
            dieP = true;
            die.SetActive(true);
        }
        if (finP)
        {
            fin.SetActive(true);
        }
    }
}
