using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnCollision");
        if (collision.gameObject.CompareTag("Tile"))
        {
            Debug.Log("enter collision");
            collision.gameObject.GetComponentInParent<Tile>().checkTileState();
        }
        else if(collision.gameObject.CompareTag("Gift"))
        {
            collision.gameObject.GetComponentInParent<Gift>().showGift();
        }
    }
}
