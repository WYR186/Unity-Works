using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GateSocket : MonoBehaviour
{
    public int requiredKeyId = 1;
    public int gateIndex = 1;
    public MP1GameManager gm;

    UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    bool solved = false;

    void Awake() { socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>(); }

    void OnEnable() { socket.selectEntered.AddListener(OnEnter); }
    void OnDisable() { socket.selectEntered.RemoveListener(OnEnter); }

    void OnEnter(SelectEnterEventArgs args)
    {
        if (solved) return;

        var key = args.interactableObject.transform.GetComponentInParent<KeyId>();
        if (key != null && key.id == requiredKeyId)
        {
            solved = true;
            gm.OnGateSolved(gateIndex);
        }
        else
        {
            // 插错就弹出去
            if (socket.interactionManager != null)
                socket.interactionManager.SelectExit(socket, args.interactableObject);
        }
    }
}
