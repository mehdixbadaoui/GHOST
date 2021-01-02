using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class manager : MonoBehaviour
{
    List<GameObject> objects;
    GameObject player;
    public GameObject possessed;

    public float possess_dist;
    private bool is_possessing;
    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>(GameObject.FindGameObjectsWithTag("movable"));
        player = GameObject.FindGameObjectWithTag("player");
        possessed = null;

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
            //float dist = Mathf.Pow(obj.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(obj.transform.position.y - player.transform.position.y, 2);
            if (obj == possessed)
            {
                Color trans = obj.GetComponent<SpriteRenderer>().color;
                trans.a = 0.5f;
                obj.GetComponentInChildren<SpriteRenderer>().color = trans;

            }

            else if (obj == objects[0] && dist < possess_dist && !is_possessing)
            {
                obj.GetComponentInChildren<SpriteRenderer>().color = Color.red;

                //REALLY NEED TO FIX THIS UGLY ASS CODE
                foreach (Transform child in obj.transform)
                {
                    child.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }

            }


            else
            {
                obj.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                foreach (Transform child in obj.transform)
                {
                    child.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                }
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

            else if (!possessed && d < possess_dist)
            {

                //Debug.Log("can pos");
                possessed = objects[0];
                possess(true);

            }
        }
    }

    private void possess(bool b)
    {
        is_possessing = b;
        player.GetComponent<Movement>().enabled = !b;
        possessed.GetComponent<Movement>().enabled = b;
        player.GetComponentInChildren<SpriteRenderer>().enabled = !b;

        if (!b)
        {
            Vector3 new_player_pos = possessed.transform.position;
            new_player_pos.z = -4.6f;
            player.transform.position = new_player_pos;
        }
        
    }

}
