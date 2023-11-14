#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    [CustomEditor(typeof(CameraDolly))] [CanEditMultipleObjects]
    public class CameraDollyEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty cameraTrack;
        SerializedProperty lookAt;
        SerializedProperty startIndex;
        SerializedProperty flipStartDirection;
        SerializedProperty updateRotation;
        SerializedProperty moveSpeed;
        SerializedProperty turnSpeed;
        
        private void OnEnable()
        {
            cameraTrack = serializedObject.FindProperty("cameraTrack");
            lookAt = serializedObject.FindProperty("lookAt");
            startIndex = serializedObject.FindProperty("startIndex");
            flipStartDirection = serializedObject.FindProperty("flipStartDirection");
            updateRotation = serializedObject.FindProperty("updateRotation");
            moveSpeed = serializedObject.FindProperty("moveSpeed");
            turnSpeed = serializedObject.FindProperty("turnSpeed");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            CameraDolly cameraDolly = (CameraDolly)target;
            serializedObject.Update();

            /*
            // draw default inspector
            base.OnInspectorGUI();
            */

            // banner
            Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/inspectorBanner_CameraController.png", typeof(Texture));
            GUILayout.Box(banner, GUILayout.ExpandWidth(true), GUILayout.Height(Screen.width / 7.5f));

            // custom inspector
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(flipStartDirection);
            EditorGUILayout.PropertyField(updateRotation);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.PropertyField(startIndex);
            EditorGUILayout.PropertyField(cameraTrack);
            if (updateRotation.boolValue)
            {
                EditorGUILayout.PropertyField(lookAt);
                EditorGUILayout.PropertyField(turnSpeed);
            }
            EditorGUILayout.PropertyField(moveSpeed);
            if (cameraDolly.GetCameraTrack() == null)
            {
                EditorGUILayout.Space();
                EditorGUILayout.HelpBox("CameraTrack not assigned", MessageType.Warning);
            }
            if (updateRotation.boolValue)
            {
                if (cameraDolly.GetLookAt() == null)
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.HelpBox("LookAt not assigned, object rotation will not be updated", MessageType.Warning);
                }
                else
                {
                    EditorGUILayout.Space();
                    EditorGUILayout.HelpBox("Object rotation is being driven by LookAt transform", MessageType.Info);
                }
            }
            
            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
        
    } // class end
}
#endif