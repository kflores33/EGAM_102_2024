using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public CircleCollider2D colliderCircle;
    public SpriteRenderer spriteRenderer;

    public TrailRenderer trailRenderer;

    public float moveSpeed = 1.0f;
    public float circleRadius;
    public Vector2 thingPosition = new Vector2(0f, 0f);

    public Color blue;
    public Color magenta;

    public Transform moveHandles;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //rb.position = worldPosition;

        thingPosition = Vector2.Lerp(transform.position, worldPosition, moveSpeed);

        Debug.DrawRay(worldPosition, Vector3.forward, Color.red);

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.color = blue;
            trailRenderer.startColor = blue;

            gameObject.tag = "PlayerBlue";
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            spriteRenderer.color = magenta;
            trailRenderer.startColor = magenta;
            
            gameObject.tag = "Player";
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(thingPosition);
    }
}
