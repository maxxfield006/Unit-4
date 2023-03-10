using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

     public float attackForce = 500;
     public bool isPower = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.AddForce(Vector3.right * Time.deltaTime * horizontal * speed);
        rb.AddForce(Vector3.forward * Time.deltaTime * vertical * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(attackForce, attackForce, attackForce);
        }
        if (collision.gameObject.CompareTag("powerUp"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(WaitTime(7));
        }
    }

    IEnumerator WaitTime(float seconds)
    {
        attackForce += 1000;
        isPower = true;
        yield return new WaitForSeconds(seconds);
        attackForce -= 1000;
        isPower = false;
    }

   
}
