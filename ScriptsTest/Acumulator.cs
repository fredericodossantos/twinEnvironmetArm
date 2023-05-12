using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acumulator : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public GameObject[] gameObjects;
    public float moveSpeed = 1f;
    public List<bool> isMoving = new List<bool>();

    void Start()
    {
        // Add the initial positions of the game objects to the list
        for (int i = 0; i < gameObjects.Length; i++)
        {
            positions.Add(gameObjects[i].transform.position);
            isMoving.Add(false);
        }
    }
    void Update()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 direction = positions[i] - gameObjects[i].transform.position;
            if (direction.magnitude > 0.01f)
            {
                gameObjects[i].transform.Translate(direction * moveSpeed * Time.deltaTime);
                isMoving[i] = true;
            }
            else
            {
                isMoving[i] = false;
            }
        }
    }

}


