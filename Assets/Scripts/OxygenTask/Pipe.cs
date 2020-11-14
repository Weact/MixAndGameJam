using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pipe : MonoBehaviour
{
    Color colorActive =  new Color(0.5f, 1f, 0f);
    Color colorOff= new Color(1f, 0.5f, 0f);

    public bool startingState;
    public bool answerState;

    [HideInInspector]
    public bool state;
    public void SwitchState()
    {
        state = !state;
        ChangeColor();
    }

    void ChangeColor()
    {
        if (state)
        {
            GetComponent<Image>().color = colorActive;
        } else
        {
            GetComponent<Image>().color = colorOff;
        }
    }

    public bool CompareAnswer()
    {
        return (state == answerState);
    }

    public void Start()
    {
        state = startingState;
        ChangeColor();
    }
}
