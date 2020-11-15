using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Begin_Script : MonoBehaviour
{
    private Text textbox;
    public float timeRemaining = 120.0f;
    private bool verif = true;
    [SerializeField]
    private GameManagerScript GMScript = null;

    private void Start()
    {
        textbox = GetComponent<Text>();
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void startTimer()
    {
        if (verif)
        {
            verif = false;
            InvokeRepeating("updateText", 0f, 1f);
        }
    }

    void updateText()
    {
        timeRemaining--;
        textbox.text = timeRemaining.ToString();
        if(timeRemaining <= 0)
        {
            CancelInvoke("updateText");
            if (GMScript != null)
                GMScript.GameOver();
        }
    }
}
