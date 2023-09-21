using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace EM
{
    public class LocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        EnemyAnimManager enemyAnimManager;
        public LayerMask detectionLayer;
        public CharacterStats currentTarget;

        NavMeshAgent navMeshAgent;
        public Rigidbody enemyRB;

        public float distanceFromTarget;
        public float stoppingDistance = 0.5f;
        public float rotationSpeed = 20f;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            enemyRB = GetComponent<Rigidbody>();
            enemyAnimManager = GetComponentInChildren<EnemyAnimManager>();
        }

        private void Start()
        {
            navMeshAgent.isStopped = true;
            enemyRB.isKinematic = false;
        }
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
                enemyAnimManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                navMeshAgent.isStopped = true;
            }
            else
            {
                if (distanceFromTarget > stoppingDistance)
                {
                    enemyAnimManager.animator.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
                }
                /*else
                {
                    if (distanceFromTarget <= stoppingDistance)
                    {
                        enemyAnimManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
                    }
                }*/
            }

            HandleRotationTowardsTarget();
            navMeshAgent.transform.localPosition = Vector3.zero;
            navMeshAgent.transform.localRotation = Quaternion.identity;

        }

        private void HandleRotationTowardsTarget()
        {
            if (enemyManager.isPerformingAction)
            {
                Vector3 direction = currentTarget.transform.position - transform.position;
                direction.y = 0;
                direction.Normalize();

                if (direction == Vector3.zero)
                {
                    direction = transform.forward;
                }

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
            }
            else
            {
                Vector3 relativeDirection = transform.InverseTransformDirection(navMeshAgent.desiredVelocity);
                Vector3 targetVelocity = enemyRB.velocity;

                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(currentTarget.transform.position);
                enemyRB.velocity = targetVelocity;
                transform.rotation = Quaternion.Slerp(transform.rotation, navMeshAgent.transform.rotation, rotationSpeed / Time.deltaTime);

            }
        }
    }
}
