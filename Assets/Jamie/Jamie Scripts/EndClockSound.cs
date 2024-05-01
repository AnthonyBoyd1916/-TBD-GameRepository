using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndClockSound : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Player.transform.position;

        #region Code to stop it playing if the level is quit - Sara
        if (GameManager.Instance.currentLevel != 1)
        {
            Destroy(this);
        }
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EndL1Sound")
        {
            this.enabled = false;
        }
    }
}
