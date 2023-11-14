#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

using Gaskellgames;
using Gaskellgames.InputEventSystem;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    [InitializeOnLoad]
    public class HierarchyIcon_CameraController
    {
        #region Variables

        private static readonly Texture2D icon_CameraBrain;
        private static readonly Texture2D icon_CameraRig;
        private static readonly Texture2D icon_CameraFreelookRig;
        private static readonly Texture2D icon_CameraSwitcher;
        private static readonly Texture2D icon_CameraShaker;
        private static readonly Texture2D icon_CameraTriggerZone;
        private static readonly Texture2D icon_CameraTarget;
        private static readonly Texture2D icon_CameraMultiTarget;
        private static readonly Texture2D icon_CameraDolly;
        private static readonly Texture2D icon_CameraTrack;
        private static readonly Texture2D icon_ShadowTransform;

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Editor Loop

        static HierarchyIcon_CameraController()
        {
            icon_CameraBrain = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraBrain.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraBrain == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraBrain;
            
            icon_CameraRig = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraRig.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraRig == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraRig;
            
            icon_CameraFreelookRig = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraFreelookRig.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraFreelookRig == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraFreelookRig;
            
            icon_CameraSwitcher = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraSwitcher.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraSwitcher == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraSwitcher;
            
            icon_CameraShaker = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraShaker.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraShaker == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraShaker;
            
            icon_CameraTriggerZone = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraTriggerZone.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraTriggerZone == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraTriggerZone;
            
            icon_CameraTarget = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraTarget.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraTarget == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraTarget;
            
            icon_CameraMultiTarget = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraMultiTarget.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraMultiTarget == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraMultiTarget;
            
            icon_CameraDolly = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraDolly.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraDolly == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraDolly;
            
            icon_CameraTrack = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_CameraTrack.png", typeof(Texture2D)) as Texture2D;
            if (icon_CameraTrack == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_CameraTrack;
            
            icon_ShadowTransform = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/Icon_ShadowTransform.png", typeof(Texture2D)) as Texture2D;
            if (icon_ShadowTransform == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_ShadowTransform;
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Private Functions

        private static void DrawHierarchyIcon_CameraBrain(int instanceID, Rect rect)
        {
            if (icon_CameraBrain == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraBrain>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraBrain);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraRig(int instanceID, Rect rect)
        {
            if (icon_CameraRig == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraRig>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            
            var otherComponent = gameObject.GetComponent<GMKInputController>();
            float offset = hierarchyPixelHeight;
            if (otherComponent != null) { offset += hierarchyPixelHeight; }
            
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - offset, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraRig);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraFreelookRig(int instanceID, Rect rect)
        {
            if (icon_CameraFreelookRig == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraFreelookRig>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraFreelookRig);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraSwitcher(int instanceID, Rect rect)
        {
            if (icon_CameraSwitcher == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraSwitcher>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            
            var otherComponent = gameObject.GetComponent<CameraBrain>();
            float offset = hierarchyPixelHeight;
            if (otherComponent != null) { offset += hierarchyPixelHeight; }
            
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - offset, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraSwitcher);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraShaker(int instanceID, Rect rect)
        {
            if (icon_CameraShaker == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraShaker>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraShaker);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraTriggerZone(int instanceID, Rect rect)
        {
            if (icon_CameraTriggerZone == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraTriggerZone>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            
            var otherComponent = gameObject.GetComponent<CameraMultiTarget>();
            float offset = hierarchyPixelHeight;
            if (otherComponent != null) { offset += hierarchyPixelHeight; }
            
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - offset, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraTriggerZone);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraTarget(int instanceID, Rect rect)
        {
            if (icon_CameraTarget == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraTarget>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraTarget);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraMultiTarget(int instanceID, Rect rect)
        {
            if (icon_CameraMultiTarget == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraMultiTarget>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraMultiTarget);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraDolly(int instanceID, Rect rect)
        {
            if (icon_CameraDolly == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraDolly>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraDolly);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_CameraTrack(int instanceID, Rect rect)
        {
            if (icon_CameraTrack == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<CameraTrack>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_CameraTrack);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_ShadowTransform(int instanceID, Rect rect)
        {
            if (icon_ShadowTransform == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<ShadowTransform>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_ShadowTransform);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        #endregion
        
    } // class end
}

#endif