using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject[] Rooms;
    private float timer;
    private int random = -1;
    private int lastIndex = -1;
    private float maxTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            random = Random.Range(0, Rooms.Length);
            while (random == lastIndex)
            {
                random = Random.Range(0, Rooms.Length);
            }
            lastIndex = random;
            StartCoroutine(ChangeRoomState());
            timer = 0;
        }
    }

    public IEnumerator ChangeRoomState()
    {
        Rooms[random].SetActive(true);
        yield return new WaitForSeconds(5);
        Rooms[random].SetActive(false);
    }
}
