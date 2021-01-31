using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3Key : MonoBehaviour
{
    public GameObject door;
    Vector3 initialpos;

    private void Start()
    {
        initialpos = door.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -4.35) unlock();

    }

    private void unlock()
    {
        door.transform.position = Vector2.MoveTowards(door.transform.position, initialpos - new Vector3(1, 0, 0), 5 * Time.deltaTime);
    }
}
