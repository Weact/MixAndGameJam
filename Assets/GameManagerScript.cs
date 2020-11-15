using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Fin = null;
    [SerializeField]
    private GameObject Victoire = null;

    private Text AfficheTaches = null;

    public bool bTache1 = false;
    public bool bTache2 = false;
    public bool bTache3 = false;

    // Start is called before the first frame update
    void Start()
    {
        AfficheTaches = GameObject.Find("TexteSpawn").GetComponent<Text>();
    }

    public void AfficheNbTache()
    {
        string Affiche = CompteBool().ToString() + "/3";
        AfficheTaches.text = Affiche;
    }

    private int CompteBool()
    {
        int n = 0;
        if (bTache1)
            n++;
        if (bTache2)
            n++;
        if (bTache3)
            n++;
        Debug.Log(n);
        return n;
    }

    public void GameOver()
    {
        if (bTache1 && bTache2 && bTache3)
        {
            Victory();
        }
        else
        {
            Defeat();
        }
    }

    public void Defeat()
    {
        if (Fin != null)
            Fin.SetActive(true);
    }

    private void Victory()
    {
        if (Victoire != null)
            Victoire.SetActive(true);
    }
}
