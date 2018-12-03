using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(CardStat))]
public class CardStatDrawer : PropertyDrawer 
{

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        int typeSize = 80;
		int valueSize = 40;
        int spacing = 5;
        
        int typeIndent = 0;
		int valueIndent = typeIndent +spacing + typeSize;    
        Rect typeRect = new Rect(position.x + typeIndent, position.y, typeSize, position.height);
		Rect valueRect = new Rect(position.x + valueIndent, position.y, valueSize, position.height);

        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("type"), GUIContent.none);		
        EditorGUI.PropertyField(valueRect, property.FindPropertyRelative("value"), GUIContent.none);

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
