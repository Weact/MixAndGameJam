using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarScript : MonoBehaviour
{
    public int normal_reduction = 1;

    [SerializeField]
    private float timeRate = 1; //In second

    private Slider OxygenBar;
    private Text OxygenTextDisplay;

    [SerializeField]
    private GameObject Fin = null;

    // Start is called before the first frame update
    void Start()
    {
        OxygenBar = GetComponent<Slider>();
        OxygenTextDisplay = GetComponent<Text>();
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
        if(OxygenBar.value > 0)
        {
            OxygenBar.value -= normal_reduction;
        }
        else
        {
            Debug.Log("Player's Oxygen has reached 0 !");
            CancelInvoke("substractPlayerOxygen");
            if (Fin != null)
                Fin.SetActive(true);
        }
    }
}
