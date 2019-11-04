using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(Interactible))]
public class InteractibleEditor : Editor
{
    private SerializedProperty YourList;


    private ReorderableList YourReorderableList;

    private void OnEnable()
    {
        // Step 1 "link" the SerializedProperties to the properties of YourOtherClass
        YourList = serializedObject.FindProperty("UIActionButtons");

        // Step 2 setup the ReorderableList
        YourReorderableList = new ReorderableList(serializedObject, YourList)
        {
            // Can your objects be dragged an their positions changed within the List?
            draggable = true,

            // Can you add elements by pressing the "+" button?
            displayAdd = true,

            // Can you remove Elements by pressing the "-" button?
            displayRemove = true,

            // Make a header for the list
            drawHeaderCallback = rect =>
            {
                EditorGUI.LabelField(rect, "This are your Elements");
            },

            // Now to the interesting part: Here you setup how elements look like
            drawElementCallback = (rect, index, active, focused) =>
            {
                // Get the currently to be drawn element from YourList
                var element = YourList.GetArrayElementAtIndex(index);

                // Get the elements Properties into SerializedProperties
                var Image = element.FindPropertyRelative("TextureImage");
                var Event = element.FindPropertyRelative("Event");

                // Draw the Enum field
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), Image);
                // start the next property in the next line
                rect.y += EditorGUIUtility.singleLineHeight;

                

                // Draw the Step field
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), Event);
                // start the next property in the next line
                rect.y += EditorGUIUtility.singleLineHeight;                
            },

         
            elementHeight = EditorGUIUtility.singleLineHeight * 8,

           
            onAddCallback = list =>
            {
                // The new index will be the current List size ()before adding
                var index = list.serializedProperty.arraySize;

                // Since this method overwrites the usual adding, we have to do it manually:
                // Simply counting up the array size will automatically add an element
                list.serializedProperty.arraySize++;
                list.index = index;
                var element = list.serializedProperty.GetArrayElementAtIndex(index);

                // again link the properties of the element in SerializedProperties
                var Image = element.FindPropertyRelative("TextureImage");
                var Event = element.FindPropertyRelative("Event");

                

            }
        };
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        // copy the values of the real Class to the linked SerializedProperties
        serializedObject.Update();

        // print the reorderable list
        YourReorderableList.DoLayoutList();

        // apply the changed SerializedProperties values to the real class
        serializedObject.ApplyModifiedProperties();
    }
}