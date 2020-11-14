using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerifyPipe : MonoBehaviour
{
    public Slider oxygen;
    public Slider player;
    public Pipe[] pipes;
    public Text fail;

    private bool validate;
    private float timer = 0;
    private Color validColor;

    // Start is called before the first frame update
    void Start()
    {
        validColor = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (validate) { 
            timer += Time.deltaTime;
            if (timer > 0.01)
            {
                oxygen.value--;
                player.value++;
                timer = 0;
            }
        }

        if (player.value == player.maxValue)
        {
            validate = false;
            oxygen.value = 0;
            timer = 0;
        }
    }

    public void ValidatePipe()
    {
        bool verif = true;
        int i = 0;
        while (i < pipes.Length && verif)
        {
            if (!pipes[i].CompareAnswer())
            {
                verif = false;
            }
            i++;
        }
        if (verif)
        {
            validate = true;
        } else
        {
            StartCoroutine(FadeTextToZeroAlpha(2, fail));
            
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, Text i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }

}
