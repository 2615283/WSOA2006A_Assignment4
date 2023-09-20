using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    //public CapsuleCollider playerCollider;
    LayerMask enemyLayer;
    LayerMask healthBooster;
    [SerializeField]
    GameObject loseMessage;

    // Start is called before the first frame update
    void Start()
    {
        healthCount.text = healthLevel.ToString();
        currentHealth = healthLevel;
    }

    //Display current health and make sure it is never over the maxHealth
    void Update()
    {
        healthCount.text = currentHealth.ToString(); 
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When the player collides with an enemy, subtract from their health
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= 5;
            healthCount.text = currentHealth.ToString();

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                healthCount.text = currentHealth.ToString();
                Reset();
                
            }
        }

        //when the player collides with a health booster, add to their health
        if (collision.gameObject.CompareTag("HealthBoost"))
        {
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += 5;
            }
        }


    }

    //reset the level and restore the player's score/health
    private void Reset()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<PlayerMovement>().enabled = false;
        //GetComponent<Rigidbody>().isKinematic = true;
        Invoke(nameof(ReloadLevel), 0.5f);
        currentHealth = 100;
        //loseMessage.enabled = true;

    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
