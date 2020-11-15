using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashLight : MonoBehaviour
{
    public float intensity = 1;
    public float range = 10;

    public GameObject flashLight;
    private Transform flashLightProperties;

    public GameObject playerCamera;
    private Transform playerCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        flashLightProperties = flashLight.GetComponent<Transform>();
        playerCameraTransform = playerCamera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        flashLightProperties.rotation = playerCameraTransform.rotation;
        if (Input.GetKeyDown(KeyCode.Q)) ToggleTorchLight();
    }

    void ToggleTorchLight()
    {
        flashLight.SetActive(!flashLight.activeSelf);
    }
}
