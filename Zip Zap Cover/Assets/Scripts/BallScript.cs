using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;

    public float force;

    public float angleDirection;

    public bool canLaunch = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.simulated = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) && canLaunch == true)
        {
            var direction = angleDirection;

            rb.velocity = Vector2.up * force;

            rb.AddForce(new Vector2(direction, force));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Thing"))
        {
            canLaunch = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        canLaunch = false;
    }
}
