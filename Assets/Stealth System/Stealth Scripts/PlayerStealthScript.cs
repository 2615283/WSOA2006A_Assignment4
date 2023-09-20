using UnityEngine;

public class PlayerStealthScript : MonoBehaviour
{
    public bool Sneaking = false;
    public bool Running = false;
    public bool Walking = false;
    public bool Idle = true;

    public int Noise = 0;

    private void Start()
    {
        Sneaking = false;
        Running = false;
        Walking = false;
        Idle = true;
    }

    private void Update()
    {
        if (Sneaking == true)
        {
            Noise = 1;
        }
        if (Running == true)
        {
            Noise = 5;
        }
        if (Walking == true)
        {
            Noise = 3;
        }
        if (Idle == true)
        {
            Noise = 0;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Sneaking = true;
            Running = false;
            Walking = false;
            Idle = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Running = true;
            Walking = false;
            Sneaking = false;
            Idle = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Walking = true;
            Sneaking = false;
            Running = false;
            Idle = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Sneaking = false;
            Idle = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Running = false;
            Idle = true;
        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            Walking = false;
            Idle = true;
        }
    }
}
