using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempFishCollision : MonoBehaviour
{
    public bool placeable;
    public LayerMask collisionLayer;
    public Color color;
    
    void Start()
    {
        placeable = true;
    }

    void Update()
    {
        if (placeable)
        {
            color = Color.white;
        } else
        {
            color = Color.red;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if ((collisionLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            placeable = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if ((collisionLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            placeable = true;
        }
    }
}
