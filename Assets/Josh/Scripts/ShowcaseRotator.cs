using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowcaseRotator : MonoBehaviour
{
    public enum RotationMode
    {
        Full360,
        PingPong
    }

    [Header("Rotation Settings")]
    public RotationMode mode = RotationMode.Full360;

    [Tooltip("Time (in seconds) for a full rotation or full back-and-forth cycle")]
    public float cycleDuration = 15f;

    [Tooltip("Max angle for PingPong mode (total arc = 2x this)")]
    public float maxAngle = 80f;

    [Header("Tilt Settings")]
    [Tooltip("Slight tilt on X axis for better presentation")]
    public float tiltX = 10f;

    private float startY;

    void Start()
    {
        startY = transform.eulerAngles.y;
    }

    void Update()
    {
        float time = Time.time;

        if (mode == RotationMode.Full360)
        {
            // 360 degrees over cycleDuration seconds
            float speed = 360f / cycleDuration;
            float yRotation = startY + (time * speed);
            transform.rotation = Quaternion.Euler(tiltX, yRotation, 0);
        }
        else if (mode == RotationMode.PingPong)
        {
            // Smooth oscillation using sine wave
            float speed = (2 * Mathf.PI) / cycleDuration; // full back-and-forth cycle
            float angle = Mathf.Sin(time * speed) * maxAngle;

            transform.rotation = Quaternion.Euler(tiltX, startY + angle, 0);
        }
    }
}
