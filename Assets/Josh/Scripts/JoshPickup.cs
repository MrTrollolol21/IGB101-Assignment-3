using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoshPickup : MonoBehaviour
{
    JoshGameManager gameManager;

    private void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.transform.tag == "Player")
        {
            gameManager.currentPickups += 1;
            Destroy(this.gameObject);
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
