using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.CameraController
{
    public class CameraSwitcher : MonoBehaviour
    {
        #region Variables

        [Space] [SerializeField] private CameraBrain cameraBrain;
        [Tooltip("Use the global camera list")]
        [SerializeField] private bool useRegisteredList = true;
        [LineSeparator]
        [SerializeField] private InputActionProperty switchCamera;
        [LineSeparator]
        [SerializeField] private List<CameraRig> customCameraRigsList;

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Reset / Debug [Editor]

#if UNITY_EDITOR

        private void Reset()
        {
            if (GetComponent<CameraBrain>() != null)
            {
                cameraBrain = GetComponent<CameraBrain>();
            }
        }

#endif

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Game loop

        private void OnEnable()
        {
            switchCamera.action.performed += switchCameraCallback;
            switchCamera.action.Enable();
        }

        private void OnDisable()
        {
            switchCamera.action.performed -= switchCameraCallback;
            switchCamera.action.Disable();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Input Action Callbacks

        private void switchCameraCallback(InputAction.CallbackContext context)
        {
            SwitchToNextCamera();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Private Functions

        private void SwitchToNextCamera()
        {
            if(cameraBrain != null)
            {
                List<CameraRig> registeredCameras = CameraList.GetCameraRigList();

                if (useRegisteredList && 1 < registeredCameras.Count)
                {
                    SelectNextCamera(registeredCameras);
                }
                else if(1 < customCameraRigsList.Count)
                {
                    SelectNextCamera(customCameraRigsList);
                }
            }
        }

        private void SelectNextCamera(List<CameraRig> cameraList)
        {
            CameraRig active = cameraBrain.GetActiveCamera();
            int activeIndex = -1;

            for (int i = 0; i < cameraList.Count; i++)
            {
                if (cameraList[i] == active)
                {
                    activeIndex = i;
                }
            }

            if (activeIndex != -1)
            {
                if (activeIndex == cameraList.Count - 1)
                {
                    activeIndex = 0;
                }
                else
                {
                    activeIndex++;
                }
                cameraBrain.SetActiveCamera(cameraList[activeIndex]);
            }
            else
            {
                cameraBrain.SetActiveCamera(cameraList[0]);
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Getters / Setters

        public void ToggleNextCamera()
        {
            SwitchToNextCamera();
        }

        #endregion


    } // class end
}


