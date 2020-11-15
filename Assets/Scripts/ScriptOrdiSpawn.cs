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
    private OxygenBarScript OxyScript = null;

    [SerializeField]
    private GameObject entity = null;

    private Begin_Script scriptTimer = null;
    private EntityBehavior scriptSpeed = null;

    private GameManagerScript GMScript = null;

    // Start is called before the first frame update
    void Start()
    {
        if(entity == null)
        {
            Debug.LogError("There is no entity in the game, please setup one.");
            return;
        }

        OxyScript = GameObject.Find("OxygenBar").GetComponent<OxygenBarScript>();
        scriptTimer = GameObject.Find("TimeRemainingText").GetComponent<Begin_Script>();

        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        scriptSpeed = GameObject.Find("EntityUnit").GetComponent<EntityBehavior>();
        scriptSpeed.speed = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && bCanStart && bUsable)
        {
            if (scriptTimer == null)
            {
                Debug.LogError("There is no Script assigned, please assign one.");
                return;
            }

            scriptSpeed.speed = 15;
            scriptSpeed.SetAgentProperties();
            scriptTimer.startTimer();

            if (PortesSpawn != null)
                PortesSpawn.SetActive(false);
            if (OxyScript != null)
                OxyScript.Begin();
            bUsable = false;
            if (InteractText != null)
                InteractText.enabled = false;
            GMScript.AfficheNbTache();
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