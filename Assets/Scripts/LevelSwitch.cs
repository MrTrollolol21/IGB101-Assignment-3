using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    private GameManager gameManager;

    public string nextLevel;

    private void Start()
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
            if (gameManager != null && gameManager.levelComplete)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}