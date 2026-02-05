using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public InputActionReference toggleAction; // drag from Input Actions
    public Color colorA = Color.white;
    public Color colorB = Color.cyan;

    private Light lt;
    private bool state;

    void Awake()
    {
        lt = GetComponent<Light>();
    }

    void OnEnable()
    {
        if (toggleAction == null) return;
        toggleAction.action.performed += OnToggle;
        toggleAction.action.Enable();
    }

    void OnDisable()
    {
        if (toggleAction == null) return;
        toggleAction.action.performed -= OnToggle;
        toggleAction.action.Disable();
    }

    private void OnToggle(InputAction.CallbackContext ctx)
    {
        state = !state;
        lt.color = state ? colorB : colorA;
    }
}
