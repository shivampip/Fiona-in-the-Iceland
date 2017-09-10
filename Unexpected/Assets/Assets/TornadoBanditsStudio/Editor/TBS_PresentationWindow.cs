using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace TornadoBanditsStudio.LowPolyFreePack
{
    public class TBS_PresentationWindow : EditorWindow
    {
        #region LOGO_PATHS
        private const string logoPath = "Assets/TornadoBanditsStudio/Logo/TBSLogo.png";
        private const string facebookLogoPath = "Assets/TornadoBanditsStudio/Logo/facebook_icon.png";
        private const string mailLogoPath = "Assets/TornadoBanditsStudio/Logo/mail_icon.png";
        private const string siteLogoPath = "Assets/TornadoBanditsStudio/Logo/web_icon.png";
        private const string warningIconPath = "Assets/TornadoBanditsStudio/Logo/warningIcon.png";
        #endregion

        #region LOGOS_TEXTURES
        private static Texture2D logo = null;
        private static Texture2D facebookLogo = null;
        private static Texture2D mailLogo = null;
        private static Texture2D siteLogo = null;
        private static Texture2D warningIcon = null;
        #endregion

        #region URLS REGIONS
        private static string FACEBOOK_URL = "http://tinyurl.com/tornadobanditsstudio";
        private static string MAIL_URL = "mailto:contact@tornadobandits.com.com";
        private static string SITE_URL = "www.tornadobandits.com";
        #endregion

        public static TBS_PresentationWindow presentationWindow;

        [MenuItem ("Tornado Bandits Studio/Package Presentation")]
        public static void InitializePresentationWindow ()
        {
            // Get existing open window or if none, make a new one:
            presentationWindow = (TBS_PresentationWindow) EditorWindow.GetWindowWithRect (typeof (TBS_PresentationWindow), new Rect (0, 0, 512, 600), true, "Package Presentation");
            presentationWindow.Show ();
        }

        void OnEnable ()
        {
            if (logo == null)
            {
                logo = (Texture2D) AssetDatabase.LoadAssetAtPath (logoPath, typeof (Texture2D));
                facebookLogo = (Texture2D) AssetDatabase.LoadAssetAtPath (facebookLogoPath, typeof (Texture2D));
                mailLogo = (Texture2D) AssetDatabase.LoadAssetAtPath (mailLogoPath, typeof (Texture2D));
                siteLogo = (Texture2D) AssetDatabase.LoadAssetAtPath (siteLogoPath, typeof (Texture2D));
                warningIcon = (Texture2D) AssetDatabase.LoadAssetAtPath (warningIconPath, typeof (Texture2D));
            }

            if (customFont == null)
                customFont = (Font) AssetDatabase.LoadAssetAtPath ("Assets/TornadoBanditsStudio/Logo/CaviarDreams.ttf", typeof (Font));
        }

        void OnGUI ()
        {

            //Set gui skins
            SetGUISkins ();

            //Apply a texture on our editor window and apply it
            EditorGUILayout.BeginVertical (simpleBackgroundColor);
            scrollPosition = GUILayout.BeginScrollView (scrollPosition);

            GUILayout.Space (20);
            GUILayout.Label ("Low Poly Free Pack", textTitleGUISkin);

            GUILayout.Space (15);

            if (logo)
                GUILayout.Label (logo, iconGUISkin, GUILayout.Height (256), GUILayout.Width (256), GUILayout.ExpandWidth (true));

            GUILayout.Label ("Firstly, we would like to say that we thank you for trusting us.", simpleMiddleTextGUISkin);
            GUILayout.Space (15);
            GUILayout.Label ("Version 0.1", linkTextGUISkin);
            GUILayout.Space (15);
            GUILayout.Label ("    With the launch of our newest pack: Low Poly Dungeons Pack We've added 17 new low poly meshes and a new demo scene.\n    We've also changed the old image effects to the new Post Processing Stack and updated the documentation.", simpleTextGUISkin);

            GUILayout.Space (15);
            if (GUILayout.Button ("Low Poly Dungeons Pack", linkTextGUISkin))
            {
                Application.OpenURL ("https://www.assetstore.unity3d.com/en/#!/content/94002");
            }

            GUILayout.Space (15);

            GUILayout.Space (15);
            GUILayout.Label ("    This is a small presentation window that will introduce you into our Low Poly Free Package.\n\n    If you have any question don't hesitate to contact us.", simpleTextGUISkin);

            GUILayout.Space (15);
            GUILayout.Label ("    Our project's assets are packed in a single folder, called TornadoBanditsStudio. The Editor and Logo folders are used only for this presentation. The main assets of the package are childs of the folder called Low Poly Free Pack.", simpleTextGUISkin);
            GUILayout.Space (10);
            GUILayout.Label ("    Meshes may be located in the folder called Meshes while the prefabs may be found in the Prefabs folder.\n\n\n    Most of the meshes are used in our demo scenes, that may be found in DemoScenes folder.", simpleTextGUISkin);

            GUILayout.Space (25);
            GUILayout.Label ("    Meshes and Prefabs folders are split in different subfolders that helped us to organise the models.\n\n    In the prefabs folder we have created different complex prefabs that will help you create your enviornments faster.\n\n    We recommend you, if you want to create your own scenes to use the prefabs folder, because each prefab has a collider.", simpleTextGUISkin);

            GUILayout.Space (20);
            GUILayout.Label ("    You will also be able to find some particles that fit the art direction of the package. You will be able to find them in the Particles folder.", simpleTextGUISkin);

            GUILayout.Space (20);
            GUILayout.Label ("    We have also created some skyboxes and sprites that may help with your scenes backgrounds.", simpleTextGUISkin);

            GUILayout.Space (20);
            GUILayout.Label ("    In the Scripts folder you will be able to find some behaviours that might help you creating small effects for your scenes.\n\n- TBS_Water to create a low poly water. The water calculations are done on CPU and not on GPU, so it isn't the most optimized water for a mobile device (see some examples in the Water folder)\n- TBS_CameraMovement that moves the camera (or any other object) to a point in a given time.", simpleTextGUISkin);

            GUILayout.Space (50);
            if (warningIcon)
                GUILayout.Label (warningIcon, iconGUISkin, GUILayout.Height (50), GUILayout.Width (50), GUILayout.ExpandWidth (true));

            GUILayout.Label ("    To achieve the camera effects presented in our package's trailer, you will need to download Unity's Post Processing Stack. We will leave a link below. After you download it, select a camera add the component PostProcessingBehaviour and after that in it's field drag and drop the Post Processing Settings made by us. You will be able to find them in the DemoScenes folder.\n\n    If you will import the pack all the existing scenes will be set up automatically.", simpleTextGUISkin);

            GUILayout.Space (15);
            if (GUILayout.Button ("Download Post Processing Stack now", linkTextGUISkin))
            {
                Application.OpenURL ("https://www.assetstore.unity3d.com/en/#!/content/83912");
            }
          
            //Space
            GUILayout.Space (40);

            GUILayout.Label ("    To achieve the camera fog effects present in the scenes Palm_Tree_Scene and Pine_Tree_Scene you will have to import in the project the Unity Legacy Image Effects.", simpleTextGUISkin);
            GUILayout.Space (15);

            if (GUILayout.Button ("Download Legacy Image Effects now", linkTextGUISkin))
            {
                Application.OpenURL ("https://www.assetstore.unity3d.com/en/#!/content/51515");
            }

            GUILayout.Space (40);

            GUI.backgroundColor = Color.clear;
            //Buttons part
            GUILayout.BeginHorizontal (simpleHorizontalGroup);
            GUILayout.Space (100);
            if (GUILayout.Button (facebookLogo, GUILayout.Width (45), GUILayout.Height (45)))
                Application.OpenURL (FACEBOOK_URL);
            GUILayout.Space (70);
            if (GUILayout.Button (siteLogo, GUILayout.Width (45), GUILayout.Height (45)))
                Application.OpenURL (SITE_URL);
            GUILayout.Space (70);
            if (GUILayout.Button (mailLogo, GUILayout.Width (45), GUILayout.Height (45)))
                Application.OpenURL (MAIL_URL);
            GUILayout.Space (90);
            GUILayout.EndHorizontal ();

            GUILayout.Space (15);

            GUILayout.EndScrollView ();
            EditorGUILayout.EndVertical ();
        }

        #region GUI_SKINS
        private GUIStyle iconGUISkin;
        private GUIStyle textTitleGUISkin;
        private GUIStyle simpleTextGUISkin;
        private GUIStyle buttonGUIStyle;
        private GUIStyle simpleBackgroundColor;
        private GUIStyle linkTextGUISkin;
        private GUIStyle simpleMiddleTextGUISkin;
        private GUIStyle simpleHorizontalGroup;
        private Texture2D backgroundTexture;
        private Font customFont;
        private Vector2 scrollPosition = Vector2.zero;

        private Color whiteColor = new Color (250f / 255f, 250f / 255f, 250f / 255f);
        private Color backgroundColor = new Color (23f / 255f, 26f / 255f, 28f / 255f);

        void SetGUISkins ()
        {
            if (backgroundTexture == null)
            {
                backgroundTexture = new Texture2D (1, 1, TextureFormat.RGBA32, false);
                backgroundTexture.SetPixel (0, 0, backgroundColor);
                backgroundTexture.Apply ();
            }

            //Simple color guistyle
            simpleBackgroundColor = new GUIStyle ();
            simpleBackgroundColor.normal.background = backgroundTexture;

            //Icons gui skin
            iconGUISkin = new GUIStyle (GUI.skin.label);
            iconGUISkin.imagePosition = ImagePosition.ImageOnly;
            iconGUISkin.alignment = TextAnchor.MiddleCenter;
            iconGUISkin.stretchWidth = true;

            //Text title gui skin
            textTitleGUISkin = new GUIStyle (GUI.skin.label);
            if (customFont != null)
                textTitleGUISkin.font = customFont;
            textTitleGUISkin.fontSize = 30;
            textTitleGUISkin.alignment = TextAnchor.MiddleCenter;
            textTitleGUISkin.stretchWidth = true;
            textTitleGUISkin.normal.textColor = whiteColor;

            //Simple text gui skin
            simpleTextGUISkin = new GUIStyle (GUI.skin.label);
            if (customFont != null)
                simpleTextGUISkin.font = customFont;
            simpleTextGUISkin.wordWrap = true;
            simpleTextGUISkin.margin = new RectOffset (30, 30, 0, 0);
            simpleTextGUISkin.fontSize = 15;
            simpleTextGUISkin.alignment = TextAnchor.MiddleLeft;
            simpleTextGUISkin.stretchHeight = true;
            simpleTextGUISkin.normal.textColor = whiteColor;

            //Simple text gui skin
            simpleMiddleTextGUISkin = new GUIStyle (GUI.skin.label);
            if (customFont != null)
                simpleMiddleTextGUISkin.font = customFont;
            simpleMiddleTextGUISkin.wordWrap = true;
            simpleMiddleTextGUISkin.margin = new RectOffset (30, 30, 0, 0);
            simpleMiddleTextGUISkin.fontSize = 15;
            simpleMiddleTextGUISkin.alignment = TextAnchor.MiddleCenter;
            simpleMiddleTextGUISkin.stretchHeight = true;
            simpleMiddleTextGUISkin.normal.textColor = whiteColor;

            //Button gui style
            buttonGUIStyle = new GUIStyle (GUI.skin.button);

            //Link text gui skin
            linkTextGUISkin = new GUIStyle (GUI.skin.button);
            if (customFont != null)
                linkTextGUISkin.font = customFont;
            linkTextGUISkin.fontStyle = FontStyle.Normal;
            linkTextGUISkin.fontSize = 15;
            linkTextGUISkin.stretchHeight = true;
            linkTextGUISkin.wordWrap = true;
            linkTextGUISkin.margin = new RectOffset (30, 30, 0, 0);
            linkTextGUISkin.alignment = TextAnchor.MiddleCenter;
            linkTextGUISkin.normal.background = backgroundTexture;
            linkTextGUISkin.normal.textColor = new Color (124f / 255f, 250f / 255f, 250f / 255f);
            linkTextGUISkin.focused.background = backgroundTexture;
            linkTextGUISkin.focused.textColor = whiteColor;
            linkTextGUISkin.hover.background = backgroundTexture;
            linkTextGUISkin.hover.textColor = whiteColor;
            linkTextGUISkin.active.background = backgroundTexture;

            simpleHorizontalGroup = new GUIStyle ();
            simpleHorizontalGroup.alignment = TextAnchor.MiddleCenter;
            simpleHorizontalGroup.stretchWidth = true;
            simpleHorizontalGroup.fixedHeight = 50;
            simpleHorizontalGroup.wordWrap = true;
        }
        #endregion
    }
}
