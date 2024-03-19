using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MIND : MonoBehaviour
{
    [SerializeField] private bool right = false;
    [SerializeField] private float timer = 10f;
    [SerializeField] private float chargespeed = 1f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Monst1;
    [SerializeField] private GameObject Monst2;
    //[SerializeField] private Transform Monst1Pos;
    //[SerializeField] private Transform Monst2Pos;

    private Renderer Monst1Rend;
    private Renderer Monst2Rend;
    
    void Start()
    {
        Monst1Rend = Monst1.GetComponent<SpriteRenderer>();
        //Monst1Rend.enabled = false;
        Monst2Rend = Monst2.GetComponent<SpriteRenderer>();
        //Monst2Rend.enabled = false;
    }
    void Update()
    {
        timer = timer - 0.01f;

        if(timer <= 0f)
        {
            if(right == true)
            {   
                Vector3 scale = Monst1.transform.localScale;

                if (player.transform.position.x > Monst1.transform.position.x)
                {
                    scale.x = Mathf.Abs(scale.x) * -1;
                    Monst1.transform.Translate(x: (chargespeed * Time.deltaTime) + 12, y: 0, z: 0);

                    if (Monst1.transform.position.x <= player.transform.position.x)
                    {
                        Monst1.transform.Translate(x: player.transform.position.x + 12, y: 0, z: 0);
                        timer = 10f;
                    }
                }
            }
            if (right == false)
            {
                Vector3 scale = Monst2.transform.localScale;
           
                if (player.transform.position.x < Monst2.transform.position.x)
                {                   
                    scale.x = Mathf.Abs(scale.x) * -1;
                    Monst2.transform.Translate(x: (-chargespeed * Time.deltaTime) + 12, y: 0, z: 0);

                    if (Monst2.transform.position.x <= player.transform.position.x)
                    {
                        Monst2.transform.Translate(x: player.transform.position.x + 12, y: 0, z: 0);
                        timer = 10f;
                    }
                }
            }

        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("END Screen");
        }
    }
    private void Wasteful()
    {
        /*
        Vector3 PlayerLocator1 = player.transform.position;
        Vector3 PlayerLocator2 = player.transform.position;
        float yheight = player.transform.position.y;
        float Monst1x = Monst1.transform.position.x;
        float Monst2x = Monst2.transform.position.x;
        PlayerLocator1.y += yheight;
        PlayerLocator1.x += Monst1x;
        PlayerLocator1.y += yheight;
        PlayerLocator1.x += Monst2x;
        Monst1.transform.position = PlayerLocator1 ;
        Monst2.transform.position = PlayerLocator2 ;
        */
    }
}
