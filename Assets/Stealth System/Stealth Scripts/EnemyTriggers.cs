using UnityEngine;

public class EnemyTriggers : MonoBehaviour
{
    public bool PlayerSeen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSeen = true;
        }
    }
}
