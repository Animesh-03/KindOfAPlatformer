using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPart : MonoBehaviour
{
    public float shakeIntensity;
    public float shakeTime;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            collision.collider.transform.GetComponent<Player>().Respawn();
            GameObject deathParticles = Resources.Load("Player/PlayerDeathParticle") as GameObject;
            Instantiate(deathParticles, collision.GetContact(0).point, Quaternion.identity);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("PlayerDeath");
            CameraShake.Instance.Shake(shakeIntensity,shakeTime);
            Debug.Log("Player Killed");
        }

    }
}
