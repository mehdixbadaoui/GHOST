using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class manager : MonoBehaviour
{
    List<GameObject> objects;
    GameObject player;
    public GameObject possessed;

    bool is_possessing;

    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("movable"));
        player = GameObject.FindGameObjectWithTag("player");
        possessed = null;
        is_possessing = false;

    }

    // Update is called once per frame
    void Update()
    {
        objects = objects.OrderBy(o => (o.transform.position - player.transform.position).magnitude).ToList();
        //GameObject closest = objects[0];
        //closest.GetComponent<SpriteRenderer>().color = Color.red;
        float closest_dist = (objects[0].transform.position - player.transform.position).magnitude;
        //Debug.Log($"name :{objects[0]} dist: {closest_dist}");
        foreach (GameObject obj in objects)
        {
            float dist = (obj.transform.position - player.transform.position).magnitude;
            if (obj == possessed)
            {
                Color trans = obj.GetComponent<SpriteRenderer>().color;
                trans.a = 0.5f;
                obj.GetComponent<SpriteRenderer>().color = trans;

            }

            else if (obj == objects[0] && dist < 2f)
            {
                obj.GetComponent<SpriteRenderer>().color = Color.red;
            }


            else
            {
                obj.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            float d = (objects[0].transform.position - player.transform.position).magnitude;
            if (possessed)
            {
                possess(false);
                possessed = null;
            }

            else if (!possessed && d < 2f){

                //Debug.Log("can pos");
                possessed = objects[0];
                possess(true);

            }
        }
    }

    private void possess(bool b)
    {
        player.GetComponent<Movement>().enabled = !b;
        possessed.GetComponent<Movement>().enabled = b;
        
    }

}
