using UnityEngine;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames
{
    [System.Serializable]
    public class XRInputs
    {
        #region Variables

        public XRButtonInputsTouch primaryButton;
        public XRButtonInputsTouch secondaryButton;
        public XRButtonInputsTouch joystickButton;
        public ButtonInputs menuButton;

        [Range(-1, 1)] public float joystickHorizontal;
        [Range(-1, 1)] public float joystickVertical;
        [Range(0, 1)] public float triggerAxis;
        public bool triggerTouch;
        [Range(0, 1)] public float gripAxis;

        #endregion

    } // class end
}
