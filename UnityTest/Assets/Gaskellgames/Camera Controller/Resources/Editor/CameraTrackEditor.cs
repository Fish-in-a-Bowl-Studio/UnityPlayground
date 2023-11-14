#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    [CustomEditor(typeof(CameraTrack))] [CanEditMultipleObjects]
    public class CameraTrackEditor : Editor
    {
        #region Serialized Properties / OnEnable

        SerializedProperty nodeScale;
        SerializedProperty waypointScale;
        SerializedProperty nodeColor;
        SerializedProperty trackColor;
        
        SerializedProperty gizmosOnSelected;
        SerializedProperty showAllHandles;
        SerializedProperty autoUpdateTrack;
        SerializedProperty showNodes;
        SerializedProperty element0IsOrigin;
        SerializedProperty showTrack;
        SerializedProperty closedLoop;
        SerializedProperty showWaypoints;
        
        SerializedProperty updateTrack;
        SerializedProperty trackType;
        SerializedProperty subdivisions;
        SerializedProperty tension;
        SerializedProperty nodes;
        
        SerializedProperty trackLength;

        private bool gizmoGroup;
        
        private void OnEnable()
        {
            nodeScale = serializedObject.FindProperty("nodeScale");
            waypointScale = serializedObject.FindProperty("waypointScale");
            nodeColor = serializedObject.FindProperty("nodeColor");
            trackColor = serializedObject.FindProperty("trackColor");
            
            gizmosOnSelected = serializedObject.FindProperty("gizmosOnSelected");
            showAllHandles = serializedObject.FindProperty("showAllHandles");
            autoUpdateTrack = serializedObject.FindProperty("autoUpdateTrack");
            showNodes = serializedObject.FindProperty("showNodes");
            element0IsOrigin = serializedObject.FindProperty("element0IsOrigin");
            showTrack = serializedObject.FindProperty("showTrack");
            closedLoop = serializedObject.FindProperty("closedLoop");
            showWaypoints = serializedObject.FindProperty("showWaypoints");
            
            trackType = serializedObject.FindProperty("trackType");
            subdivisions = serializedObject.FindProperty("subdivisions");
            tension = serializedObject.FindProperty("tension");
            nodes = serializedObject.FindProperty("nodes");
            updateTrack = serializedObject.FindProperty("updateTrack");
            
            trackLength = serializedObject.FindProperty("trackLength");
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region OnSceneGUI

        private void OnSceneGUI()
        {
            // get & update references
            CameraTrack cameraTrack = (CameraTrack)target;
            
            if(cameraTrack == null) { return; }

            if (cameraTrack.ShowAllHandles)
            {
                for (int i = 0; i < cameraTrack.Nodes.Count; i++)
                {
                    Handles.Label(cameraTrack.Node(i) + new Vector3(0, -0.25f, 0), cameraTrack.name + ": Node " + i);
                    EditorGUI.BeginChangeCheck();
                    Vector3 handle = Handles.PositionHandle(cameraTrack.Node(i), Quaternion.identity);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(cameraTrack, "Moved Node");
                        cameraTrack.Node(i, handle);
                    }
                }
            }
            else
            {
                for (int i = 0; i < cameraTrack.Nodes.Count; i++)
                {
                    Handles.Label(cameraTrack.Node(i) + new Vector3(0, -0.25f, 0), cameraTrack.name + ": Node " + i);
                }
                EditorGUI.BeginChangeCheck();
                Vector3 handle = Handles.PositionHandle(cameraTrack.Node(cameraTrack.SelectedIndex), Quaternion.identity);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(cameraTrack, "Moved Node");
                    cameraTrack.Node(cameraTrack.SelectedIndex, handle);
                }
            }
        }

        #endregion
        
        //----------------------------------------------------------------------------------------------------

        #region OnInspectorGUI

        public override void OnInspectorGUI()
        {
            // get & update references
            CameraTrack cameraTrack = (CameraTrack)target;
            serializedObject.Update();

            /*
            // draw default inspector
            base.OnInspectorGUI();
            */

            // banner
            Texture banner = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Gaskellgames/Camera Controller/Resources/Icons/inspectorBanner_CameraController.png", typeof(Texture));
            GUILayout.Box(banner, GUILayout.ExpandWidth(true), GUILayout.Height(Screen.width / 7.5f));

            // custom inspector
            gizmoGroup = EditorGUILayout.BeginFoldoutHeaderGroup(gizmoGroup, "Gizmo Settings");
            if (gizmoGroup)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(nodeScale);
                EditorGUILayout.PropertyField(waypointScale);
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(nodeColor);
                EditorGUILayout.PropertyField(trackColor);
                EditorGUILayout.Space();
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFoldoutHeaderGroup();
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(gizmosOnSelected);
            EditorGUILayout.PropertyField(showAllHandles);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(autoUpdateTrack);
            EditorGUILayout.PropertyField(showNodes);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(element0IsOrigin);
            EditorGUILayout.PropertyField(showTrack);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(showWaypoints);
            EditorGUILayout.PropertyField(closedLoop);
            EditorGUILayout.EndHorizontal();
            // LineSeparator
            EditorGUILayout.PropertyField(trackLength);
            if (cameraTrack.Nodes != null && cameraTrack.Nodes.Count != 0 && !showAllHandles.boolValue)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Selected Node");
                if (GUILayout.Button("<"))
                {
                    // check handle index within scope
                    if (cameraTrack.SelectedIndex >= 1)
                    {
                        cameraTrack.SelectedIndex--;
                        SceneView.RepaintAll();
                    }
                }
                var style = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter};
                GUILayout.Label("Node: " + cameraTrack.SelectedIndex, style, GUILayout.MinWidth(100), GUILayout.MaxWidth(100));
                if (GUILayout.Button(">"))
                {
                    // check handle index within scope
                    if (cameraTrack.SelectedIndex < cameraTrack.Nodes.Count - 1)
                    {
                        cameraTrack.SelectedIndex++;
                        SceneView.RepaintAll();
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            // LineSeparator
            EditorGUILayout.PropertyField(trackType);
            EditorGUILayout.PropertyField(subdivisions);
            if(cameraTrack.TrackType == "CatmullRomSpline") { EditorGUILayout.PropertyField(tension); }
            EditorGUILayout.PropertyField(nodes);
            if (cameraTrack.Nodes.Count < 2 && cameraTrack.TrackType == "Linear")
            {
                EditorGUILayout.Space();
                EditorGUILayout.HelpBox( "Not enough nodes to generate Linear path (require 2+ nodes)", MessageType.Warning);
            }
            else if (cameraTrack.Nodes.Count < 4 && cameraTrack.TrackType != "Linear")
            {
                EditorGUILayout.Space();
                EditorGUILayout.HelpBox( "Not enough nodes to generate Spline curve (require 4+ nodes)", MessageType.Warning);
            }
            if (!autoUpdateTrack.boolValue)
            {
                EditorGUILayout.Space();
                if (GUILayout.Button("Update Track")) { updateTrack.boolValue = true; }
            }
            
            // apply reference changes
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
        
    } // class end
}
#endif