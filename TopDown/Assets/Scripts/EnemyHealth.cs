using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]private HealthSystem health;
    // Start is called before the first frame update
    void Start()
    {
        health.OnDeath += Death;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Debug.Log("Hit");
            health.Damage(bullet.dmg);
        }
    }

    public void Death()
    {
        health.OnDeath -= Death;
        Destroy(gameObject);
    }
}
