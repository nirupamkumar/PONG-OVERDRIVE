using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    public string githubURL = "https://github.com/nirupamkumar/PONG-OVERDRIVE.git";
    public string linkedInURL = "https://www.linkedin.com/in/nirupam-kumar-mundra-537b39233/";

    public void OpenGitHub()
    {
        OpenSocialURLs(githubURL);
    }

    public void OpenLinkedIn()
    {
        OpenSocialURLs(linkedInURL);
    }

    // Generic method to open a URL
    private void OpenSocialURLs(string url)
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        // For WebGL builds, use a JavaScript plugin to open the URL in a new tab
        OpenURLInWebGL(url);
#else
        // For other platforms, use Application.OpenURL
        Application.OpenURL(url);
#endif
    }

    // WebGL-specific function to open a URL in a new tab
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void OpenURLInWebGL(string url);
}