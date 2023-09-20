using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;

namespace EM
{
    public class LocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        public LayerMask detectionLayer;
        public CharacterStats currentTarget;

        //NavMeshAgent navMeshAgent; 
        public void HandleDetection()
        {
            //look for colliders on player's layer, then when it finds them, makes them a target
            Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

            for (int i = 0; i < colliders.Length; i++)
            {
                CharacterStats charStats = colliders[i].transform.GetComponent<CharacterStats>();

                if (charStats != null)
                {
                    Vector3 targetDirection = charStats.transform.position - transform.position;
                    float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                    if (viewableAngle > enemyManager.minDetectionAngle && viewableAngle < enemyManager.maxDetectionAngle)
                    {
                        currentTarget = charStats;
                    }
                }
            }
        }

        public void HandleMoveToTarget()
        {
            Vector3 targetDirection = currentTarget.transform.position - transform.position;
            float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

            if (enemyManager.isPerformingAction)
            {

            }
        }
    }
}
