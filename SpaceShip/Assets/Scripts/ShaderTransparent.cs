using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTransparent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color color = new Color(255, 255, 255, 0.5f);
        gameObject.GetComponent<Renderer>().material.color = color;

    }
}
