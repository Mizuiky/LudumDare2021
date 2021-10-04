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
        StartCoroutine("findGift");    
    }

    public IEnumerator findGift()
    {
        FindObjectOfType<AudioManager>().Play("sparkle");
        //animação do gelo quebrando 

        this.show();

        yield return new WaitForSeconds(1.3f);
        FindObjectOfType<GameManager>().victory();
    }
}
