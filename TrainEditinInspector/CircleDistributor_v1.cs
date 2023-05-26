using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDistributor_v1 : MonoBehaviour
{
    public GameObject prefab;
    public int numberOfObjects = 10;
    public float radius = 5f;
    public float force = 10f;

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
            GameObject sphere = Instantiate(prefab, newPos, Quaternion.identity);
            Rigidbody rb = sphere.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(newPos.normalized * force, ForceMode.Impulse);
            }
        }
    }
}
