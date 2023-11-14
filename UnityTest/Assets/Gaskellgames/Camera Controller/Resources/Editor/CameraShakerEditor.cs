#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    [CustomEditor(typeof(CameraShaker))] [CanEditMultipleObjects]
    public class CameraShakerEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty alwaysShowZone;
        SerializedProperty gizmoColor;
        SerializedProperty intensity;
        SerializedProperty range;

        private void OnEnable()
        {
            alwaysShowZone = serializedObject.FindProperty("alwaysShowZone");
            gizmoColor = serializedObject.FindProperty("gizmoColor");
            intensity = serializedObject.FindProperty("intensity");
            range = serializedObject.FindProperty("range");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            CameraShaker cameraShaker = (CameraShaker)target;
            serializedObject.Update();

            /*
            // draw default inspector
            base.OnInspectorGUI();
            */

            // banner
            Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/inspectorBanner_CameraController.png", typeof(Texture));
            GUILayout.Box(banner, GUILayout.ExpandWidth(true), GUILayout.Height(Screen.width / 7.5f));

            // custom inspector
            EditorGUILayout.PropertyField(alwaysShowZone);
            EditorGUILayout.PropertyField(gizmoColor);
            EditorGUILayout.PropertyField(intensity);
            EditorGUILayout.PropertyField(range);

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
    }
}

#endif
