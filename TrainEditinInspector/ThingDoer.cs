using UnityEngine;
using UnityEditor;



public class ThingDoer : MonoBehaviour
{

    public Vector3 position;
    public Vector3 rotation;

}

[CustomEditor(typeof(ThingDoer))]
class  ThingDoerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ThingDoer td = (ThingDoer)target;
        //put a grab bar to change the X position of the object in the scene view
        td.position.x = EditorGUILayout.Slider("X", td.position.x, -10, 10);
        td.transform.position = td.position;
        // put a grab bar to change the Z axis rotation of the object in the scene view
        td.rotation.x = EditorGUILayout.Slider("X", td.rotation.x, -180, 180);
        td.rotation.y = EditorGUILayout.Slider("Y", td.rotation.y, -180, 180);
        td.rotation.z = EditorGUILayout.Slider("Z", td.rotation.z, -180, 180);

        // Update the rotation of the object in the scene
        td.transform.rotation = Quaternion.Euler(td.rotation);       
    
    }
}
