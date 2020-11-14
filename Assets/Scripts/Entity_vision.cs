using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_vision : MonoBehaviour
{
    public Transform player;
    public float fviewRadius;
    public float fangleInfo;

    private bool isInvision = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fviewRadius);
    }

    public static bool Invision(Transform checkingObject, Transform target, float fviewRadius)
    {
        bool verif = false;
        float distanceToEntity = Vector3.Distance(checkingObject.position, target.position);
        if(distanceToEntity <= fviewRadius)
        {
            verif = true;
        }

      return verif;
    }


    private void Update()
    {
        isInvision = Invision(transform, player, fviewRadius);

        if(isInvision)
        {
            Debug.Log("In vision");
        }
        else
        {
            Debug.Log("Not IN vision");
        }
    }
}

    
