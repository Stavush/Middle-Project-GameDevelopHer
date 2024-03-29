using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]


public class Movment : MonoBehaviour
{
    public float speed = 8f;

    public float speedMultiplier = 1f;

    public Vector2 initialDirection;

    public LayerMask obstacleLayer;

    public Rigidbody2D rb { get; private set; }

    public Vector2 direction { get; private set; }

    public Vector2 nextDirection { get; private set; }

    public Vector3 startingPosition { get; private set; }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;

    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMultiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextDirection = Vector2.zero;
        this.transform.position = this.startingPosition;
        this.rb.isKinematic = false;
        this.enabled = true;
    }

    private void Update()
    {
        if (this.nextDirection != Vector2.zero)
        {
            SetDirection(this.nextDirection);
        }
    }


    private void FixedUpdate()
    {
        Vector2 position = this.rb.position;
        Vector2 translation = this.direction * this.speed * speedMultiplier * Time.fixedDeltaTime;
        this.rb.MovePosition(position + translation);
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (forced || !Occupied(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            this.nextDirection = direction;
        }
    }

    public bool Occupied(Vector2 direction)
    {

        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.obstacleLayer);
        return hit.collider != null;
    }
}
