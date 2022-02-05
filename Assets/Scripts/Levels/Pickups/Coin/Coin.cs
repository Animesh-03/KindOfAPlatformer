using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float magnitude;
    public float speed;

    private Vector3 initialPos;
    private float yPos;

    void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        yPos = Mathf.Sin((Time.time * speed) % (Mathf.PI * 2f)) * magnitude;
        transform.position  = new Vector3(transform.position.x, initialPos.y + yPos, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            GameObject audioManager =  GameObject.FindGameObjectWithTag("AudioManager");
            audioManager.GetComponent<AudioManager>().PlaySound("CoinPickup");
            collider.GetComponent<Player>().IncreaseCoins();
            Instantiate(Resources.Load<GameObject>("Levels/CoinPickupParticle"), transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
