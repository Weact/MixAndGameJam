using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UI_Input_Panel : MonoBehaviour
{
    private Button btnOK;
    private Button btnAnnuler;
    private Text Affichage;
    private Text Nombre;
    private InputField input;

    private void Start()
    {
        btnOK = transform.Find("ButtonOK").GetComponent<Button>();
        btnAnnuler = transform.Find("ButtonCancel").GetComponent<Button>();
        Affichage = transform.Find("Texte").GetComponent<Text>();
        Nombre = transform.Find("Numero").GetComponent<Text>();
        input = transform.Find("InputField").GetComponent<InputField>();
        input.characterLimit = 2;
        //Hide();
        Show();
        GenererAleatoire();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            OnOK();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnAnnuler();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        btnOK.onClick.AddListener(delegate { OnOK(); });
        btnAnnuler.onClick.AddListener(delegate { OnAnnuler(); });
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnOK()
    {
        if (input.text == Nombre.text)
        {
            Debug.Log("OK");
        }
        else
        {
            Debug.Log("Echec");
        }
        GenererAleatoire();
    }

    private void OnAnnuler()
    {
        input.text = "";
        GenererAleatoire();
    }

    private void GenererAleatoire()
    {
        var Unite = UnityEngine.Random.Range(0, 10);
        var Dizaine = UnityEngine.Random.Range(0, 10);
        Nombre.text = Unite.ToString()+Dizaine.ToString();
    }
}
