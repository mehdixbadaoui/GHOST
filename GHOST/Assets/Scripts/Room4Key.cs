using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Room4Key : MonoBehaviour
{
    public GameObject table;
    public GameObject player;
    public GameObject text;
    public GameObject manager;
    public GameObject hole;

    public bool locked;
    public float unlock_distance = 2f;
    public float text_distance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        locked = true;
        player = GameObject.FindGameObjectWithTag("player");
        hole.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, table.transform.position) < unlock_distance && !manager.GetComponent<manager>().is_possessing)
        {
            locked = false;
            StartCoroutine(floorCrash());
        }
        else locked = true;

        if (Vector2.Distance(player.transform.position, transform.position) < text_distance && !locked)
        {
            text.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
            }
        }
        else
            text.SetActive(false);

    }

    IEnumerator floorCrash()
    {
        yield return new WaitForSeconds(0.5f);
        hole.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        table.SetActive(false);

    }
    IEnumerator Load(int index)
    {
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene(index);
    }

}
