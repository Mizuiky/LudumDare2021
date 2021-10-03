using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer currentTileSprite;
    [SerializeField]
    private Sprite[] tileSpriteStates; 
    [SerializeField]
    private Animator tileAnimator;

    public TileType tileType;
    public TileState tileState;

    [SerializeField]
    private Gift gift;
    
    void Start()
    {
        this.resetTile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTileAnimation()
    {

    }

    public void resetTile()
    {
        gameObject.SetActive(true);
        setTileType(this.tileType);

        if (gift != null)
        {
            this.gift.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            this.checkTileState();
        }
    }

    public void checkTileState()
    {
        if(this.tileState == TileState.isRight)
        {
            this.currentTileSprite.sprite = this.tileSpriteStates[2];
           //som feed back que acerto
           // remove neve do caminho trocando sprite pelod e gelo quebrado
        }
        else
        {
            if (this.tileType == TileType.Cracked)
            {
                //ativar animação de quebrar o gelo

                //adicionar um som feedback de quebrando o gelo
            }

            this.tileType = TileType.Cracked;
            //mudar sprite para quebrar o gelo
            //fazer um game over pelo game manager
        }
    }

    private void setTileType(TileType type)
    {
        switch(type)
        {
            case TileType.Snow:
                this.currentTileSprite.sprite = tileSpriteStates[0];
                break;

            case TileType.Ice:
                this.currentTileSprite.sprite = tileSpriteStates[1];
                break;
            case TileType.Cracked:
                this.currentTileSprite.sprite = tileSpriteStates[2];
                break;
        }
    }
}
