using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EM
{
    public class EnemyManager : PlayerManager
    {
        public bool isPerformingAction;
        [Header("AI Settings")]
        public float detectionRadius = 20;
        public float maxDetectionAngle = 50;
        public float minDetectionAngle = -50;

        LocomotionManager locoManager;
        void Awake()
        {
            locoManager = GetComponent<LocomotionManager>();
        }

        void Update()
        {
           
        }

        private void FixedUpdate()
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
            else
            {
                locoManager.HandleMoveToTarget();
            }
        }
    }

}
