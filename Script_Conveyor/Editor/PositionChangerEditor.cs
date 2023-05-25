using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PositionChanger))]
public class PositionChangerEditor : Editor
{
    private const float MinPosition = -10f;
    private const float MaxPosition = 10f;

    private SerializedProperty positionProperty;
    private Rect draggableRect;
    private bool isDragging;

    private void OnEnable()
    {
        positionProperty = serializedObject.FindProperty("position");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(positionProperty);
        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        PositionChanger positionChanger = (PositionChanger)target;
        Vector3 position = positionChanger.transform.position;

        Vector3 newPosition = Handles.Slider(position, Vector3.right, HandleUtility.GetHandleSize(position) * 0.3f, Handles.ArrowHandleCap, 0f);

        if (newPosition != position)
        {
            float clampedX = Mathf.Clamp(newPosition.x, MinPosition, MaxPosition);
            newPosition.x = clampedX;
            positionChanger.transform.position = newPosition;
            positionProperty.vector3Value = newPosition;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
