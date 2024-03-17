using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerThingScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public bool isTouched;
    public float speed;

    public Color red;
    public Color touched;

    public PlayerHealth healthManager;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
        spriteRenderer.color = red;

        //Apply a force to push the asteroid foward
        rb.AddForce(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //isTouched = true;
            healthManager.healthCount -= 1;
            spriteRenderer.color = touched;

        }
        if (col.gameObject.CompareTag("PlayerBlue"))
        {
            //isTouched = true;
            spriteRenderer.color = touched;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //isTouched = false;
            Destroy(this);
        }
        if (col.gameObject.CompareTag("PlayerBlue"))
        {
            //isTouched = false;
            Destroy(this);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IgnoredByPlayer" || collision.gameObject.tag == "Wall")
        {
            rb.AddForce((transform.up * -1) * speed * 2);
        }
    }
}
