using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacingTask : MonoBehaviour
{
    public Transform playerTransform;
    private float timer = 0;
    private float maxTime = 30;
    public Text timeLeft;

    private void OnEnable()
    {
        Reset();
    }

    private void OnDisable()
    {
        Reset();
    }

    private void Reset()
    {
        timer = 0;
        playerTransform.SetPositionAndRotation(new Vector3(-94+446.875f, 146+238.125f, 0), Quaternion.Euler(0, 0, 90));
    }

    private void Update()
    {
        timer += Time.deltaTime;
        timeLeft.text = (Mathf.Round(maxTime - timer)).ToString();
        if (timer > maxTime)
        {
            GameObject.Find("PresentoirRacing").GetComponent<RacingManager>().Interact();
        }
    }

    private void OnTriggerEnter2D()
    {
        GameObject.Find("PresentoirRacing").GetComponent<RacingManager>().Interact();
    }

}
