using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 1.0f;
    [SerializeField]
    private Animator animator;

    private void Update()
    {
        float hor = InputManager.Instance.GetHorizontalAxis();
        float ver = InputManager.Instance.GetVerticalAxis();

        if (ver != 0 || hor != 0)
            animator.SetBool("Idle", false);
        else
            animator.SetBool("Idle", true);

        // Set animation based on direction of movement
        animator.SetFloat("Move", ver);

        Vector2 move = new Vector2(hor, ver) * speed * Time.deltaTime;
        transform.Translate(move);
    }
}
