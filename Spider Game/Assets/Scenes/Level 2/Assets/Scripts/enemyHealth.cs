using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour {


    public float health = 50f;
    private AudioSource source;
    public ParticleSystem bloodParticles;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        

        if (health <= 0f)
        {
            
            
            Die();
            
        }
    }

    void Die()
    {
        //bloodParticles.Play();
        source.Play();
       
        Destroy(gameObject, source.clip.length);
    }
}
