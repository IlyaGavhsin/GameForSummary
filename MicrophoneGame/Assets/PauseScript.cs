using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public Text tx;
    private void Start()
    {
        tx = GetComponent<Text>();
    }
    void Update()
    {
        if (TextScript._IsPause)
        {
            tx.text = "Пауза";
        }
        if (!TextScript._IsPause)
        {
            tx.text = "Игра";
        }
    }
}
