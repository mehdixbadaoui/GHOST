using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3Key : MonoBehaviour
{
    public GameObject door;
    public GameObject text;
    GameObject player;
    public GameObject exit;
    public float distance = 2f;
    private bool locked;

    Vector3 initialpos;

    private void Start()
    {
        locked = true;
        initialpos = door.transform.position;
        player = GameObject.FindGameObjectWithTag("player");
        text.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -4.35) 
            unlock();
        if (Vector2.Distance(player.transform.position, exit.transform.position) < distance && !locked) /*Debug.Log("E");*/
            text.SetActive(true);
    }

    private void unlock()
    {
        locked = false;
        door.transform.position = Vector2.MoveTowards(door.transform.position, initialpos - new Vector3(1, 0, 0), 5 * Time.deltaTime);
    }
}
