using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    private Animator animator;
    private int horizontal;
    private int vertical;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        horizontal = Animator.StringToHash("Horiz");
        vertical = Animator.StringToHash("Vert");
    }

    public void UpdateAnimationValues(float movementHorizontal, float movementVertical, bool isSneaking, bool isSprinting)
    {
        if (isSneaking)
        {
            movementVertical = 2;
        }

        if (isSprinting)
        {
            movementVertical = 3;
        }


        animator.SetFloat(horizontal, movementHorizontal, 0.1f, Time.deltaTime);
        animator.SetFloat(vertical, movementVertical, 0.1f, Time.deltaTime);
    }
}
