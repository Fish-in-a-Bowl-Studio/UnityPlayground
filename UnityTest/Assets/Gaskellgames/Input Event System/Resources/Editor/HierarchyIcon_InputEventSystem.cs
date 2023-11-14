#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.InputEventSystem
{
    [InitializeOnLoad]
    public class HierarchyIcon_InputEventSystem
    {
        #region Variables

        private static readonly Texture2D icon_InputActionManager;
        private static readonly Texture2D icon_GMKInputController;
        private static readonly Texture2D icon_XRInputController;
        private static readonly Texture2D icon_InputEvent;

        #endregion
        
        //----------------------------------------------------------------------------------------------------

        #region Editor Loop

        static HierarchyIcon_InputEventSystem()
        {
            icon_InputActionManager = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Input Event System/Resources/Icons/Icon_InputActionManager.png", typeof(Texture2D)) as Texture2D;
            if (icon_InputActionManager == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_InputActionManager;
            
            icon_GMKInputController = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Input Event System/Resources/Icons/Icon_GMKInputController.png", typeof(Texture2D)) as Texture2D;
            if (icon_GMKInputController == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_GMKInputController;
            
            icon_XRInputController = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Input Event System/Resources/Icons/Icon_XRInputController.png", typeof(Texture2D)) as Texture2D;
            if (icon_XRInputController == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_XRInputController;
            
            icon_InputEvent = AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Input Event System/Resources/Icons/Icon_InputEvent.png", typeof(Texture2D)) as Texture2D;
            if (icon_InputEvent == null) { return; }
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchyIcon_InputEvent;
        }

        #endregion
        
        //----------------------------------------------------------------------------------------------------

        #region Private Functions

        private static void DrawHierarchyIcon_InputActionManager(int instanceID, Rect rect)
        {
            if (icon_InputActionManager == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<InputActionManager>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_InputActionManager);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_GMKInputController(int instanceID, Rect rect)
        {
            if (icon_GMKInputController == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<GMKInputController>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_GMKInputController);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_XRInputController(int instanceID, Rect rect)
        {
            if (icon_XRInputController == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<XRInputController>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_XRInputController);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        private static void DrawHierarchyIcon_InputEvent(int instanceID, Rect rect)
        {
            if (icon_InputEvent == null) { return; }
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) { return; }
            var component = gameObject.GetComponent<InputEvent>();
            if (component == null) { return; }
            float hierarchyPixelHeight = 16;
            EditorGUIUtility.SetIconSize(new Vector2(hierarchyPixelHeight, hierarchyPixelHeight));
            var iconPosition = new Rect(rect.xMax - hierarchyPixelHeight, rect.yMin, rect.width, rect.height);
            var iconGUIContent = new GUIContent(icon_InputEvent);
            EditorGUI.LabelField(iconPosition, iconGUIContent);
        }

        #endregion
        
    } // class end
}

#endif