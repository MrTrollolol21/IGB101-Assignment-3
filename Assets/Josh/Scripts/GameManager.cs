using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;
    public Text pickupText;

    // Audio Proximity Check
    public AudioSource[] audiosources;
    public float audioProximity = 5.0f;

    // Door references
    public DoorOpen firstDoor;
    public DoorOpen exitDoor;

    private bool firstDoorOpened = false;
    private bool exitDoorOpened = false;
    private bool roomTwoAudioUnlocked = false;

    private void LevelCompleteCheck()
    {
        if (currentPickups >= 3 && !firstDoorOpened)
        {
            firstDoor.OpenDoor();
            firstDoorOpened = true;
            roomTwoAudioUnlocked = true;
        }

        if (currentPickups == maxPickups && !exitDoorOpened)
        {
            exitDoor.OpenDoor();
            exitDoorOpened = true;
            levelComplete = true;
        }
        else if (currentPickups < maxPickups)
        {
            levelComplete = false;
        }
    }

    private void UpdateGUI()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }

    private void PlayAudioSamples()
    {
        if (!roomTwoAudioUnlocked)
        {
            for (int i = 0; i < audiosources.Length; i++)
            {
                if (audiosources[i] != null && audiosources[i].isPlaying)
                {
                    audiosources[i].Stop();
                }
            }

            return;
        }

        for (int i = 0; i < audiosources.Length; i++)
        {
            if (audiosources[i] == null)
            {
                continue;
            }

            float distanceToPlayer = Vector3.Distance(
                player.transform.position,
                audiosources[i].transform.position
            );

            if (distanceToPlayer <= audioProximity)
            {
                if (!audiosources[i].isPlaying)
                {
                    audiosources[i].Play();
                }
            }
            else
            {
                if (audiosources[i].isPlaying)
                {
                    audiosources[i].Stop();
                }
            }
        }
    }

    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }
}
