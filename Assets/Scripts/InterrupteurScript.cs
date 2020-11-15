using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterrupteurScript : MonoBehaviour
{
    private bool bCanStart = false;
    [SerializeField]
    private GameObject Lumieres = null;
    [SerializeField]
    private Text InteractText = null;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && bCanStart)
        {
            Allumer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (InteractText != null)
            InteractText.enabled = true;
        bCanStart = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (InteractText != null)
            InteractText.enabled = false;
        bCanStart = false;
    }

    private void Allumer()
    {
        if (Lumieres!=null)
        {
            Lumieres.SetActive(!Lumieres.activeSelf);
        }
    }
}
