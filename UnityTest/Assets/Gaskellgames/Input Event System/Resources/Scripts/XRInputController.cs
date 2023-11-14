using UnityEngine;
using UnityEngine.InputSystem;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.InputEventSystem
{
    public class XRInputController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private PlayerInput playerInput;
        [SerializeField, ReadOnly] private XRInputs leftHand;
        [SerializeField, ReadOnly] private XRInputs rightHand;

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Game Loop

        void Update()
        {
            UpdateUserInputs();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region User Inputs

        private void UpdateUserInputs()
        {
            // left hand
            if (leftHand != null)
            {
                leftHand.menuButton.keydown = playerInput.actions["Left Menu Button"].WasPressedThisFrame();
                leftHand.menuButton.keypressed = playerInput.actions["Left Menu Button"].IsPressed();
                leftHand.menuButton.keyreleased = playerInput.actions["Left Menu Button"].WasReleasedThisFrame();

                leftHand.primaryButton.keytouched = playerInput.actions["Left Primary Touch"].IsPressed();
                leftHand.primaryButton.keydown = playerInput.actions["Left Primary Button"].WasPressedThisFrame();
                leftHand.primaryButton.keypressed = playerInput.actions["Left Primary Button"].IsPressed();
                leftHand.primaryButton.keyreleased = playerInput.actions["Left Primary Button"].WasReleasedThisFrame();

                leftHand.secondaryButton.keytouched = playerInput.actions["Left Secondary Touch"].IsPressed();
                leftHand.secondaryButton.keydown = playerInput.actions["Left Secondary Button"].WasPressedThisFrame();
                leftHand.secondaryButton.keypressed = playerInput.actions["Left Secondary Button"].IsPressed();
                leftHand.secondaryButton.keyreleased = playerInput.actions["Left Secondary Button"].WasReleasedThisFrame();

                leftHand.joystickButton.keytouched = playerInput.actions["Left Joystick Touch"].IsPressed();
                leftHand.joystickButton.keydown = playerInput.actions["Left Joystick Button"].WasPressedThisFrame();
                leftHand.joystickButton.keypressed = playerInput.actions["Left Joystick Button"].IsPressed();
                leftHand.joystickButton.keyreleased = playerInput.actions["Left Joystick Button"].WasReleasedThisFrame();

                leftHand.joystickHorizontal = playerInput.actions["Left Joystick Axis"].ReadValue<Vector2>().x;
                leftHand.joystickVertical = playerInput.actions["Left Joystick Axis"].ReadValue<Vector2>().y;

                leftHand.triggerTouch = playerInput.actions["Left Trigger Touch"].IsPressed();
                leftHand.triggerAxis = playerInput.actions["Left Trigger Axis"].ReadValue<float>();

                leftHand.gripAxis = playerInput.actions["Left Grip Axis"].ReadValue<float>();
            }

            // right hand
            if (rightHand != null)
            {
                rightHand.menuButton.keydown = playerInput.actions["Right Menu Button"].WasPressedThisFrame();
                rightHand.menuButton.keypressed = playerInput.actions["Right Menu Button"].IsPressed();
                rightHand.menuButton.keyreleased = playerInput.actions["Right Menu Button"].WasReleasedThisFrame();

                rightHand.primaryButton.keytouched = playerInput.actions["Right Primary Touch"].IsPressed();
                rightHand.primaryButton.keydown = playerInput.actions["Right Primary Button"].WasPressedThisFrame();
                rightHand.primaryButton.keypressed = playerInput.actions["Right Primary Button"].IsPressed();
                rightHand.primaryButton.keyreleased = playerInput.actions["Right Primary Button"].WasReleasedThisFrame();

                rightHand.secondaryButton.keytouched = playerInput.actions["Right Secondary Touch"].IsPressed();
                rightHand.secondaryButton.keydown = playerInput.actions["Right Secondary Button"].WasPressedThisFrame();
                rightHand.secondaryButton.keypressed = playerInput.actions["Right Secondary Button"].IsPressed();
                rightHand.secondaryButton.keyreleased = playerInput.actions["Right Secondary Button"].WasReleasedThisFrame();

                rightHand.joystickButton.keytouched = playerInput.actions["Right Joystick Touch"].IsPressed();
                rightHand.joystickButton.keydown = playerInput.actions["Right Joystick Button"].WasPressedThisFrame();
                rightHand.joystickButton.keypressed = playerInput.actions["Right Joystick Button"].IsPressed();
                rightHand.joystickButton.keyreleased = playerInput.actions["Right Joystick Button"].WasReleasedThisFrame();

                rightHand.joystickHorizontal = playerInput.actions["Right Joystick Axis"].ReadValue<Vector2>().x;
                rightHand.joystickVertical = playerInput.actions["Right Joystick Axis"].ReadValue<Vector2>().y;

                rightHand.triggerTouch = playerInput.actions["Right Trigger Touch"].IsPressed();
                rightHand.triggerAxis = playerInput.actions["Right Trigger Axis"].ReadValue<float>();

                rightHand.gripAxis = playerInput.actions["Right Grip Axis"].ReadValue<float>();
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Public Functions

        public XRInputs GetLeftHandInputs()
        {
            return leftHand;
        }

        public XRInputs GetRightHandInputs()
        {
            return rightHand;
        }

        #endregion
        
        //----------------------------------------------------------------------------------------------------
        
        #region Getter / Setter
        
        public PlayerInput PlayerInput
        {
            get { return playerInput; }
            set{ playerInput = value; }
        }

        #endregion

    } // class end
}