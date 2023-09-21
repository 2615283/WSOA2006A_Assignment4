using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public int Radius;
    public PlayerStealthScript StealthScript;
    public EnemyTriggers SeesPlayer;

    public GameObject RunningDetection;
    public GameObject WalkingDetection;
    public GameObject SneakingDetection;

    private void Start()
    {
        StealthScript = GameObject.Find("LowPolyMan Variant").GetComponent<PlayerStealthScript>();
        SeesPlayer = GameObject.Find("RunningRadius").GetComponent<EnemyTriggers>();
    }

    private void Update()
    {
        if (StealthScript.Noise == 5)
        {
            if (SeesPlayer.PlayerSeen == true)
            {
                RunningDetection.SetActive(true);

                SneakingDetection.SetActive(false);
                WalkingDetection.SetActive(false);
            }
        }

        if (StealthScript.Noise == 3)
        {
            if (SeesPlayer.PlayerSeen == true)
            {
                WalkingDetection.SetActive(true);

                RunningDetection.SetActive(false);
                SneakingDetection.SetActive(false);
            }
        }

        if (StealthScript.Noise == 1)
        {
            if (SeesPlayer.PlayerSeen == true)
            {
                SneakingDetection.SetActive(true);

                WalkingDetection.SetActive(false);
                RunningDetection.SetActive(false);
            }
        }

        if (StealthScript.Noise >= 0)
        {
            RunningDetection.SetActive(false);
            SneakingDetection.SetActive(false);
            WalkingDetection.SetActive(false);
        }
    }
}
