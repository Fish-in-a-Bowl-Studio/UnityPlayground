using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.InputEventSystem
{
    [CustomEditor(typeof(InputEvent))] [CanEditMultipleObjects]
    public class InputEventEditor : Editor
    {
        #region Serialized Properties / OnEnable
        
        private SerializedProperty userInput;
        private SerializedProperty OnPressed;
        private SerializedProperty OnHeld;
        private SerializedProperty OnReleased;

        private bool eventGroup;

        private void OnEnable()
        {
            userInput = serializedObject.FindProperty("userInput");
            OnPressed = serializedObject.FindProperty("OnPressed");
            OnHeld = serializedObject.FindProperty("OnHeld");
            OnReleased = serializedObject.FindProperty("OnReleased");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------
        
        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            InputEvent inputEvent = (InputEvent)target;
            serializedObject.Update();

            // banner
            Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Input Event System/Resources/Icons/inspectorBanner_InputEventSystem.png", typeof(Texture));
            GUILayout.Box(banner, GUILayout.ExpandWidth(true), GUILayout.Height(Screen.width / 7.5f));
            
            // custom inspector
            EditorGUILayout.PropertyField(userInput);
            EditorGUILayout.Space();
            eventGroup = EditorGUILayout.BeginFoldoutHeaderGroup(eventGroup, "Events");
            if (eventGroup)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(OnPressed);
                EditorGUILayout.PropertyField(OnHeld);
                EditorGUILayout.PropertyField(OnReleased);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
        
    } // class end
}

#endif
