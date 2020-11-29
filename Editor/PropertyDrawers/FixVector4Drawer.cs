using CCC.Editor;
using Unity.Properties;
using Unity.Properties.Adapters;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(fix4))]
public class FixFixVector4Drawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty xProp = property.FindPropertyRelative(nameof(fix4.x)).FindPropertyRelative(nameof(fix.RawValue));
        SerializedProperty yProp = property.FindPropertyRelative(nameof(fix4.y)).FindPropertyRelative(nameof(fix.RawValue));
        SerializedProperty zProp = property.FindPropertyRelative(nameof(fix4.z)).FindPropertyRelative(nameof(fix.RawValue));
        SerializedProperty wProp = property.FindPropertyRelative(nameof(fix4.w)).FindPropertyRelative(nameof(fix.RawValue));

        fix xVal;
        fix yVal;
        fix zVal;
        fix wVal;
        xVal.RawValue = xProp.longValue;
        yVal.RawValue = yProp.longValue;
        zVal.RawValue = zProp.longValue;
        wVal.RawValue = wProp.longValue;

        fix4 oldFixVec = new fix4(xVal, yVal, zVal, wVal);

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Editor Field
        Vector4 oldVec = oldFixVec.ToUnityVec();
        Vector4 newVec = EditorGUI.Vector4Field(position, label, oldVec);

        // Change ?
        if (oldVec != newVec)
        {
            fix4 newFixVec = newVec.ToFixVec();

            xProp.longValue = newFixVec.x.RawValue;
            yProp.longValue = newFixVec.y.RawValue;
            zProp.longValue = newFixVec.z.RawValue;
            wProp.longValue = newFixVec.w.RawValue;
        }


        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(SerializedPropertyType.Vector4, label);
    }
}


[CustomEntityPropertyDrawer]
public class FixVector4EntityDrawer : IMGUIAdapter,
        IVisit<fix4>
{
    VisitStatus IVisit<fix4>.Visit<TContainer>(Property<TContainer, fix4> property, ref TContainer container, ref fix4 value)
    {
        Vector4 oldValue = value.ToUnityVec();

        Vector4 newValue = EditorGUILayout.Vector4Field(GetDisplayName(property), oldValue);

        if (!newValue.Equals(oldValue) && !Application.isPlaying) // we do not support runtime changes due to loss of precision
        {
            value = newValue.ToFixVec();
        }

        return VisitStatus.Stop;
    }
}