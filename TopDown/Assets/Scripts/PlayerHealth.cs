using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthSystem health;
    public Enemy enemyPrefab;
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

        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {   
            health.Damage(enemy.dmg);
            
        }
    }

    public void Death()
    {
        health.OnDeath -= Death;
        Destroy(gameObject);
    }
}
