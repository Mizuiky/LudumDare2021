using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void explodeBomb()
    {
        this.gameObject.SetActive(true);
        //aparecer bomba
        //esperar um segundos fazer animação
        //musica da explosão
        FindObjectOfType<AudioManager>().Play("bombExplosion");
        //set active false
    }

    public void hideBomb()
    {
        this.gameObject.SetActive(false);
    }
}
