using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class AnimatorManager : MonoBehaviour
    {
        public Animator animator;
        private int horizontal;
        private int vertical;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            horizontal = Animator.StringToHash("Horiz");
            vertical = Animator.StringToHash("Vert");
        }

        public void UpdateAnimationValues(float movementHorizontal, float movementVertical, bool isSneaking)
        {
            if (isSneaking)
            {
                movementVertical = 2;
            }


            animator.SetFloat(horizontal, movementHorizontal, 0.1f, Time.deltaTime);
            animator.SetFloat(vertical, movementVertical, 0.1f, Time.deltaTime);
        }
    }
