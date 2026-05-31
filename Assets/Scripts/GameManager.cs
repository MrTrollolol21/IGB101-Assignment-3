using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
using Unity.VisualScripting;
=======
using TMPro;
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

<<<<<<< Updated upstream
    //Pickup and Game End Logic
    public int currentpickups = 0;
    public int maxpickups = 5;
    public bool levelcomplete = false;

    public Text pickuptext;
=======
    // Pickup and game state
    public int currentPickups = 0;
    public int maxPickups = 0;
    public bool levelComplete = false;

    // UI
    public TextMeshProUGUI pickupText;
>>>>>>> Stashed changes

    // Audio proximity check
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

<<<<<<< Updated upstream
=======
    // Door references
    public DoorOpen firstDoor;
    public DoorOpen exitDoor;

    private bool firstDoorOpened = false;
    private bool exitDoorOpened = false;
    private bool roomTwoAudioUnlocked = false;

    private void Start()
    {
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("Pickup");

        foreach (GameObject pickupObject in pickups)
        {
            if (pickupObject.activeInHierarchy)
            {
                maxPickups++;
            }
        }

        UpdateGUI();
    }
>>>>>>> Stashed changes

    private void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    private void LevelCompleteCheck()
    {
        if (currentPickups >= 3 && !firstDoorOpened)
        {
            if (firstDoor != null)
            {
                firstDoor.OpenDoor();
            }

            firstDoorOpened = true;
            roomTwoAudioUnlocked = true;
        }

        if (currentPickups >= maxPickups && !exitDoorOpened)
        {
            if (exitDoor != null)
            {
                exitDoor.OpenDoor();
            }

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
<<<<<<< Updated upstream
        pickuptext.text = "Pickups" + currentpickups + "/" + maxpickups;

=======
        if (pickupText != null)
        {
            pickupText.text = "Pickups " + currentPickups + "/" + maxPickups;
        }
>>>>>>> Stashed changes
    }

    private void PlayAudioSamples()
    {
        if (player == null || audioSources == null)
        {
            return;
        }

        if (roomTwoAudioUnlocked)
        {
            for (int i = 1; i < audioSources.Length; i++)
            {
                if (audioSources[i] != null && audioSources[i].isPlaying)
                {
                    audioSources[i].Stop();
                }
            }

            return;
        }

        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i] == null)
            {
                continue;
            }

            float distanceToPlayer = Vector3.Distance(
                player.transform.position,
                audioSources[i].transform.position
            );

            if (distanceToPlayer < audioProximity)
            {
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
            }
            else
            {
                if (audioSources[i].isPlaying)
                {
                    audioSources[i].Stop();
                }
            }
        }
    }
}
