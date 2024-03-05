using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform playpos;
    [SerializeField] private Transform enemypos;
    [SerializeField] private float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 scale = enemypos.localScale;

        if (playpos.position.x > enemypos.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            enemypos.Translate(x: speed * Time.deltaTime, y: 0, z: 0);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
            enemypos.Translate(x: speed * Time.deltaTime * -1, y: 0, z: 0);
        }
    }
}
