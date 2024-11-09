using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform target; // Player's Transform
    public Vector3 offset = new Vector3(0, 5, -10); // Camera offset
    public float smoothSpeed = 0.125f; // Smooth speed for camera movement

    void LateUpdate()
    {
        if (target == null) return; // If target is not set, exit

        // Calculate the desired camera position based on the player's position and the offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera from its current position to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the player
        transform.LookAt(target);
    }
}

