#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.InputEventSystem
{
    [CustomEditor(typeof(XRInputController))]
    public class XRInputControllerEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty playerInput;
        SerializedProperty leftHand;
        SerializedProperty rightHand;

        private void OnEnable()
        {
            playerInput = serializedObject.FindProperty("playerInput");
            leftHand = serializedObject.FindProperty("leftHand");
            rightHand = serializedObject.FindProperty("rightHand");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            XRInputController xrInputController = (XRInputController)target;
            serializedObject.Update();

            // banner
            Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Input Event System/Resources/Icons/inspectorBanner_InputEventSystem.png", typeof(Texture));
            GUILayout.Box(banner, GUILayout.ExpandWidth(true), GUILayout.Height(Screen.width / 7.5f));

            // custom inspector
            EditorGUILayout.PropertyField(playerInput);
            EditorGUILayout.PropertyField(leftHand);
            EditorGUILayout.PropertyField(rightHand);

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion

    } // class end
}

#endif
