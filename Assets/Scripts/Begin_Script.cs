using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Begin_Script : MonoBehaviour
{
    private Text textbox;
    public float timeReaming = 30.0f;
    private bool verif = true;
    [SerializeField]
    private GameObject Fin = null;

    private void Start()
    {
        textbox = GetComponent<Text>();   
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && verif)
        {
            verif = false;
            InvokeRepeating("updateText", 0f, 1f);

        }

    }

    void updateText()
    {
        timeReaming--;
        textbox.text = timeReaming.ToString();
        if(timeReaming <= 0)
        {
            CancelInvoke("updateText");
            if (Fin != null)
                Fin.SetActive(true);
        }
    }
}
