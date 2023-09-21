using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EM
{
    public class EnemyAnimManager : AnimatorManager
    {
        LocomotionManager locoManager;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            locoManager = GetComponentInParent<LocomotionManager>();
        }

        private void OnAnimatorMove()
        {
            float delta = Time.deltaTime;
            locoManager.enemyRB.drag = 0;
            Vector3 deltaPosition = animator.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / delta;
            locoManager.enemyRB.velocity = velocity;
        }
    }
}
