using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
<<<<<<< Updated upstream
    GameManager GameManager;
    // Start is called before the first frame update
    void Start()
=======
    private GameManager gameManager;

    [SerializeField] private AudioClip soundClip;
    [SerializeField, Range(0f, 1f)] private float volume = 1f;

    private void Start()
>>>>>>> Stashed changes
    {
        GameObject managerObject = GameObject.FindGameObjectWithTag("Game Manager");

        if (managerObject != null)
        {
            gameManager = managerObject.GetComponent<GameManager>();
        }
        else
        {
            Debug.LogError("No GameObject with the tag 'Game Manager' was found.");
        }
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            GameManager.currentpickups += 1;
            Destroy(this.gameObject);
=======
            if (gameManager != null)
            {
                gameManager.currentPickups += 1;
            }

            if (soundClip != null)
            {
                AudioSource.PlayClipAtPoint(soundClip, transform.position, volume);
            }

            Destroy(gameObject);
>>>>>>> Stashed changes
        }
    }
}