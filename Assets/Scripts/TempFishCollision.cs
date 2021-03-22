using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFishCollision : MonoBehaviour
{
    public bool placeable;
    public LayerMask collisionLayer;
    public LayerMask exceptionLayer;
    public Color color;
    private bool exception;
    
    void Start()
    {
        placeable = true;
        exception = false;
    }

    void Update()
    {
        if (placeable || exception)
        {
            color = Color.white;
        } else
        {
            if (!exception)
            {
                color = Color.red;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        {
            if ((collisionLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
            {
                placeable = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if ((collisionLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            placeable = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((exceptionLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            exception = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if ((exceptionLayer & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
        {
            exception = false;
        }
    }
}
