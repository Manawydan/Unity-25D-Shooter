using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour {

    // References
    private Rigidbody rb;
    private Animator playerAnimator;

    // Movement
    private Vector3 movementVelocity;

    // Jump
    private bool isGrounded = true;
    private LayerMask groundMask;

    // Inventory
    public List<BaseWeapon> weapons;
    public int currentWeapon;

    void Awake()
    {
        // Setup References
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

        groundMask = LayerMask.GetMask("Ground");
    }

    void Start ()
    {
        // Freeze axis x,y,z rotation
        rb.freezeRotation = true;
    }

    public void MovementInput(float _playerSpeed)
    {
        // Vetor de Inputs para os Eixos Horizontal e Vertical
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Normalizo o Vetor de Input e Multiplico pela velocidade do player
        movementVelocity = movementInput.normalized * _playerSpeed;

        // Player Animations
        // TODO: Walk Anim Here
    }

    public void JumpInput (float _jumpSpeed)
    {
        // Se apertou a tecla espaco e se esta no chao, entao...
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * _jumpSpeed);
            // Player Animations
            // TODO: Jump Anim Here
        }

        isGrounded = false;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1 + 0.1f, groundMask))
        {
            isGrounded = true;
        }

        // Player Animation
        // TODO: Jump Anim Here
    }

    public void MouseInput ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weapons[0].Shoot();
        }
    }

    public void ReloadInput ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapons[0].Reload();
        }
    }

    void FixedUpdate()
    {
        // Faço com que o rigidbody receba a soma de posicoes, multiplicado por deltaTime
        rb.MovePosition(rb.position + movementVelocity * Time.fixedDeltaTime);
    }
}
