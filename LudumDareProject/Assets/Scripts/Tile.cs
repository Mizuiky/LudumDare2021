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
    [SerializeField]
    private Bomb bomb;

    [SerializeField]
    private bool changeTileSprite;

    public bool hasWalkHere = false;

    private int countSteps = 0;

    private bool startIce = false;
    
    void Start()
    {
        this.resetTile();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.startIce = true;
        }
        if(this.startIce)
        {
            this.startIce = false;
            this.setTileType(TileType.Snow);
        }
    }

    public void resetTile()
    {
        this.tileAnimator.enabled = false;

        this.startIce = false;

        if (changeTileSprite)
        {
            setTileType(TileType.Ice);
            if(this.gift != null)
            {
                this.gift.hideGift();
            }
            else if(this.bomb != null)
            {
                this.bomb.hideBomb();
            }
        }
        gameObject.SetActive(true);  
       
        this.hasWalkHere = false;
    }

    public void checkTileState()
    {
        countSteps++;

        Debug.Log("checktilestate");
        if (this.tileState == TileState.isRight && !hasWalkHere)
        {
            this.hasWalkHere = true;

            this.tileType = TileType.Cracked;

            setTileType(TileType.Cracked);

            this.tileAnimator.enabled = true;

            if (gift != null)
            {
                this.gift.gameObject.SetActive(true);
            }
            //som feed back que acerto
            // remove neve do caminho trocando sprite pelo de gelo quebrado
        }
        else
        {
            //mudar sprite para quebrar o gelo  

            setTileType(TileType.Cracked);

            this.tileType = TileType.Cracked;

            Debug.Log("else");
            if (this.tileState == TileState.isWrong && this.tileType == TileType.Cracked)
            {
                if (bomb != null)
                {
                    this.bomb.gameObject.SetActive(true);
                }

                Debug.Log("else2");
                FindObjectOfType<AudioManager>().Play("glassCrack");
                this.gameObject.SetActive(false);
                FindObjectOfType<GameManager>().gameOver();

                //fazer um game over pelo game manageR
            }
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
