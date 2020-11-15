using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DefeatScript : MonoBehaviour
{
    private PlayerMovement ScriptMouvement=null;

    // Start is called before the first frame update
    void Start()
    {
        ScriptMouvement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScriptMouvement != null)
            ScriptMouvement.enabled = false;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void OnEnable()
    {
        if (ScriptMouvement != null)
            ScriptMouvement.enabled = false;
    }

    private void OnDisable()
    {
        if (ScriptMouvement != null)
            ScriptMouvement.enabled = true;
    }
}
