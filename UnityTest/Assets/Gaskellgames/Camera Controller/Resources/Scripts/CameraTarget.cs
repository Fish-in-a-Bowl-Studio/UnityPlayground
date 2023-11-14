using System;
using UnityEngine;
using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    public class CameraTarget : MonoBehaviour
    {
        #region Variables

        enum TargetTypes
        {
            OnEnable,
            OnTrigger
        }

        [SerializeField] private TargetTypes targetType = TargetTypes.OnEnable;
        [SerializeField] private bool autoFindMultiTarget = true;
        [SerializeField] private CameraMultiTarget multiTarget;
        
        [Tooltip("Add a cameraBrain to set the active camera to the 'CameraSensor' cameraRig during OnTriggerEnter")]
        [Space, SerializeField] private CameraBrain cameraBrain;
        [SerializeField, TagDropdown] private string triggerTag = "";
        [SerializeField] private bool revertOnExit;
        private CameraRig previousCamera;
        
        [Space, SerializeField] private InspectorEvent OnEnterTag;
        [Space, SerializeField] private InspectorEvent OnExitTag;

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Events

        private void OnEnable()
        {
            if(targetType == TargetTypes.OnEnable)
            {
                if (autoFindMultiTarget)
                {
                    multiTarget = FindObjectOfType<CameraMultiTarget>();
                }

                multiTarget.AddTargetToList(transform);
            }
        }

        private void OnDisable()
        {
            if (targetType == TargetTypes.OnEnable)
            {
                multiTarget.RemoveTargetFromList(transform);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (targetType == TargetTypes.OnTrigger)
            {
                if (other.CompareTag(tag))
                {
                    if(cameraBrain != null)
                    {
                        CameraTriggerZone cameraTriggerZone = other.GetComponent<CameraTriggerZone>();
                        if (cameraTriggerZone != null)
                        {
                            previousCamera = cameraBrain.GetActiveCamera();
                            cameraBrain.SetActiveCamera(cameraTriggerZone.GetCameraRig());
                        }
                    }

                    CameraMultiTarget cameraMultiTarget = other.GetComponent<CameraMultiTarget>();
                    if(cameraMultiTarget != null)
                    {
                        cameraMultiTarget.AddTargetToList(transform);
                    }

                    OnEnterTag.Invoke();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (targetType == TargetTypes.OnTrigger)
            {
                if (other.CompareTag(tag))
                {
                    if(revertOnExit)
                    {
                        cameraBrain.SetActiveCamera(previousCamera);
                    }

                    CameraMultiTarget cameraMultiTarget = other.GetComponent<CameraMultiTarget>();
                    if (cameraMultiTarget != null)
                    {
                        cameraMultiTarget.RemoveTargetFromList(transform);
                    }

                    OnExitTag.Invoke();
                }
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Getter / Setter

        public string GetTargetType()
        {
            return targetType.ToString();
        }

        #endregion

    } //class end
}
