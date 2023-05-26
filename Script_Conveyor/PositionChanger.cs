using UnityEngine;

public class PositionChanger : MonoBehaviour
{
    [SerializeField]
    [Range(-10f, 10f)]
    private float xPosition;

    public Vector3 Position
    {
        get { return new Vector3(xPosition, transform.position.y, transform.position.z); }
        set { xPosition = value.x; }
    }

    private void Update()
    {
        transform.position = Position;
    }
}