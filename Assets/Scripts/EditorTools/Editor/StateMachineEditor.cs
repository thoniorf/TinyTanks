using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Reflection;

[CustomEditor(typeof(StateMachine), true)]
[CanEditMultipleObjects]
public class StateMachineEditor : Editor
{
    SerializedProperty characterState;
    SerializedProperty gameMode;
    string stateName;
    void OnEnable()
    {
        characterState = serializedObject.FindProperty("_currentState");
        gameMode = serializedObject.FindProperty("GameModeEventChannel");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        System.Object targetObject = serializedObject.targetObject;
        State currentState = (targetObject as IStateMachine).CurrentState;
        if (currentState != null)
            stateName = currentState.getStateName();

        EditorGUILayout.LabelField("State: ", currentState != null ? stateName : "not registered yet");

        if (gameMode != null)
        {
            EditorGUILayout.PropertyField(gameMode);
        }

        serializedObject.ApplyModifiedProperties();
    }

}
