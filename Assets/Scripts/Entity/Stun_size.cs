using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stun_size : MonoBehaviour
{
    public bool stun = false;
    public float range = 5f;
    public Transform target;
    private int stun_time = 3;
    private int stimer = 0;

    private Text stunTextObject;

    // Start is called before the first frame update
    void Start()
    {
        stunTextObject = GameObject.Find("StunText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToEntity = Vector3.Distance(transform.position, target.position);
        if(distanceToEntity <= range && stimer == 0)
        {
            //Debug.Log("Dans la zone");
            InvokeRepeating("StunPlayer", 0, 1);
        }

    }

    void StunPlayer()
    {
        if(stimer < stun_time)
        {
            stimer++;
            //Debug.Log(stimer);
            //Debug.Log(stun_time);
            stun = true;
            stunTextObject.enabled = true;
        }
        else
        {
            stimer = 0;
            stun = false;
            stunTextObject.enabled = false;
            CancelInvoke("StunPlayer");
        }
    }
}

