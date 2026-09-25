using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class playermovement : MonoBehaviour
{
    public LayerMask ground;
    public float movementSpeed=6f;
    public float JumpForce = 6f;
    private Playercontrols controls;
    private Rigidbody2D Rigidbody2D;
    private Vector2 moveinput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        controls = new Playercontrols();
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Move.walk.performed -= ctx => moveinput = ctx.ReadValue<Vector2>();
        controls.Move.walk.canceled -= ctx => moveinput = Vector2.zero;
        controls.Move.jump.performed -= ctx => tryJump();
    }
    private void OnDisable()
    {
        controls.Disable();
        controls.Move.walk.performed -= ctx => moveinput = ctx.ReadValue<Vector2>();
        controls.Move.walk.canceled -= ctx => moveinput = Vector2.zero;
        controls.Move.jump.performed -= ctx => tryJump();
    }
    public void tryJump()
    {
        if (isgrounded()) {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.linearVelocityX, JumpForce);
        }
        Debug.Log("trytojump");
    }
    bool isgrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, .2f, ground);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(moveinput.x * movementSpeed, Rigidbody2D.linearVelocityY);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
