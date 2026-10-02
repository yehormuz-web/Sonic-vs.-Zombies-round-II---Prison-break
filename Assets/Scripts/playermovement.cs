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
    public float raycastDistance;
    private Animator Anime;
    private SpriteRenderer SpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        controls = new Playercontrols();
        Anime = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        controls.Enable();
        controls.Move.walk.performed += ctx => moveinput = new Vector2(ctx.ReadValue<float>(),0f);
        controls.Move.walk.canceled += ctx => moveinput = Vector2.zero;
        controls.Move.jump.performed += ctx => tryJump();
    }
    private void OnDisable()
    {
        controls.Disable();
        controls.Move.walk.performed -= ctx => moveinput = new Vector2(ctx.ReadValue<float>(), 0f);
        controls.Move.walk.canceled -= ctx => moveinput = Vector2.zero;
        controls.Move.jump.performed -= ctx => tryJump();
    }
    public void tryJump()
    {
        if (isgrounded()) {
            Rigidbody2D.linearVelocity = new Vector2(Rigidbody2D.linearVelocity.x, JumpForce);
            Anime.SetBool("Jump",true);
        }
        Debug.Log("trytojump");
    }
    bool isgrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down,raycastDistance, ground);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = new Vector2(moveinput.x * movementSpeed, Rigidbody2D.linearVelocity.y);
        Anime.SetFloat("Speed", Mathf.Abs(moveinput.x));
        Debug.Log($"Speed: {Mathf.Abs(moveinput.x)}");
        Anime.SetBool("Jump", !isgrounded());
        if (moveinput.x > 0)
        {
            SpriteRenderer.flipX = false;
        }
        else if (moveinput.x < 0)
        {
            SpriteRenderer.flipX = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
