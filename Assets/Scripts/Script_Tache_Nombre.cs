using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Script_Tache_Nombre: MonoBehaviour
{
    private Button btnOK;
    private Button btnAnnuler;
    private Text Affichage;
    private Text Nombre;
    private InputField input;

    private bool bEnable = false;
    private bool bStart = false;
    private string sGreenNumber = "";
    private string sRedNumber = "";
    private string sBlueNumber = "";
    private int nSolution = 1;

    private void OnEnable()
    {
        //Debug.Log("Enable");
        Start();
        Cursor.lockState = CursorLockMode.Confined;
        Reinitialiser();
        bEnable = true;
        TacheStart();
    }

    private void OnDisable()
    {
        bEnable = false;
        Reinitialiser();
        //Debug.Log("Disable");
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        btnOK = transform.Find("ButtonOK").GetComponent<Button>();
        btnAnnuler = transform.Find("ButtonCancel").GetComponent<Button>();
        Affichage = transform.Find("Texte").GetComponent<Text>();
        Nombre = transform.Find("Numero").Find("NumeroTexte").GetComponent<Text>();
        input = transform.Find("InputField").GetComponent<InputField>();
        input.characterLimit = 2;
        //Hide();
        Show();
    }

    private void Reinitialiser()
    {
        //Debug.Log(Affichage);
        if (Affichage!=null)
            Affichage.text = "Remember the three Numbers";
        //Debug.Log(Nombre);
        if (Nombre!=null)
            Nombre.text = "0 0";
        input.text = "";
        sGreenNumber = "";
        sRedNumber = "";
        sBlueNumber = "";
        bStart = false;
    }

    private void TacheStart()
    {
        sGreenNumber = GenererAleatoire();
        sRedNumber = GenererAleatoire();
        sBlueNumber = GenererAleatoire();
        //Debug.Log("Vert " + sGreenNumber + " Bleu " + sBlueNumber + " Rouge " + sRedNumber);
        StartCoroutine(Melange(Time.time,1f,"SetRouge"));
    }

   
    private IEnumerator Melange(float Temps,float TempsMelange,string Fonction)
    {
        while ((Temps+TempsMelange)>Time.time && bEnable)
        {
            //Debug.Log("Melange");
            Nombre.text = GenererAleatoire();
            yield return new WaitForSeconds(0.05f);
        }
        //Debug.Log(Fonction);
        if (Fonction=="SetRouge" || Fonction == "SetBleu" || Fonction == "SetVert")
        {
            //Debug.Log("StartCoroutine "+Fonction+" depuis Melange.");
            if (bEnable)
                StartCoroutine(Fonction, Time.time);
        }
    }

    private IEnumerator MelangeInfini()
    {
        while (bStart && bEnable)
        {
            //Debug.Log("Melange");
            Nombre.text = GenererAleatoire();
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator SetRouge(float Temps)
    {
        //Debug.Log("Red");
        Nombre.color = Color.red;
        Nombre.text = sRedNumber;
        while (Temps + 1f > Time.time && bEnable)
        {
            yield return new WaitForSeconds(1f);
        }
        Nombre.color = Color.black;
        if (bEnable)
            StartCoroutine(Melange(Time.time, 1f, "SetBleu"));
    }

    private IEnumerator SetBleu(float Temps)
    {
        //Debug.Log("Blue");
        Nombre.color = Color.blue;
        Nombre.text = sBlueNumber;
        while (Temps + 1f > Time.time && bEnable)
        {
            yield return new WaitForSeconds(1f);
        }
        Nombre.color = Color.black;
        if (bEnable)
            StartCoroutine(Melange(Time.time, 1f, "SetVert"));
    }

    private IEnumerator SetVert(float Temps)
    {
        //Debug.Log("Green");
        Nombre.color = Color.green;
        Nombre.text = sGreenNumber;
        while (Temps + 1f > Time.time && bEnable)
        {
            yield return new WaitForSeconds(1f);
        }
        Nombre.color = Color.black;
        if (bEnable)
        {
            bStart = true;
            StartCoroutine(MelangeInfini());
            nSolution = UnityEngine.Random.Range(1, 3);
            switch (nSolution)
            {
                case 2:
                    if (Affichage != null)
                        Affichage.text = "What was the Blue Number ?";
                    break;
                case 3:
                    if (Affichage != null)
                        Affichage.text = "What was the Green Number ?";
                    break;
                default:
                    if (Affichage != null)
                        Affichage.text = "What was the Red Number ?";
                    break;
            }
        }
    }

    private void Update()
    {
        if (bStart)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                OnOK();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnAnnuler();
            }
            int number;
            if (int.TryParse(Input.inputString, out number))
            {
                input.text += Input.inputString;
            }
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
        string texteCible = "0 0";
        switch (nSolution)
        {
            case 2:
                texteCible = sBlueNumber;
                break;
            case 3:
                texteCible = sGreenNumber;
                break;
            default:
                texteCible = sRedNumber;
                break;
        }
        if (input.text.Length>1 && input.text[0]+" "+input.text[1] == texteCible)
        {
            if (Affichage != null)
                Affichage.text = "Congratulation !";
            bStart = false;
        }
        else
        {
            if (Affichage != null)
                Affichage.text = "Error. Try again.";
            input.text = "";
            //Nombre.text = GenererAleatoire();
        }
    }

    private void OnAnnuler()
    {
        input.text = "";
        //Nombre.text = GenererAleatoire();
    }

    private string GenererAleatoire()
    {
        var Unite = UnityEngine.Random.Range(0, 10);
        var Dizaine = UnityEngine.Random.Range(0, 10);
        return Unite.ToString() +" "+ Dizaine.ToString();
    }
}
