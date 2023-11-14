#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.InputEventSystem
{
    public class GaskellgamesMenuItemInputEventSystem : GaskellgamesMenuItem
    {
        #region Tools Menu

        private const string GaskellgamesToolsMenu_InputActions = GaskellgamesToolsMenu + "/Input Event System";

        #endregion
        
        //----------------------------------------------------------------------------------------------------

        #region GameObject Menu
        
        private const string GaskellgamesGameobjectMenu_InputActions = GaskellgamesGameobjectMenu + "/Input Event System";
        
        [MenuItem(GaskellgamesGameobjectMenu_InputActions + "/Input Actions Manager", false, 10)]
        private static void Gaskellgames_GameobjectMenu_InputActionsManager()
        {
            // Create a custom game object
            GameObject go = new GameObject("InputActionsManager");
            
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
            
            // Add scripts & components
            go.transform.position = Vector3.zero;
            InputActionManager iam = go.AddComponent<InputActionManager>();
            iam.SetupInputActionManager();
        }
        
        [MenuItem(GaskellgamesGameobjectMenu_InputActions + "/Input Actions Manager", true, 10)]
        private static bool Gaskellgames_GameobjectMenu_InputActionsManagerValidate()
        {
            InputActionManager exists = GameObject.FindObjectOfType<InputActionManager>();
            if (exists) { return false; } else { return true; }
        }
        
        [MenuItem(GaskellgamesGameobjectMenu_InputActions + "/Input Event", false, 25)]
        private static void Gaskellgames_GameobjectMenu_InputEvent()
        {
            // Create a custom game object
            GameObject go = new GameObject("InputEvent");
            
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
            
            // Add scripts & components
            go.transform.position = Vector3.zero;
            go.AddComponent<InputEvent>();
        }
        
        [MenuItem(GaskellgamesGameobjectMenu_InputActions + "/Input Controller (Gamepad, Mouse, Keyboard)", false, 40)]
        private static GMKInputController Gaskellgames_GameobjectMenu_GMKInputController()
        {
            // add input action manager
            AddInputActionsManager();
            
            // Create a custom game object
            GameObject go = new GameObject("InputController (GMK)");
            
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
            
            // Add scripts & components
            go.transform.position = Vector3.zero;
            GMKInputController gmk = go.AddComponent<GMKInputController>();
            PlayerInput pi = go.AddComponent<PlayerInput>();
            gmk.PlayerInput = pi;
            pi.actions = AssetDatabase.LoadAssetAtPath<InputActionAsset>("Assets/Gaskellgames/Input Event System/Resources/Input Actions/InputActionsGaskellgames.inputactions");

            return gmk;
        }
        
        [MenuItem(GaskellgamesGameobjectMenu_InputActions + "/Input Controller (Extended Reality)", false, 40)]
        private static void Gaskellgames_GameobjectMenu_XRInputController()
        {
            // add input action manager
            AddInputActionsManager();
            
            // Create a custom game object
            GameObject go = new GameObject("InputController (XR)");
            
            // Register the creation in the undo system
            Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
            Selection.activeObject = go;
            
            // Add scripts & components
            go.transform.position = Vector3.zero;
            XRInputController pic = go.AddComponent<XRInputController>();
            PlayerInput pi = go.AddComponent<PlayerInput>();
            pic.PlayerInput = pi;
            pi.actions = AssetDatabase.LoadAssetAtPath<InputActionAsset>("Assets/Gaskellgames/Input Event System/Resources/Input Actions/InputActionsGaskellgames.inputactions");
        }
        
        #endregion
        
        //----------------------------------------------------------------------------------------------------

        #region Public Functions

        public static GMKInputController AddPlayerInputController()
        {
            return Gaskellgames_GameobjectMenu_GMKInputController();
        }

        public static void AddInputActionsManager()
        {
            if (Gaskellgames_GameobjectMenu_InputActionsManagerValidate())
            {
                Gaskellgames_GameobjectMenu_InputActionsManager();
            }
        }

        #endregion
        
    } // class end
}

#endif