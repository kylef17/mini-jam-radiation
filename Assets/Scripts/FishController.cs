using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Animator anim;
    public LayerMask collisionLayer;

    public float moveSpeed;
    public float minAngle;
    public float maxAngle;
    public float rotationSpeed;

    private Vector2 direction;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("Fish") as RuntimeAnimatorController;
        ChooseTargetLocation();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (direction.normalized * moveSpeed * Time.deltaTime));
        
        if (Mathf.Sign(direction.x) > 0)
        {
            UpdateAnimation(180);
        } else if (Mathf.Sign(direction.x) < 0)
        {
            UpdateAnimation(0);
        }
    }

    private void ChooseTargetLocation()
    {
        direction = RandomVector2();
        if(Random.value < 0.5f)
        {
            direction *= -1;
        }
    }

    private Vector2 RandomVector2()
    {
        float angle = Random.Range(minAngle, maxAngle);
        return DegreeToVector2(angle);
    }

    private static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    private static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collisionLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            if (Mathf.Abs(collision.GetContact(0).normal.x) > 0.5f)
            {
                BounceX();
            }
            else if (Mathf.Abs(collision.GetContact(0).normal.y) > 0.5f)
            {
                BounceY();
            }
        }
    }

    private void BounceX()
    {
        direction.x = -direction.x;
    }

    private void BounceY()
    {
        direction.y = -direction.y;
    }

    private void UpdateAnimation(float rotation)
    {
        Quaternion newRotation = Quaternion.Euler(transform.rotation.x, rotation, transform.rotation.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
    }
}
