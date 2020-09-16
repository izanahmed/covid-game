using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement P1 = collision.collider.GetComponent<PlayerMovement>();
        if (P1 != null)
        {
            P1.setStatus(true);
            Destroy(gameObject);
            return;
        }

    }
}

// NOT FIXED THE MULTIPLE ZOMBIES WITH ONE COIN