using CCC.Editor;
using Unity.Properties;
using Unity.Properties.Adapters;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(fixQuaternion))]
public class FixQuaternionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty xProp = property.FindPropertyRelative(nameof(Quaternion.x)).FindPropertyRelative(nameof(fix.RawValue));
        SerializedProperty yProp = property.FindPropertyRelative(nameof(Quaternion.y)).FindPropertyRelative(nameof(fix.RawValue));
        SerializedProperty zProp = property.FindPropertyRelative(nameof(Quaternion.z)).FindPropertyRelative(nameof(fix.RawValue));
        SerializedProperty wProp = property.FindPropertyRelative(nameof(Quaternion.w)).FindPropertyRelative(nameof(fix.RawValue));

        fix xVal;
        fix yVal;
        fix zVal;
        fix wVal;
        xVal.RawValue = xProp.longValue;
        yVal.RawValue = yProp.longValue;
        zVal.RawValue = zProp.longValue;
        wVal.RawValue = wProp.longValue;

        fixQuaternion oldQuat = new fixQuaternion(xVal, yVal, zVal, wVal);

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Editor Field
        Vector3 oldEuler = oldQuat.ToUnityQuat().eulerAngles;
        Vector3 newEuler = EditorGUI.Vector3Field(position, label, oldEuler);

        // Change ?
        if (oldEuler != newEuler)
        {
            fixQuaternion newQuat = Quaternion.Euler(newEuler.x, newEuler.y, newEuler.z).ToFixQuat();

            xProp.longValue = newQuat.x.RawValue;
            yProp.longValue = newQuat.y.RawValue;
            zProp.longValue = newQuat.z.RawValue;
            wProp.longValue = newQuat.w.RawValue;
        }


        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(SerializedPropertyType.Vector3, label);
    }
}

[CustomEntityPropertyDrawer]
public class FixQuaternionEntityDrawer : IMGUIAdapter,
        IVisit<fixQuaternion>
{
    VisitStatus IVisit<fixQuaternion>.Visit<TContainer>(Property<TContainer, fixQuaternion> property, ref TContainer container, ref fixQuaternion value)
    {
        Vector3 oldValue = value.ToUnityQuat().eulerAngles;

        Vector3 newValue = EditorGUILayout.Vector3Field(GetDisplayName(property), oldValue);

        if (!newValue.Equals(oldValue) && !Application.isPlaying) // we do not support runtime changes due to loss of precision
        {
            value = fixQuaternion.FromEuler(newValue.ToFixVec());
        }

        return VisitStatus.Stop;
    }
}