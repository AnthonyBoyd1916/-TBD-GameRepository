using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_PicturePickup : MonoBehaviour
{
    [SerializeField] Image pictureFragments; // The UI element that has its sprites changed
    [SerializeField] Sprite pictureFragments0;
    [SerializeField] Sprite pictureFragments1;
    [SerializeField] Sprite pictureFragments2;
    [SerializeField] Sprite pictureFragments3;
    [SerializeField] Sprite pictureFragments4;
    [SerializeField] Sprite pictureFragments5;
    [SerializeField] private GameObject Endblocker;

    int pictureFragmentsCollected;

    void Start()
    {
        pictureFragments.GetComponent<Image>().sprite = pictureFragments0; // Ensures the sprite is set to the correct one at the start of the level
        pictureFragmentsCollected = 0; // Ensures the number of picture fragments collected is 0 at the start of the level
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PictureFragment")
        {
            Destroy(collision.gameObject);
            pictureFragmentsCollected++; // Adds one to the total picture fragments collected

            switch (pictureFragmentsCollected)
            {
                case 1:
                    pictureFragments.GetComponent<Image>().sprite = pictureFragments1;      // Sets the UI image to the correct sprite based on the collected fragments
                    break;
                case 2:
                    pictureFragments.GetComponent<Image>().sprite = pictureFragments2;
                    break;
                case 3:
                    pictureFragments.GetComponent<Image>().sprite = pictureFragments3;
                    break;
                case 4:
                    pictureFragments.GetComponent<Image>().sprite = pictureFragments4;
                    break;
                case 5:
                    pictureFragments.GetComponent<Image>().sprite = pictureFragments5;
                    Endblocker.SetActive(false);
                    break;
                default:
                    Debug.Log("Picture collected fragments: " + pictureFragmentsCollected);
                    break;
            }
        }
    }
}
