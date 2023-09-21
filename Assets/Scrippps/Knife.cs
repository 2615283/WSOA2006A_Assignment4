using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public int enemy = 10;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Knife"))
        {
            enemy = enemy - 5;
        }
    }

    private void Update()
    {
        if (enemy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
