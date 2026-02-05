using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    public InputActionReference toggleAction;
    public Transform insidePoint;
    public Transform outsidePoint;

    private bool outside;

    void Start()
    {
        // 默认从 inside 开始（也符合题目）
        if (insidePoint != null)
            transform.SetPositionAndRotation(insidePoint.position, insidePoint.rotation);
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
        outside = !outside;
        Transform target = outside ? outsidePoint : insidePoint;
        if (target == null) return;

        transform.SetPositionAndRotation(target.position, target.rotation);
    }
}
