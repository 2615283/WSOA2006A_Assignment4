using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameScript : MonoBehaviour
{
    public PlayerInventoryScript InventoryList;
    public GameObject EndScreen;
    public GameObject Player;

    private void Start()
    {
        //gets access to the playerinventoryscript
        InventoryList = Player.GetComponent<PlayerInventoryScript>();
    }
    private void Update()
    {
        //checks if player has collected all the documents
        if (InventoryList.Inventory.Count == 15)
        {
            //ends the game once the player has collected all the documents
            EndScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
