using UnityEngine;

public class ExitWholeGame : MonoBehaviour
{
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}