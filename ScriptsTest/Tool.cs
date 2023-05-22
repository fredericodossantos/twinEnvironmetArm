using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour

{
    public MoveTool moveTool;

    void Update()
    {
        // Call the MoveIt() method of the Move_XYZ script
        moveTool.MoveIt();
    }
}
