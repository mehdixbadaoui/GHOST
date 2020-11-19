using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class possess : MonoBehaviour
{
    List<GameObject> objects;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("movable"));
        player = GameObject.FindGameObjectWithTag("player");

    }

    // Update is called once per frame
    void Update()
    {
        objects = objects.OrderBy(o => (o.transform.position - player.transform.position).magnitude).ToList();
        //GameObject closest = objects[0];
        //closest.GetComponent<SpriteRenderer>().color = Color.red;
        float closest_dist = (objects[0].transform.position - player.transform.position).magnitude;
        Debug.Log($"name :{objects[0]} dist: {closest_dist}");
        foreach (GameObject obj in objects)
        {
            float dist = (obj.transform.position - player.transform.position).magnitude;
            if (obj == objects[0] && dist < 2f)
            {
                obj.GetComponent<SpriteRenderer>().color = Color.red;
                continue;
            }
            obj.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
