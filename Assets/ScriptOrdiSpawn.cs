using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptOrdiSpawn : MonoBehaviour
{
    private bool bUsable = true;
    private bool bCanStart = false;
    [SerializeField]
    private Text InteractText = null;
    [SerializeField]
    private GameObject PortesSpawn = null;
    private OxygenBarScript OxyScript=null;

    // Start is called before the first frame update
    void Start()
    {
        OxyScript = GameObject.Find("OxygenBar").GetComponent<OxygenBarScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && bCanStart && bUsable)
        {
            if (PortesSpawn != null)
                PortesSpawn.SetActive(false);
            if (OxyScript != null)
                OxyScript.Begin();
            bUsable = false;
            if (InteractText != null)
                InteractText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bUsable)
        {
            //Debug.Log(other.name+" entre.");
            if (InteractText != null)
                InteractText.enabled = true;
            bCanStart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.name + " sort.");
        if (InteractText != null)
            InteractText.enabled = false;
        bCanStart = false;
    }
}
