using UnityEditor;
using UnityEngine;
using CCC.Editor;
using Unity.Properties.Adapters;
using Unity.Properties;

[CustomPropertyDrawer(typeof(fix))]
public class Fix64Drawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty valueProperty = property.FindPropertyRelative(nameof(fix.RawValue));
        long valueRaw = valueProperty.longValue;

        fix value;
        value.RawValue = valueRaw;

        float floatValue = (float)value;

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Editor Field
        float newFloatValue = EditorGUI.FloatField(position, label, floatValue);

        // Change ?
        if(newFloatValue != floatValue)
        {
            fix newValue = (fix)newFloatValue;
            valueProperty.longValue = newValue.RawValue;
        }


        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 18;
    }
}

[CustomEntityPropertyDrawer]
public class Fix64EntityDrawer : IMGUIAdapter,
        IVisit<fix>
{
    VisitStatus IVisit<fix>.Visit<TContainer>(Property<TContainer, fix> property, ref TContainer container, ref fix value)
    {
        float oldValue = (float)value;

        float newValue = EditorGUILayout.FloatField(GetDisplayName(property), oldValue);

        if (!newValue.Equals(oldValue) && !Application.isPlaying) // we do not support runtime changes due to loss of precision
        {
            value = (fix)newValue;
        }

        return VisitStatus.Stop;
    }
}