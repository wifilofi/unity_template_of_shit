using Tools.CMSTags;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
    [CustomPropertyDrawer(typeof(TagUnity))]
    public class TagUnityDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, $"{nameof(TagUnity)} requires a string field.", MessageType.Error);
                return;
            }

            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
    }
}
