using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Room2Key : MonoBehaviour
{
    public GameObject door;
    public GameObject text;
    GameObject player;
    public GameObject exit;
    public float unlock_distance = 2f;
    public float text_distance = 2f;
    public bool locked;
    public Animator transistion;
    private Vector3 initialpos;

    // Start is called before the first frame update
    void Start()
    {
        locked = true;
        initialpos = transform.position;
        player = GameObject.FindGameObjectWithTag("player");
        text.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(initialpos, transform.position) > unlock_distance)
            locked = false;
        else locked = true;

        if (Vector2.Distance(player.transform.position, initialpos) < text_distance && !locked)
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

    IEnumerator Load(int index)
    {
        yield return new WaitForSeconds(0);

        SceneManager.LoadScene(index);
    }

}
