

using System;
using System.Collections;
using System.Collections.Generic;
using  System.Linq;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    // The class draw a path for their character
    // The path is a line renderer
    // The path is drawn by the mouse
    
    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    public Action<IEnumerable<Vector3>> OnPathCreated = delegate { };

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))        
            points.Clear();

        if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (DistanceToLastPoint(hitInfo.point) > 1f)
                {
                    points.Add(hitInfo.point);
                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            OnNewPathCreated(points);
        }

        float DistanceToLastPoint(Vector3 point)
        {
            if (!points.Any())
                return Mathf.Infinity;
            return Vector3.Distance(points.Last(), point);
        }      
            
        
      
    }

}
