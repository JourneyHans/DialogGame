using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XNodeEditor;

[CustomPropertyDrawer(typeof(ChatTrigger))]
public class ChatTriggerDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        property.isExpanded = EditorGUILayout.Foldout(property.isExpanded, label);

        if (property.isExpanded)
        {
            EditorGUI.indentLevel += 1;
            EditorGUILayout.PropertyField(property.FindPropertyRelative("TriggerCount"));

            EditorGUILayout.PropertyField(property.FindPropertyRelative("EventType"));
            TriggerEvent eventTypeValue = (TriggerEvent)property.FindPropertyRelative("EventType").enumValueIndex;
            switch (eventTypeValue)
            {
                case TriggerEvent.None:
                    break;
                case TriggerEvent.Test:
                    break;
                case TriggerEvent.ChangeBG:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("Res"));
                    break;
                case TriggerEvent.ChangeBGM:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("BGM"));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            EditorGUI.indentLevel -= 1;
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return -2.0f;
    }
}

//[CustomNodeEditor(typeof(ChatNode))]
//public class ChatNodeEditor : NodeEditor
//{
//    private bool _triggerFoldout = false;    // false -> fold. true -> expand
//
//    public override void OnBodyGUI()
//    {
////        base.OnBodyGUI();
//        serializedObject.Update();
//        ChatNode chatNode = target as ChatNode;
//
//        // Input and Output
//        NodeEditorGUILayout.PortField(new GUIContent("Input"), target.GetInputPort("Input"));
//        NodeEditorGUILayout.PortField(new GUIContent("Output"), target.GetOutputPort("Output"));
//
//        // Common property
//        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Interval"), new GUIContent("Interval"));
//        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Content"), new GUIContent("Content"));
//
//        //        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("TriggerCount"), new GUIContent("TriggerCount"));
//        //        NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("EventType"), new GUIContent("EventType"));
//
//        // Trigger property
//        EditorGUILayout.Space(10);
//
//        _triggerFoldout = EditorGUILayout.Foldout(_triggerFoldout, "Trigger");
//        if (!_triggerFoldout)
//        {
//            
//        }
//        else
//        {
//            SerializedProperty triggerProperty = serializedObject.FindProperty("Trigger");
//            NodeEditorGUILayout.PropertyField(triggerProperty.FindPropertyRelative("EventType"), new GUIContent("EventType"));
//
//            // Based on Type
//            switch (chatNode.Trigger.EventType)
//            {
//                case TriggerEvent.None:
//                    break;
//                case TriggerEvent.Test:
//                    NodeEditorGUILayout.PropertyField(triggerProperty.FindPropertyRelative("TriggerCount"), new GUIContent("TriggerCount"));
//                    break;
//                case TriggerEvent.ChangeBG:
//                    NodeEditorGUILayout.PropertyField(triggerProperty.FindPropertyRelative("Res"), new GUIContent("BG Image"));
//                    break;
//                case TriggerEvent.ChangeBGM:
//                    NodeEditorGUILayout.PropertyField(triggerProperty.FindPropertyRelative("BGM"), new GUIContent("BGM"));
//                    break;
//                default:
//                    throw new ArgumentOutOfRangeException();
//            }
//        }
//    }
//}
