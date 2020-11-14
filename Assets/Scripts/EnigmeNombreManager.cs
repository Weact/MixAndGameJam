using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnigmeNombreManager : MonoBehaviour
{
    private Script_Tache_Nombre ScriptJeu =null;
    //private CapsuleCollider Collider;
    private Text InteractText=null;
    private bool bCanStart=false;
    private bool bStarted = false;
    private PlayerMovement PlayerMovement=null;
    private MouseLook MouseLook=null;

    [SerializeField]
    private bool bUsable = true;

    // Start is called before the first frame update
    void Start()
    {
        ScriptJeu = transform.Find("Table").Find("CanvasTache").Find("Panel").GetComponent<Script_Tache_Nombre>();
        //Collider = transform.GetComponent<CapsuleCollider>();
        InteractText = GameObject.Find("InteractText").GetComponent<Text>();
        InteractText.enabled = false;
        GameObject Player = GameObject.Find("Player");
        PlayerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        MouseLook = GameObject.Find("PlayerCamera").GetComponent<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.F) && bCanStart && bUsable)
       {
            bStarted = !bStarted;
            ActiveTache(bStarted);
            if (InteractText != null)
                InteractText.enabled = !bStarted;
            //Debug.Log("Activation.");
        }
    }

    private void ActiveTache(bool bStart)
    {
        if (ScriptJeu != null)
            ScriptJeu.enabled = bStart;
        if (PlayerMovement != null)
            PlayerMovement.enabled = !bStart;
        if (MouseLook != null)
            MouseLook.enabled = !bStart;
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
        bStarted = false;
        ActiveTache(bStarted);
    }
}
