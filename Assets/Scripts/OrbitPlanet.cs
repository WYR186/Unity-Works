using UnityEngine;

public class OrbitPlanet : MonoBehaviour
{
    [Tooltip("Degrees per second")]
    public float rotateSpeed = 30f;

    void Update()
    {
        // Y-axis rotation, frame-rate independent
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
