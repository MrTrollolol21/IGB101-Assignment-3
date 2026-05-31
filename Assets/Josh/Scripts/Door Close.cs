using UnityEngine;

public class EntryDoorClose : MonoBehaviour
{
    public float closeAngle = 90f;
    public float closeSpeed = 2f;

    public AudioSource doorAudio;

    private Quaternion openRotation;
    private Quaternion closedRotation;

    private bool shouldClose = false;
    private bool hasPlayedSound = false;

    void Start()
    {
        openRotation = transform.rotation;
        closedRotation = openRotation * Quaternion.Euler(0f, closeAngle, 0f);
    }

    void Update()
    {
        if (shouldClose)
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                closedRotation,
                Time.deltaTime * closeSpeed
            );
        }
    }

    public void CloseDoor()
    {
        shouldClose = true;

        if (!hasPlayedSound && doorAudio != null)
        {
            doorAudio.Play();
            hasPlayedSound = true;
        }
    }
}