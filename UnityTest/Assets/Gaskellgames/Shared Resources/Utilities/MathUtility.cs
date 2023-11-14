using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames
{
    public class MathUtility
    {
        #region Rounding

        public static float RoundFloat(float value, int decimalPlaces)
        {
            return Mathf.Round(value * Mathf.Pow(10, decimalPlaces)) / Mathf.Pow(10, decimalPlaces);
        }
        
        public static Vector2 RoundVector2(Vector2 value, int decimalPlaces)
        {
            return new Vector2(RoundFloat(value.x, decimalPlaces), RoundFloat(value.y, decimalPlaces));
        }
        
        public static Vector3 RoundVector3(Vector3 value, int decimalPlaces)
        {
            return new Vector3(RoundFloat(value.x, decimalPlaces), RoundFloat(value.y, decimalPlaces), RoundFloat(value.z, decimalPlaces));
        }
        
        public static Vector4 RoundVector(Vector4 value, int decimalPlaces)
        {
            return new Vector4(RoundFloat(value.x, decimalPlaces), RoundFloat(value.y, decimalPlaces), RoundFloat(value.z, decimalPlaces), RoundFloat(value.w, decimalPlaces));
        }

        #endregion
    }
}
