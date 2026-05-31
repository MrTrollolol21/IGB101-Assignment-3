using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeMotion : MonoBehaviour
{
    public enum Axis { X, Y, Z }

    [Header("Movement Settings")]
    public Axis movementAxis = Axis.X;

    [Tooltip("Total distance from one end to the other")]
    public float travelDistance = 3.2f;

    [Tooltip("Time (seconds) for a full back-and-forth cycle")]
    public float cycleDuration = 4f;

    [Header("Rotation Settings")]
    public Axis rotationAxis = Axis.X;

    [Tooltip("Rotation speed in degrees per second")]
    public float rotationSpeed = 720f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // --- MOVEMENT ---
        float halfDistance = travelDistance / 2f;
        float speed = (2 * Mathf.PI) / cycleDuration;
        float offset = Mathf.Sin(Time.time * speed) * halfDistance;

        Vector3 newPos = startPos;

        switch (movementAxis)
        {
            case Axis.X:
                newPos.x += offset;
                break;
            case Axis.Y:
                newPos.y += offset;
                break;
            case Axis.Z:
                newPos.z += offset;
                break;
        }

        transform.position = newPos;

        // --- ROTATION ---
        Vector3 rotationVector = Vector3.zero;

        switch (rotationAxis)
        {
            case Axis.X:
                rotationVector = Vector3.right;
                break;
            case Axis.Y:
                rotationVector = Vector3.up;
                break;
            case Axis.Z:
                rotationVector = Vector3.forward;
                break;
        }

        transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime);
    }
}
