using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    [SerializeField]
    private Vector3 position;

    public Vector3 PositionChanger
    {
        get { return position; }
        set { position = value; }
    
    }

    private void Update()
    {
        transform.position = position;
    }

}
