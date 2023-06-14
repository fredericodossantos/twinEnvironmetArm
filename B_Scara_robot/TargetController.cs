using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{   
    public GameObject Target;
    public float speed = 5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Target.transform.position += Vector3.left * speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Target.transform.position += Vector3.right * speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Target.transform.position += Vector3.forward * speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Target.transform.position += Vector3.back * speed * Time.deltaTime;
        }
        
    }
}
