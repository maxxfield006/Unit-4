using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerController player;
    public GameObject playerGO;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 1)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerGO)
        {
            Destroy(gameObject);
            player.attackForce = 1500;
            Debug.Log("COLLISION");
        }
    }


}
