using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventoryScript : MonoBehaviour
{
    //add to player script
    public bool ObjectFound = false;
    public bool KeycardFound = false;
    public GameObject Documents;
    public GameObject Keycard;
    public List<string> Inventory;
    public List<string> Keycards;
    public string itemType;

    public TMP_Text InventoryDisplay;

    public void Start()
    {
        //creating the inventory lists
        Inventory = new List<string>();
        Keycards = new List<string>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            //accesses the object's name in order to add it to the inventory
            itemType = collision.gameObject.GetComponent<Collectible>().ItemType;
            ObjectFound = true;
            Documents = GameObject.FindWithTag("Collectible");
        }

        if (collision.CompareTag("Keycard"))
        {
            //accesses the object's name in order to add it to the inventory
            itemType = collision.gameObject.GetComponent<Collectible>().ItemType;
            KeycardFound = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //sets to false if the player doesn't pick up the object
        ObjectFound = false;
        KeycardFound = false;
    }

    void Update()
    {
        if (ObjectFound)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // once the player picks up the document it is destroyed and added to the inventory
                Inventory.Add(itemType);
                Destroy(Documents.gameObject);
            }
        }

        if (KeycardFound)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // once the player picks up the keycard it is destroyed and added to the inventory
                Keycards.Add(itemType);
                Destroy(Keycard.gameObject);
            }
        }
        //shows the player what is in their inventory
        InventoryDisplay.text = "Research Collected: " + Inventory.Count + " / 15" + "\n" + Keycards.Count + " keycards in inventory";
    }

}
