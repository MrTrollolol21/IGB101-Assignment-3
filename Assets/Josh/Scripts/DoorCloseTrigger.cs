using UnityEngine;

public class EntryDoorCloseTrigger : MonoBehaviour
{
    public EntryDoorClose doorToClose;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            doorToClose.CloseDoor();
            hasTriggered = true;
        }
    }
}