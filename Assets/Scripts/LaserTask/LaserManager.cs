using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserManager : MonoBehaviour
{

    public GameObject LaserTask;
    private Text InteractText = null;
    private bool bCanStart = false;
    private bool bStarted = false;
    private PlayerMovement PlayerMovement = null;
    private MouseLook MouseLook = null;

    [SerializeField]
    private bool bUsable = true;

    // Start is called before the first frame update
    void Start()
    {
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
            Interact();
        }
    }

    public void Interact()
    {
        bStarted = !bStarted;
        ActiveTache(bStarted);
        if (InteractText != null)
            InteractText.enabled = !bStarted;
    }

    private void ActiveTache(bool bStart)
    {
        if (LaserTask != null)
            LaserTask.SetActive(bStart);
        if (PlayerMovement != null)
            PlayerMovement.enabled = !bStart;
        if (MouseLook != null)
            MouseLook.enabled = !bStart;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bUsable)
        {
            if (InteractText != null)
                InteractText.enabled = true;
            bCanStart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (InteractText != null)
            InteractText.enabled = false;
        bCanStart = false;
        bStarted = false;
        ActiveTache(bStarted);
    }
}

