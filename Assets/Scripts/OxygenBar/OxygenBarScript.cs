using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarScript : MonoBehaviour
{
    public int normal_reduction = 1;

    [SerializeField]
    private GameManagerScript GMScript = null;

    [SerializeField]
    private float timeRate = 1; //In second

    private Slider OxygenBar;
    private Text OxygenTextDisplay;

    [SerializeField]
    private GameObject DefeatObject = null;

    // Start is called before the first frame update
    void Start()
    {
        OxygenBar = GetComponent<Slider>();
        OxygenTextDisplay = GetComponent<Text>();
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
    
    public void Begin()
    {
        InvokeRepeating("SubstractPlayerOxygen", timeRate, timeRate); 
    }

    // Update is called once per frame
    void Update()
    {
        OxygenTextDisplay.text = OxygenBar.value.ToString();
    }

    void SubstractPlayerOxygen()
    {
        if(DefeatObject == null)
        {
            //Debug.LogError("DefeatObject is null, please setup one.");
            return;
        }
        if(OxygenBar.value <= 0 || DefeatObject.activeSelf)
        {
            //Debug.Log("Player's Oxygen has reached 0 !");
            CancelInvoke("substractPlayerOxygen");
            OxygenBar.value = 0;
            if (GMScript != null) GMScript.Defeat();
        }
        else
        {
            OxygenBar.value -= normal_reduction;
        }
    }
}
