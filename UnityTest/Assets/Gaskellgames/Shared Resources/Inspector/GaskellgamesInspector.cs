using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gaskellgames
{
    #region Inspector Events

    [Serializable]
    public class InspectorEvent : UnityEvent { }

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region 'ReadOnly' Attribute

    public class ReadOnlyAttribute : PropertyAttribute { }

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region 'TagDropdown' Attribute

    // e.g: public string TagFilter = "";

    public class TagDropdownAttribute : PropertyAttribute
    {
        public bool UseDefaultTagFieldDrawer = false;
    }

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region 'LineSeparator' Attribute

    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
    public class LineSeparatorAttribute : PropertyAttribute
    {
        public readonly float Thickness;
        public readonly byte R;
        public readonly byte G;
        public readonly byte B;
        public readonly byte A;
        public readonly int SpacingBefore;
        public readonly int SpacingAfter;

        public LineSeparatorAttribute()
        {
            Thickness = 1;
            SpacingBefore = 10;
            SpacingAfter = 10;
            R = 000;
            G = 028;
            B = 045;
            A = 255;
        }

        public LineSeparatorAttribute(float thickness)
        {
            Thickness = thickness;
            SpacingBefore = 10;
            SpacingAfter = 10;
            R = 000;
            G = 028;
            B = 045;
            A = 255;
        }

        public LineSeparatorAttribute(int spacingBefore, int spacingAfter)
        {
            Thickness = 1;
            SpacingBefore = spacingBefore;
            SpacingAfter = spacingAfter;
            R = 000;
            G = 028;
            B = 045;
            A = 255;
        }

        public LineSeparatorAttribute(byte r, byte g, byte b, byte a)
        {
            Thickness = 1;
            SpacingBefore = 10;
            SpacingAfter = 10;
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public LineSeparatorAttribute(float thickness = 1.0f, int spacingBefore = 10, int spacingAfter = 10, byte r = 000, byte g = 028, byte b = 045, byte a = 255)
        {
            Thickness = thickness;
            SpacingBefore = spacingBefore;
            SpacingAfter = spacingAfter;
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    #endregion

} // class end
