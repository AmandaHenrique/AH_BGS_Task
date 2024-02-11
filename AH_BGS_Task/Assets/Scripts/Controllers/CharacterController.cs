using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : Singleton<CharacterController>
{
    [Header("References")]
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] Collider2D _collider2D;
    [SerializeField] Animator animator;
    [SerializeField] NavMeshAgent meshAgent;

    [Header("Attributes")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float currentSpeed;
    float horizontalInput;
    float verticalInput;
    bool isRunning;
    bool isAttacking = false;
    Vector2 velocity;
    bool hasDestiny = false;

    Interactable interactable;

    private void Start()
    {
        meshAgent.enabled = false;
        _collider2D.enabled = true;
    }

    private void Update()
    {
        if (hasDestiny && !meshAgent.hasPath)
        {
            meshAgent.enabled = false;
            _collider2D.enabled = true;
            hasDestiny = false;
            interactable.PlayerArrived();
            interactable = null;
        }


        if (hasDestiny && interactable!= null) {
            Flip(interactable.transform.position.x - transform.position.x);
            return;
        }

        Walk();
        Flip(horizontalInput);

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

    void Flip(float horizontalValue)
    {
        Vector3 localScale = transform.localScale;

        if (horizontalValue > 0 && localScale.x < 0 || horizontalValue < 0 && localScale.x > 0)
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }
    public void Attack() {
        if (isAttacking) return;
        isAttacking = true;
        _rigidbody2D.velocity = Vector2.zero;
        animator.SetTrigger("Attack");
    }
    public void EndAttack()
    {
        isAttacking = false;
    }

    public void WalkTo(Interactable interactable)
    {
        if(Utilities.CompareDistance(interactable.PlayerPosToStop(), transform, 0.1f))
        {
            interactable.PlayerArrived();
            return;
        }

        this.interactable = interactable;
        hasDestiny = true;

        _collider2D.enabled = false;
        meshAgent.enabled = true;
        meshAgent.updateRotation = false;
        meshAgent.updateUpAxis = false;

        animator.SetFloat("Speed", runSpeed);
        meshAgent.destination = interactable.PlayerPosToStop().position;
    }
}
