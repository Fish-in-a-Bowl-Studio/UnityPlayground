#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    [CustomEditor(typeof(CameraFreelookRig))] [CanEditMultipleObjects]
    public class CameraFreelookRigEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty lockCursorOnLoad;
        SerializedProperty gizmosOnSelected;
        SerializedProperty cameraCollisions;
        SerializedProperty customInputAction;

        SerializedProperty moveCamera;
        SerializedProperty gmkInputController;

        SerializedProperty follow;
        SerializedProperty cameraOrbit;

        SerializedProperty xSensitivity;
        SerializedProperty ySensitivity;
        SerializedProperty rotationOffset;
        SerializedProperty collisionOffset;

        bool InputGroup = false;
        bool CollisionGroup = false;

        private void OnEnable()
        {
            customInputAction = serializedObject.FindProperty("customInputAction");
            moveCamera = serializedObject.FindProperty("moveCamera");
            gmkInputController = serializedObject.FindProperty("gmkInputController");

            gizmosOnSelected = serializedObject.FindProperty("gizmosOnSelected");
            lockCursorOnLoad = serializedObject.FindProperty("lockCursorOnLoad");
            cameraCollisions = serializedObject.FindProperty("cameraCollisions");

            follow = serializedObject.FindProperty("follow");
            cameraOrbit = serializedObject.FindProperty("cameraOrbit");

            xSensitivity = serializedObject.FindProperty("xSensitivity");
            ySensitivity = serializedObject.FindProperty("ySensitivity");
            rotationOffset = serializedObject.FindProperty("rotationOffset");
            collisionOffset = serializedObject.FindProperty("collisionOffset");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            CameraFreelookRig cameraFreelookRig = (CameraFreelookRig)target;
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
            EditorGUILayout.PropertyField(lockCursorOnLoad);
            EditorGUILayout.PropertyField(gizmosOnSelected);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(cameraCollisions);
            EditorGUILayout.PropertyField(customInputAction);
            EditorGUILayout.EndHorizontal();

            InputGroup = customInputAction.boolValue;
            if (InputGroup)
            {
                EditorGUILayout.PropertyField(moveCamera);
            }
            else
            {
                EditorGUILayout.PropertyField(gmkInputController);
            }

            EditorGUILayout.PropertyField(follow);
            EditorGUILayout.PropertyField(cameraOrbit);
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(xSensitivity);
            EditorGUILayout.PropertyField(ySensitivity);
            EditorGUILayout.PropertyField(rotationOffset);

            CollisionGroup = cameraCollisions.boolValue;
            if(CollisionGroup)
            {
                EditorGUILayout.PropertyField(collisionOffset);
            }

            if (follow.objectReferenceValue != null)
            {
                EditorGUILayout.Space();
                EditorGUILayout.HelpBox("Freelook rig position is being driven by the transform position of the 'Follow' gameobject", MessageType.Info);
            }

            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
    }
}

#endif
