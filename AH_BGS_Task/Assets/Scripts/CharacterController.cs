using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] Collider2D _collider2D;
    [SerializeField] Animator animator;

    [Header("Attributes")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float currentSpeed;
    float horizontalInput;
    float verticalInput;
    bool isRunning;
    bool isAttacking = false;
    Vector2 velocity;

    private void Update()
    {
        Walk();
        Flip();

        if (Input.GetKeyDown(KeyCode.E))
            Attack();
    }

    void FixedUpdate()
    {
        if (isAttacking) return;
        velocity = new Vector2(horizontalInput, verticalInput);
        _rigidbody2D.velocity = velocity.normalized * currentSpeed;
    }

    void Walk() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isRunning && (horizontalInput != 0 || verticalInput != 0))
            currentSpeed = runSpeed;
        else if (horizontalInput != 0 || verticalInput != 0)
            currentSpeed = walkSpeed;
        else currentSpeed = 0;

        animator.SetFloat("Speed", currentSpeed);
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;

        if (horizontalInput > 0 && localScale.x < 0 || horizontalInput < 0 && localScale.x > 0)
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    void Attack() {
        if (isAttacking) return;
        isAttacking = true;
        _rigidbody2D.velocity = Vector2.zero;
        animator.SetTrigger("Attack");
    }

    public void EndAttack()
    {
        isAttacking = false;
    }
}
