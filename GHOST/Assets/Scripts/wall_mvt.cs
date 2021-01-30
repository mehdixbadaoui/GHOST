using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_mvt : MonoBehaviour
{
    public float speed = 5f;
    Camera cam;

    void Update()
    {
        float transform_y = transform.position.y + Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0));
        //Debug.Log(transform_y);
        if (screenPos.x > 0 && screenPos.x < Screen.width && transform_y > 5.5 && transform_y < 6.3)
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * speed * Time.deltaTime;

    }
}
