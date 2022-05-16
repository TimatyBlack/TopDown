using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{  
    
    public event System.Action OnDeath;
    public float health;
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

    public void Damage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {   
            OnDeath?.Invoke();
            health = 0;
        }
    }

    public void HPregen(float hpAmount)
    {
        health += hpAmount;

        if(health >= healthMax)
        {
            health = healthMax;
        }
    }
}
 