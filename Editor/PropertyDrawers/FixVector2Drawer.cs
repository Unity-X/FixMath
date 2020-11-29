using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(fix2))]
public class FixVector2Drawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty xProp = property.FindPropertyRelative(nameof(fix2.x)).FindPropertyRelative(nameof(fix.RawValue));
        SerializedProperty yProp = property.FindPropertyRelative(nameof(fix2.y)).FindPropertyRelative(nameof(fix.RawValue));

        fix xVal;
        fix yVal;
        xVal.RawValue = xProp.longValue;
        yVal.RawValue = yProp.longValue;

        fix2 oldFixVec = new fix2(xVal, yVal);

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Editor Field
        Vector2 oldVec = oldFixVec.ToUnityVec();
        Vector2 newVec = EditorGUI.Vector2Field(position, label, oldVec);

        // Change ?
        if (oldVec != newVec)
        {
            fix2 newFixVec = newVec.ToFixVec();

            xProp.longValue = newFixVec.x.RawValue;
            yProp.longValue = newFixVec.y.RawValue;
        }


        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(SerializedPropertyType.Vector2, label);
    }
}