using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Acumulator acumulator; // Drag and drop the game object with the Acumulator script attached to this field in the Inspector

    public void MoveIt()
    {
        Debug.Log("Clicked to move");
        if (!acumulator.isMoving[1])
        {
            acumulator.positions[1] = new Vector3(acumulator.positions[1].x + Random.Range(-3f, 3f), acumulator.positions[1].y, acumulator.positions[1].z);
            acumulator.moveSpeed = Random.Range(0.5f, 2f);
        }
        else
        {
            Debug.Log("Object still moving");
        }
    }

    
}
