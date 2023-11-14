using UnityEngine;
using UnityEngine.InputSystem;

using Gaskellgames;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames.InputEventSystem
{
    public class GMKInputController : MonoBehaviour
    {
        #region Variables

        [Space]
        [SerializeField] private bool legacyInputSystem = false;
        [SerializeField] private LegacyInputs legacyInputs;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField, ReadOnly] private UserInputs inputs;

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Game Loop

        void Update()
        {
            if (legacyInputSystem)
            {
                UpdateUserInputLegacy();
            }
            else
            {
                UpdateUserInput();
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region New Input System

        private void UpdateUserInput()
        {
            inputs.inputButton0.keydown = playerInput.actions["Input Button 0"].WasPressedThisFrame();
            inputs.inputButton0.keypressed = playerInput.actions["Input Button 0"].IsPressed();
            inputs.inputButton0.keyreleased = playerInput.actions["Input Button 0"].WasReleasedThisFrame();

            inputs.inputButton1.keydown = playerInput.actions["Input Button 1"].WasPressedThisFrame();
            inputs.inputButton1.keypressed = playerInput.actions["Input Button 1"].IsPressed();
            inputs.inputButton1.keyreleased = playerInput.actions["Input Button 1"].WasReleasedThisFrame();

            inputs.inputButton2.keydown = playerInput.actions["Input Button 2"].WasPressedThisFrame();
            inputs.inputButton2.keypressed = playerInput.actions["Input Button 2"].IsPressed();
            inputs.inputButton2.keyreleased = playerInput.actions["Input Button 2"].WasReleasedThisFrame();

            inputs.inputButton3.keydown = playerInput.actions["Input Button 3"].WasPressedThisFrame();
            inputs.inputButton3.keypressed = playerInput.actions["Input Button 3"].IsPressed();
            inputs.inputButton3.keyreleased = playerInput.actions["Input Button 3"].WasReleasedThisFrame();

            inputs.inputButton4.keydown = playerInput.actions["Input Button 4"].WasPressedThisFrame();
            inputs.inputButton4.keypressed = playerInput.actions["Input Button 4"].IsPressed();
            inputs.inputButton4.keyreleased = playerInput.actions["Input Button 4"].WasReleasedThisFrame();

            inputs.inputButton5.keydown = playerInput.actions["Input Button 5"].WasPressedThisFrame();
            inputs.inputButton5.keypressed = playerInput.actions["Input Button 5"].IsPressed();
            inputs.inputButton5.keyreleased = playerInput.actions["Input Button 5"].WasReleasedThisFrame();

            inputs.inputButton6.keydown = playerInput.actions["Input Button 6"].WasPressedThisFrame();
            inputs.inputButton6.keypressed = playerInput.actions["Input Button 6"].IsPressed();
            inputs.inputButton6.keyreleased = playerInput.actions["Input Button 6"].WasReleasedThisFrame();

            inputs.inputButton7.keydown = playerInput.actions["Input Button 7"].WasPressedThisFrame();
            inputs.inputButton7.keypressed = playerInput.actions["Input Button 7"].IsPressed();
            inputs.inputButton7.keyreleased = playerInput.actions["Input Button 7"].WasReleasedThisFrame();

            inputs.inputButton8.keydown = playerInput.actions["Input Button 8"].WasPressedThisFrame();
            inputs.inputButton8.keypressed = playerInput.actions["Input Button 8"].IsPressed();
            inputs.inputButton8.keyreleased = playerInput.actions["Input Button 8"].WasReleasedThisFrame();

            inputs.inputButton9.keydown = playerInput.actions["Input Button 9"].WasPressedThisFrame();
            inputs.inputButton9.keypressed = playerInput.actions["Input Button 9"].IsPressed();
            inputs.inputButton9.keyreleased = playerInput.actions["Input Button 9"].WasReleasedThisFrame();

            inputs.inputAxisX = playerInput.actions["Input Axis X Y"].ReadValue<Vector2>().x;
            inputs.inputAxisY = playerInput.actions["Input Axis X Y"].ReadValue<Vector2>().y;
            inputs.inputAxis4 = playerInput.actions["Input Axis 4 5"].ReadValue<Vector2>().x;
            inputs.inputAxis5 = playerInput.actions["Input Axis 4 5"].ReadValue<Vector2>().y;
            inputs.inputAxis6 = playerInput.actions["Input Axis 6 7"].ReadValue<Vector2>().x;
            inputs.inputAxis7 = playerInput.actions["Input Axis 6 7"].ReadValue<Vector2>().y;
            inputs.inputAxis9 = playerInput.actions["Input Axis 9"].ReadValue<float>();
            inputs.inputAxis10 = playerInput.actions["Input Axis 10"].ReadValue<float>();
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Legacy Input System

        private void UpdateUserInputLegacy()
        {
            inputs.inputButton0.keydown = Input.GetKeyDown(legacyInputs.button0);
            inputs.inputButton0.keypressed = Input.GetKey(legacyInputs.button0);
            inputs.inputButton0.keyreleased = Input.GetKeyUp(legacyInputs.button0);

            inputs.inputButton1.keydown = Input.GetKeyDown(legacyInputs.button1);
            inputs.inputButton1.keypressed = Input.GetKey(legacyInputs.button1);
            inputs.inputButton1.keyreleased = Input.GetKeyUp(legacyInputs.button1);

            inputs.inputButton2.keydown = Input.GetKeyDown(legacyInputs.button2);
            inputs.inputButton2.keypressed = Input.GetKey(legacyInputs.button2);
            inputs.inputButton2.keyreleased = Input.GetKeyUp(legacyInputs.button2);

            inputs.inputButton3.keydown = Input.GetKeyDown(legacyInputs.button3);
            inputs.inputButton3.keypressed = Input.GetKey(legacyInputs.button3);
            inputs.inputButton3.keyreleased = Input.GetKeyUp(legacyInputs.button3);

            inputs.inputButton4.keydown = Input.GetKeyDown(legacyInputs.button4);
            inputs.inputButton4.keypressed = Input.GetKey(legacyInputs.button4);
            inputs.inputButton4.keyreleased = Input.GetKeyUp(legacyInputs.button4);

            inputs.inputButton5.keydown = Input.GetKeyDown(legacyInputs.button5);
            inputs.inputButton5.keypressed = Input.GetKey(legacyInputs.button5);
            inputs.inputButton5.keyreleased = Input.GetKeyUp(legacyInputs.button5);

            inputs.inputButton6.keydown = Input.GetKeyDown(legacyInputs.button6);
            inputs.inputButton6.keypressed = Input.GetKey(legacyInputs.button6);
            inputs.inputButton6.keyreleased = Input.GetKeyUp(legacyInputs.button6);

            inputs.inputButton7.keydown = Input.GetKeyDown(legacyInputs.button7);
            inputs.inputButton7.keypressed = Input.GetKey(legacyInputs.button7);
            inputs.inputButton7.keyreleased = Input.GetKeyUp(legacyInputs.button7);

            inputs.inputButton8.keydown = Input.GetKeyDown(legacyInputs.button8);
            inputs.inputButton8.keypressed = Input.GetKey(legacyInputs.button8);
            inputs.inputButton8.keyreleased = Input.GetKeyUp(legacyInputs.button8);

            inputs.inputButton9.keydown = Input.GetKeyDown(legacyInputs.button9);
            inputs.inputButton9.keypressed = Input.GetKey(legacyInputs.button9);
            inputs.inputButton9.keyreleased = Input.GetKeyUp(legacyInputs.button9);

            inputs.inputAxisX = GetAxisValue(legacyInputs.axisXY_left, legacyInputs.axisXY_right);
            inputs.inputAxisY = GetAxisValue(legacyInputs.axisXY_up, legacyInputs.axisXY_down);
            inputs.inputAxis4 = GetAxisValue(legacyInputs.axis45_left, legacyInputs.axis45_right);
            inputs.inputAxis5 = GetAxisValue(legacyInputs.axis45_up, legacyInputs.axis45_down);
            inputs.inputAxis6 = GetAxisValue(legacyInputs.axis67_left, legacyInputs.axis67_right);
            inputs.inputAxis7 = GetAxisValue(legacyInputs.axis67_up, legacyInputs.axis67_down);
            inputs.inputAxis9 = GetAxisValue(legacyInputs.axis9);
            inputs.inputAxis10 = GetAxisValue(legacyInputs.axis10);
        }

        private float GetAxisValue(KeyCode button01)
        {
            if (Input.GetKey(button01))
            {
                return 1.0f;
            }
            else
            {
                return 0.0f;
            }
        }

        private float GetAxisValue(KeyCode button01, KeyCode button02)
        {
            if (Input.GetKey(button01) && !Input.GetKey(button02))
            {
                return -1.0f;
            }
            else if (!Input.GetKey(button01) && Input.GetKey(button02))
            {
                return 1.0f;
            }
            else
            {
                return 0.0f;
            }
        }

        #endregion

        //----------------------------------------------------------------------------------------------------

        #region Public Functions

        public UserInputs GetUserInputs()
        {
            return inputs;
        }

        #endregion
        
        //----------------------------------------------------------------------------------------------------
        
        #region Getter / Setter
        
        public PlayerInput PlayerInput
        {
            get { return playerInput; }
            set { playerInput = value; }
        }

        #endregion

    } // class end
}