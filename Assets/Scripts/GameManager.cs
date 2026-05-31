using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    //Pickup and Game End Logic
    public int currentpickups = 0;
    public int maxpickups = 5;
    public bool levelcomplete = false;

    public TextMeshProUGUI pickuptext;

    //Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;


    // Update is called once per frame
    void Update()
    {
        levelcompletecheck();
        UpdateGUI();
        PlayAudioSamples();
    }

    //Level Completion
    private void levelcompletecheck()
    {
        if (currentpickups >= maxpickups)
            levelcomplete = true;
        else
            levelcomplete = false;
    }

    private void UpdateGUI()
    {
        pickuptext.text = "Pickups " + currentpickups + "/" + maxpickups;

    }

    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (Vector3.Distance(player.transform.position, audioSources[i].transform.position) < audioProximity)
                if (!audioSources[i].isPlaying)
                {
                    audioSources[i].Play();
                }
        }

    }
}


