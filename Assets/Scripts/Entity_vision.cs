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

        Vector3 fovline1 = Quaternion.AngleAxis(fangleInfo, transform.up) * transform.forward * fviewRadius;
        Vector3 fovline2 = Quaternion.AngleAxis(-fangleInfo, transform.up) * transform.forward * fviewRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovline1);
        Gizmos.DrawRay(transform.position, fovline2);

        Gizmos.color = Color.red;

        float fanglePlayer = Mathf.Atan2(player.position.x-transform.position.x, player.position.z-transform.position.z) * Mathf.Rad2Deg;

        Gizmos.DrawRay(transform.position, Quaternion.AngleAxis(fanglePlayer, transform.up) * transform.forward * fviewRadius);

    }

    public static bool Invision(Transform checkingObject, Transform target, float fviewRadius,float fangleInfo)
    {
        bool verif = false;
        float distanceToEntity = Vector3.Distance(checkingObject.position, target.position);
        if(distanceToEntity <= fviewRadius)
        {
            float fanglePlayer = Mathf.Atan2(target.position.x -checkingObject.position.x, target.position.z - checkingObject.position.z) * Mathf.Rad2Deg;
            if (fanglePlayer <= fangleInfo && fanglePlayer >= -fangleInfo)
            {
                verif = true;
            }
        }

      return verif;
    }


    private void Update()
    {
        isInvision = Invision(transform, player, fviewRadius,fangleInfo);

        if(isInvision)
        {
            RenderSettings.fogDensity = 0.25f;
        }
        else
        {
            RenderSettings.fogDensity = 0.15f;
        }
    }
}

    
