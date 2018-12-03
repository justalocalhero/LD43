using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(ResourceSprites))]
public class ResourceSpritesDrawer : PropertyDrawer 
{

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        int typeSize = 80;
		int iconSize = 80;
        int blockSize = 80;
        int negativeSize = 80;
        int spacing = 5;
        
        int typeIndent = 0;
		int iconIndent = typeIndent + spacing + typeSize;
		int blockIndent = iconIndent + spacing + iconSize;        
		int negativeIndent = blockIndent + spacing + blockSize;    

        Rect typeRect = new Rect(position.x + typeIndent, position.y, typeSize, position.height);
		Rect iconRect = new Rect(position.x + iconIndent, position.y, iconSize, position.height);        
		Rect blockRect = new Rect(position.x + blockIndent, position.y, blockSize, position.height);
		Rect negativeRect = new Rect(position.x + negativeIndent, position.y, negativeSize, position.height);

        EditorGUI.PropertyField(typeRect, property.FindPropertyRelative("type"), GUIContent.none);		
        EditorGUI.PropertyField(iconRect, property.FindPropertyRelative("icon"), GUIContent.none);
        EditorGUI.PropertyField(blockRect, property.FindPropertyRelative("block"), GUIContent.none);		
        EditorGUI.PropertyField(negativeRect, property.FindPropertyRelative("negativeBlock"), GUIContent.none);

        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
