using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    public float dmg;
    public float dmgDealingDelay = 3.0f;
    private float timeToDmg;
    public float moveSpeed = 2.0f;
    public float maxSpeed = 8.0f;    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        direction.Normalize();
        movement = direction;

        timeToDmg -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }
    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void SetPlayer(Transform target)
    {
        player = target;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHp))
        {
            if (timeToDmg <= 0)
            {
                playerHp.health.Damage(dmg/2);
                timeToDmg = dmgDealingDelay;
                Debug.Log("CoolDown");
            }
        }
    }
}
