using TMPro;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool Triggered = false;
    public PlayerInventoryScript KeycardAvailable;
    public bool Open = false;
    public GameObject Player;
    public TMP_Text ErrorMessage;

    private void Start()
    {
        //getting access to the inventory script
        KeycardAvailable = Player.GetComponent<PlayerInventoryScript>();
    }

    private void Update()
    {
        if (Triggered)
        {
            //checks if the player has a keycard
            if (KeycardAvailable.Keycards.Count >= 1)
            {
                //opens the door
                Open = true;
                gameObject.SetActive(false);
            }
            else //runs if the player does not have a keycard in their inventory
            {
                ErrorMessage.text = "You need a keycard to open this door";
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            // when a player comes close to the door it checks the conditions
            Triggered = true;
        }
    }
}

