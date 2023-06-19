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
            segmentLengths[i] = i == segments.Length - 1 ? 1f : Vector3.Distance(segmentPosition, nextPosition);
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
        for (int i = 0; i < segments.Length; i++)
        {
            ReachSegment(i, target.position.x, target.position.z);
        }

        for (int j = segments.Length - 1; j >= 1; j--)
        {
            PositionSegment(j, j - 1);
        }

        for (int k = 0; k < segments.Length; k++)
        {
            Segment(segments[k], angles[k]);
        }
    }

    private void PositionSegment(int a, int b)
    {
        Vector3 dir = segments[b].position - segments[a].position;
        dir.y = 0f; // Ignore the Y-axis
        angles[a] = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

        // Calculate the target position for the segment
        Vector3 targetPosition = segments[b].position - dir.normalized * segmentLengths[a];

        // Move the segment towards the target position gradually using Lerp
        segments[a].position = Vector3.Lerp(segments[a].position, targetPosition, Time.deltaTime * 5f);
    }

    private void ReachSegment(int i, float targetX, float targetZ)
    {
        Vector3 dir = new Vector3(targetX - segments[i].position.x, 0f, -(targetZ - segments[i].position.z));
        angles[i] = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
    }

    private void Segment(Transform segment, float angle)
    {
        segment.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
