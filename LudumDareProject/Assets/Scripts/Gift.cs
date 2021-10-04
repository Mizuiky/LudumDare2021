using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void hideGift()
    {
        this.gameObject.SetActive(false);
        //player adiciona pontos ao score
        //som de pegou um objeto, pode ser um plim
    }

    public void showGift()
    {
        this.gameObject.SetActive(true);
    }

}
