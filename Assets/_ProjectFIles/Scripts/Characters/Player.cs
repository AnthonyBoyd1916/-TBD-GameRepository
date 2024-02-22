using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // log player score from game manager with a message
       Debug.Log("Player Score: " + GameManager.Instance.PlayerScore);
    }
}
