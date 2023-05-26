using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDistributor : MonoBehaviour
{
    public GameObject spherePrefab;
    public int numberOfObjects = 10;
    public float radius = 5f;

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            Instantiate(spherePrefab, newPos, Quaternion.identity);
        }
    }
}
