using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public Transform[] segments;
    public Transform target;

    private float[] segmentLengths;
    private float[] angles;

    private void Start()
    {
        segmentLengths = new float[segments.Length];
        angles = new float[segments.Length];

        // Calculate segment lengths
        for (int i = 0; i < segments.Length; i++)
        {
            Vector3 segmentPosition = segments[i].position;
            Vector3 nextPosition = (i == segments.Length - 1) ? target.position : segments[i + 1].position;
            segmentPosition.y = 0f;
            nextPosition.y = 0f;
            segmentLengths[i] = Vector3.Distance(segmentPosition, nextPosition);
            Debug.Log("Segment " + i + " length: " + segmentLengths[i]);
        }

        // Set initial angles for each segment to 0
        for (int i = 0; i < segments.Length; i++)
        {
            angles[i] = 0f;
        }
    }

    private void Update()
    {
        ReachSegment(1, target.position.x, target.position.z); // Start from index 1 instead of 0

        for (int i = 2; i < segments.Length; i++) // Start from index 2
        {
            ReachSegment(i, segments[i - 1].position.x, segments[i - 1].position.z);
        }

        for (int j = segments.Length - 1; j >= 2; j--) // Start from index 2
        {
            PositionSegment(j, j - 1);
        }

        for (int k = 1; k < segments.Length; k++) // Start from index 1 instead of 0
        {
            Segment(segments[k], angles[k], 10f);
        }
    }

    private void PositionSegment(int a, int b)
    {
        Vector3 dir = segments[b].position - segments[a].position;
        dir.y = 0f; // Ignore the Y-axis
        angles[a] = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        segments[a].position = segments[b].position - dir.normalized * segmentLengths[a];
    }

    private void ReachSegment(int i, float targetX, float targetZ)
    {
        Vector3 dir = new Vector3(targetX - segments[i].position.x, 0f, targetZ - segments[i].position.z);
        angles[i] = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        Vector3 targetPos = new Vector3(targetX - Mathf.Cos(angles[i] * Mathf.Deg2Rad) * segmentLengths[i],
                                         segments[i].position.y,
                                         targetZ - Mathf.Sin(angles[i] * Mathf.Deg2Rad) * segmentLengths[i]);
        segments[i].position = targetPos;
    }

    private void Segment(Transform segment, float angle, float strokeWeight)
    {
        segment.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
