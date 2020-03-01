using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScence()
    {
        SceneManager.LoadScene("SampleScene");

        UIDieWin.dieP = false;
        UIDieWin.finP = false;
    }
}
