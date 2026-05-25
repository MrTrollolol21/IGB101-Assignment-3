using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSwitch : MonoBehaviour
{
    GameManager GameManager;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.transform.tag == "Player")
        {
            if (GameManager.levelcomplete)
            {
                SceneManager.LoadScene(nextLevel);
            }

        }

    }

    void Update()
    {
        
    }
}
