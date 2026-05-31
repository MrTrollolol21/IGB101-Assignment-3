using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JoshLevelSwitch : MonoBehaviour
{
    JoshGameManager gameManager;
    public string nextLevel;

    private void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.transform.tag == "Player")
        {
            if (gameManager.levelComplete)
            {
                SceneManager.LoadScene(nextLevel);            
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<JoshGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
