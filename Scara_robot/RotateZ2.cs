
using UnityEngine;
using UnityEditor;



public class RotateZ2 : MonoBehaviour
{

    public Vector3 rotation;

}

[CustomEditor(typeof(RotateZ2))]
class  RatateZ2Editor : Editor
{
    public override void OnInspectorGUI()
    {
        RotateZ2 td = (RotateZ2)target;      
        
        // put a grab bar to change the Z axis rotation of the object in the scene view       
        td.rotation.z = EditorGUILayout.Slider("Z", td.rotation.z, -30, -300);
        td.rotation.x = 90; //EditorGUILayout.Slider("X", td.rotation.x, -180, 180);
        td.rotation.y = 180;//EditorGUILayout.Slider("Y", td.rotation.y, -180, 180);

        // Update the rotation of the object in the scene
        td.transform.rotation = Quaternion.Euler(td.rotation);       
    
    }
}



