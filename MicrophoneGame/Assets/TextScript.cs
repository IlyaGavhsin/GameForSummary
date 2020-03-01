using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour
{
    public Text tx;
    static public bool _IsPause = true;

    private void Start()
    {
        tx = GetComponent<Text>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioS.sensitivity += 10.0f;
            tx.text = "Чувствительность: " + audioS.sensitivity.ToString();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioS.sensitivity -= 10.0f;
            tx.text = "Чувствительность: " + audioS.sensitivity.ToString();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tx.text = null;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tx.text = "Чувствительность: " + audioS.sensitivity.ToString();
        }
        if (Input.GetKey("escape"))
            Application.Quit();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
        PutEnter();

    }
    void PutEnter()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_IsPause)
            {
                _IsPause = false;
                return;
            }
            else
            {
                _IsPause = true;
                return;
            }
        }
    }

}
