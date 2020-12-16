using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
    public Transform player;
    [Range(0.01f, 2f)]
    public float d;
    void Update()
    {
        if((player.position - transform.position).magnitude < d)
        {
            SceneManager.LoadScene("Room2");
        }
    }
}
