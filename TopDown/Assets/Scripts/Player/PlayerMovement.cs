using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _player;
    public float moveSpeed = 5.0f;
    [SerializeField] private float _accelerate;

    //public Rigidbody2D rb;
    public Collider2D collider;
    public Camera cam;

    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = 0.5f;
    public float dashCooldown = 1f;

    private float dashCounter;
    private float dashCoolCounter;

    private bool isDashing;

    Vector2 movement;
    Vector2 mousePos;

    private void Awake()
    {
        _player.input.InputDirection += Move;
        activeMoveSpeed = moveSpeed;
    }

    // Start is called before the first frame update

    /*void Start()
    {
        activeMoveSpeed = moveSpeed;
        collider = GetComponent<Collider2D>();
    }*/

    private void Move(Vector2 direction)
    {
        _player.rigidBody.MovePosition(_player.rigidBody.position + direction.normalized * activeMoveSpeed * Time.fixedDeltaTime);
    }

    /*void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;

                isDashing = true;
                collider.isTrigger = true;
            }

        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                DashCancel();
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    *//*void FixedUpdate()
    {
        //movement
        rb.MovePosition(rb.position + movement.normalized * activeMoveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }*//*

    void DashCancel()
    {
        activeMoveSpeed = moveSpeed;
        dashCoolCounter = dashCooldown;
        isDashing = false;
        collider.isTrigger = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            if (isDashing)
            {
                DashCancel();
            }
        }
    }*/
}
