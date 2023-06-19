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
            if (i == segments.Length - 1)
            {
                segmentLengths[i] = Vector3.Distance(segments[i].position, target.position);
            }
            else
            {
                segmentLengths[i] = Vector3.Distance(segments[i].position, segments[i + 1].position);
            }
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
        ReachSegment(0, target.position.x, target.position.y);
        for (int i = 1; i < segments.Length; i++)
        {
            ReachSegment(i, segments[i - 1].position.x, segments[i - 1].position.y);
        }

        for (int j = segments.Length - 1; j >= 1; j--)
        {
            PositionSegment(j, j - 1);
        }

        for (int k = 0; k < segments.Length; k++)
        {
            Segment(segments[k], angles[k], 10f);
        }
    }

    private void PositionSegment(int a, int b)
    {
        Vector3 dir = segments[b].position - segments[a].position;
        angles[a] = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        segments[a].position = segments[b].position - dir.normalized * segmentLengths[a];
    }

    private void ReachSegment(int i, float targetX, float targetY)
    {
        Vector3 dir = new Vector3(targetX - segments[i].position.x, targetY - segments[i].position.y, 0f);
        angles[i] = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Vector3 targetPos = new Vector3(targetX - Mathf.Cos(angles[i] * Mathf.Deg2Rad) * segmentLengths[i],
                                         targetY - Mathf.Sin(angles[i] * Mathf.Deg2Rad) * segmentLengths[i],
                                         0f);
        segments[i].position = targetPos;
    }

    private void Segment(Transform segment, float angle, float strokeWeight)
    {
        segment.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
