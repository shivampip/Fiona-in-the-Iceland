using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System;


namespace TornadoBanditsStudio.LowPolyFreePack
{
    /// <summary>
    /// Editor Initializer Custom Inspector.
    /// Shows the Tutorial Window and checks if the required plugins are available.
    /// </summary>
    [InitializeOnLoad]
    public static class TBS_EditorInitializer
    {
        static TBS_EditorInitializer ()
        {
            EditorApplication.update += ShowPresentationWindow;
        }

        static void ShowPresentationWindow ()
        {
            EditorApplication.update -= ShowPresentationWindow;
            //If the tutorial isn't done then open the window
            if (EditorPrefs.HasKey ("TBS_FP") == false)
            {
                EditorPrefs.SetInt ("TBS_FP", 1);
                TBS_PresentationWindow.InitializePresentationWindow ();
                TBS_PresentationWindow.presentationWindow.Focus ();         
            }
        }
    }
}
