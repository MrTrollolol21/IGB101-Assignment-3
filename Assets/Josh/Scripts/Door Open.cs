using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;

    public AudioSource doorAudio;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private bool shouldOpen = false;
    private bool hasPlayedSound = false;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0f, openAngle, 0f);
    }

    void Update()
    {
        if (shouldOpen)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                openRotation,
                Time.deltaTime * openSpeed
            );
        }
    }

    public void OpenDoor()
    {
        shouldOpen = true;

        if (!hasPlayedSound && doorAudio != null)
        {
            doorAudio.Play();
            hasPlayedSound = true;
        }
    }
}