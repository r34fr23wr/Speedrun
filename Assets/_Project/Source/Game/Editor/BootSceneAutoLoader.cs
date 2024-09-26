#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class BootSceneAutoLoader
{
    private static string BootSceneName = Scene.Boot.ToString();

    private static string TestSceneName = "Test";
            
    static BootSceneAutoLoader() => EditorApplication.playModeStateChanged += OnPlayModeChanged;


    private static void OnPlayModeChanged(PlayModeStateChange state)
    {
        if(state != PlayModeStateChange.EnteredPlayMode) return;

        if(SceneManager.GetActiveScene().name != BootSceneName) SceneManager.LoadScene(BootSceneName);
    }
}
#endif