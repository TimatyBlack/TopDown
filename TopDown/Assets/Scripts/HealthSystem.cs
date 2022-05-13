using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event System.Action OnDeath;
    public int health;
    public int healthMax;
    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {   
            OnDeath?.Invoke();
            health = 0;
        }
        
    }
}
 