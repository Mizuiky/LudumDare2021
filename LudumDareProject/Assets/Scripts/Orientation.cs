using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    public Bounds tileBounds;
    public bool hasTile;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Orientation");
        if (collision.gameObject.CompareTag("Tile"))
        {
            Debug.Log("Orientation entered");
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            tileBounds = sr.bounds;
            hasTile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasTile = false;    
    }
}
