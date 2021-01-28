using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public Transform player;
    [Range(0.01f, 2f)]
    public float d;

    public Animator transistion;
    void Update()
    {
        if((player.position - transform.position).magnitude < d)
        {
            StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));

        }
    }

    public void loadLevel()
    {
        

    }

    IEnumerator Load(int index)
    {
        transistion.SetTrigger("start");

        yield return new WaitForSeconds(0);

        SceneManager.LoadScene(index);
    }
}
