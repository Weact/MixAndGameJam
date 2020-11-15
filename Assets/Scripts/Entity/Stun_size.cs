using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stun_size : MonoBehaviour
{
    public bool stun = false;
    public float range = 5f;
    public Transform target;
    private int stun_time = 5;
    private int stimer = 0;
    // Start is called before the first frame update
    void Start()
    {
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
        }
        else
        {
            stimer = 0;
            stun = false;
            CancelInvoke("StunPlayer");
        }
    }
}

