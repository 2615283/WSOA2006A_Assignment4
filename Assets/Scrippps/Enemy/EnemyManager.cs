using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EM
{
    public class EnemyManager : PlayerManager
    {
        public bool isPerformingAction;
        public float detectionRadius;
        public float maxDetectionAngle = 50;
        public float minDetectionAngle = -50;

        LocomotionManager locoManager;
        //[Header("A.I Settings")]
        void Awake()
        {
            locoManager = GetComponent<LocomotionManager>();
        }

        void Update()
        {
            HandleCurrentAction();
        }

        //tells you what the enemy is currently doing
        void HandleCurrentAction()
        {
            if(locoManager.currentTarget == null)
            {
                locoManager.HandleDetection();
            }
        }
    }

}
