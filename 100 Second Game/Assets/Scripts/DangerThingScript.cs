using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ThingScript;

public class DangerThingScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public PolygonCollider2D triggerCollider;
    public SpriteRenderer spriteRenderer;

    public bool isTouched;
    public bool isActive;
    public float speed;
    public float delay;

    public Color red;
    public Color touched;

    public PlayerHealth healthManager;
    public Timer timer;

    public Coroutine delayCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        //isActive = false;
        //triggerCollider.enabled = false;

        transform.Rotate(0, 0, Random.Range(0, 360));
        spriteRenderer.color = red;

        //Apply a force to push the asteroid foward
        rb.AddForce(transform.up * speed);

        //delayCoroutine = StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.hasWon == true)
        {
            //Destroy(triggerCollider);
        }

        //if (isActive == true)
        //{
        //    StopAllCoroutines();
        //}
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && timer.hasWon == false)
        {
            //isTouched = true;
            healthManager.healthCount -= 1;
            spriteRenderer.color = touched;
            Destroy(this);

        }
        if (col.gameObject.CompareTag("PlayerBlue"))
        {
            //isTouched = true;
            spriteRenderer.color = touched;
            Destroy(this);
        }
    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.gameObject.CompareTag("Player"))
    //    {
    //        //isTouched = false;
    //        spriteRenderer.color = red;
    //        Destroy(this);
    //    }
    //    if (col.gameObject.CompareTag("PlayerBlue"))
    //    {
    //        //isTouched = false;
    //        spriteRenderer.color = red;
    //        Destroy(this);
    //    }
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IgnoredByPlayer" || collision.gameObject.tag == "Wall")
        {
            rb.AddForce((transform.up * -1) * speed * 2);
        }
    }

    //IEnumerator Delay()
    //{
    //    yield return new WaitForSeconds(1f);

    //    triggerCollider.enabled = true;
    //    isActive = true;
    //}
}
