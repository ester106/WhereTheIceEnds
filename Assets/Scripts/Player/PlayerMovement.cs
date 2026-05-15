using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private float horizontalAxis;
    private bool jump;
    private float jumpSpeed = 8;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] Animator animator;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        jump = Input.GetKey(KeyCode.Space);

        if (horizontalAxis < 0)
            transform.localScale = new Vector3(-0.4f, 0.4f, 1);
        else if (horizontalAxis > 0)
            transform.localScale = new Vector3(0.4f, 0.4f, 1);

        animator.SetBool("running", horizontalAxis != 0);
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalAxis * speed, body.velocity.y);

        if (jump && IsGrounded())
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
    }


    bool IsGrounded()
    {
        float extraHeight = 0.05f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeight, groundLayerMask);
        return (raycastHit.collider != null);
    }
}
