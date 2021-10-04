using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void hide()
    {
        this.gameObject.SetActive(false);
        //player adiciona pontos ao score
        //som de pegou um objeto, pode ser um plim
    }

    public void show()
    {
        this.gameObject.SetActive(true); 
    }

    public void open()
    {
        FindObjectOfType<AudioManager>().Play("sparkle");
        FindObjectOfType<GameManager>().victory();
    }
}
