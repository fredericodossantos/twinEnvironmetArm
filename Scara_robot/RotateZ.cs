using UnityEngine;
using UnityEditor;



public class RotateZ : MonoBehaviour
{

    public Vector3 rotation;

}

[CustomEditor(typeof(RotateZ))]
class  RatateZEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RotateZ td = (RotateZ)target;      
        
        // put a grab bar to change the Z axis rotation of the object in the scene view       
        td.rotation.z = EditorGUILayout.Slider("Z", td.rotation.z, -180, 180);
        td.rotation.x = -90;//EditorGUILayout.Slider("X", td.rotation.x, -180, 180);
        td.rotation.y = 0;//EditorGUILayout.Slider("Y", td.rotation.y, -180, 180);

        // Update the rotation of the object in the scene
        td.transform.rotation = Quaternion.Euler(td.rotation);       
    
    }
}



