using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_StairTeleport : MonoBehaviour
{
    [SerializeField] private GameObject stairdestination;
    [SerializeField] private float offset = 3f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var Telepos = stairdestination.transform.position;
        Telepos.y -= offset;
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position = Telepos;
        }
    }
}
