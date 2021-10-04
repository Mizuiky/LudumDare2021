using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public void explode()
    {
        this.gameObject.SetActive(true);
        //aparecer bomba
        //esperar um segundos fazer animação
        //musica da explosão
        FindObjectOfType<AudioManager>().Play("bombExplosion");
        //set active false
    }

    public void hide()
    {
        this.gameObject.SetActive(false);
    }

    public void show()
    {
        this.gameObject.SetActive(true);
    }
}
