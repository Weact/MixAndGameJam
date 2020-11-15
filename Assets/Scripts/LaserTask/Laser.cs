using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    GameManagerScript GMScript = null;

    // Use this for initialization
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        GMScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


// Update is called once per frame
    void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        if (hit.collider)
        {
            _lineRenderer.SetPosition(1, new Vector3(hit.point.x, hit.point.y, transform.position.z));
            if (hit.collider.tag == "Mirror" )
            {
                _lineRenderer.positionCount = 3;
                Vector3 forward = hit.transform.up;
                RaycastHit2D hit2 = Physics2D.Raycast(hit.point, forward);

                if (hit2.collider)
                {
                    _lineRenderer.SetPosition(2, new Vector3(hit2.point.x, hit2.point.y, transform.position.z));
                    if (hit2.collider.tag == "Mirror")
                    {
                        _lineRenderer.positionCount = 4;
                        Vector3 forward1 = hit2.transform.right;
                        RaycastHit2D hit3 = Physics2D.Raycast(hit2.point, forward1);

                        if(hit3.collider)
                        {
                            _lineRenderer.SetPosition(3, new Vector3(hit3.point.x, hit3.point.y, transform.position.z));
                            if(_lineRenderer.GetPosition(3) == _lineRenderer.GetPosition(2))
                            {
                                hit3.point.Set(hit3.point.x + 1f, hit3.point.y);
                                _lineRenderer.SetPosition(3, new Vector3(0.5f, hit3.point.y, transform.position.z));
                            }

                            if (hit3.collider.name == "LaserEnd" || (_lineRenderer.GetPosition(3).x == 0.5f && _lineRenderer.GetPosition(3).y > 2.05f))
                            {
                                StartCoroutine("Validate");
                            }
                        }

                    } else
                    {
                        _lineRenderer.positionCount = 3;
                    }
                } 
            } else
            {
                _lineRenderer.positionCount = 2;
                
            }
        }
        
    }

    public IEnumerator Validate()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("LaserEnd").GetComponent<Image>().color = Color.green;
        yield return new WaitForSeconds(2f);
        GameObject presentoir = GameObject.Find("PresentoirLaser");
        presentoir.GetComponent<LaserManager>().Interact();
        presentoir.GetComponent<LaserManager>().enabled = false;

        if (GMScript != null)
        {
            GMScript.bTache3 = true;
            GMScript.AfficheNbTache();
        }
    }
}
