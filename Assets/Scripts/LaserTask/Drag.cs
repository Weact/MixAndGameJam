using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject mirror;
    Vector3 startPosition; //Position de départ
    Transform startParent; // Parent de départ de l'unité à déplacer
    private Vector3 screenPoint; //Position du pointeur à l'écran
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        mirror = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        screenPoint = Input.mousePosition;
        screenPoint.z = 1f;
        transform.position = mainCamera.ScreenToWorldPoint(screenPoint);
        transform.position.Set(transform.position.x, transform.position.y, 1);
        transform.SetParent(startParent);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        mirror = null;
        transform.SetParent(startParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
