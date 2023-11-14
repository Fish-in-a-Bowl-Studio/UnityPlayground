using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Code created by Gaskellgames
/// </summary>

namespace Gaskellgames
{

    #region 'ReadOnly' Attribute

    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
        
    } // class end

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region 'TagDropdown' Attribute

    /// <summary>
    /// Original by DYLAN ENGELMAN http://jupiterlighthousestudio.com/custom-inspectors-unity/
    /// Altered by Brecht Lecluyse https://www.brechtos.com
    /// Updated by Gaskellgames
    /// </summary>
    
    [CustomPropertyDrawer(typeof(TagDropdownAttribute))]
    public class TagDropdownPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType == SerializedPropertyType.String)
            {
                EditorGUI.BeginProperty(position, label, property);

                var dropdownAttribute = attribute as TagDropdownAttribute;

                if (dropdownAttribute.UseDefaultTagFieldDrawer)
                {
                    property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
                }
                else
                {
                    //generate the taglist + custom tags
                    List<string> tagList = new List<string>();
                    tagList.Add("<NoTag>");
                    tagList.AddRange(UnityEditorInternal.InternalEditorUtility.tags);
                    string propertyString = property.stringValue;
                    int index = -1;
                    if(propertyString =="")
                    {
                        //The tag is empty
                        index = 0; //first index is the special <notag> entry
                    }
                    else
                    {
                        //check if there is an entry that matches the entry and get the index - skip index 0 as that is a special custom case
                        for (int i = 1; i < tagList.Count; i++)
                        {
                            if (tagList[i] == propertyString)
                            {
                                index = i;
                                break;
                            }
                        }
                    }
                
                    //Draw the popup box with the current selected index
                    index = EditorGUI.Popup(position, label.text, index, tagList.ToArray());
 
                    //Adjust the displayed string value of the property based on the current selection
                    if(index==0)
                    {
                        property.stringValue = "";
                    }
                    else if (index >= 1)
                    {
                        property.stringValue = tagList[index];
                    }
                    else
                    {
                        property.stringValue = "";
                    }
                }
 
                EditorGUI.EndProperty();
            }
            else
            {
                EditorGUI.PropertyField(position, property, label);
            }
        }
        
    } // class end

    #endregion

    //----------------------------------------------------------------------------------------------------

    #region 'LineSeparator' Attribute

    [CustomPropertyDrawer(typeof(LineSeparatorAttribute))]
    public class LineSeparatorDraw : DecoratorDrawer
    {
        public override void OnGUI(Rect position)
        {
            // ref to attribute
            LineSeparatorAttribute lineSeparatorAttribute = attribute as LineSeparatorAttribute;
            
            // define the line
            Rect separatorRect = new Rect(position.xMin, position.yMin + lineSeparatorAttribute.SpacingBefore, position.width, lineSeparatorAttribute.Thickness);
            
            // draw line
            EditorGUI.DrawRect(separatorRect, new Color32(lineSeparatorAttribute.R, lineSeparatorAttribute.G, lineSeparatorAttribute.B, lineSeparatorAttribute.A));
        }

        public override float GetHeight()
        {
            LineSeparatorAttribute lineSeparatorAttribute = attribute as LineSeparatorAttribute;
            
            float totalSpacing = lineSeparatorAttribute.SpacingBefore + lineSeparatorAttribute.Thickness + lineSeparatorAttribute.SpacingAfter;

            return totalSpacing;
        }
    }
    
    #endregion
}
