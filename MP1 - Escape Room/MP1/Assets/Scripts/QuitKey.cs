using UnityEngine;
using UnityEngine.InputSystem;

public class QuitKey : MonoBehaviour
{
    public InputActionReference quitAction;

    void OnEnable()
    {
        if (quitAction == null) return;
        quitAction.action.performed += OnQuit;
        quitAction.action.Enable();
    }

    void OnDisable()
    {
        if (quitAction == null) return;
        quitAction.action.performed -= OnQuit;
        quitAction.action.Disable();
    }

    private void OnQuit(InputAction.CallbackContext ctx)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
