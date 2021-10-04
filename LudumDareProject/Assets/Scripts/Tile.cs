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
    public Gift gift;
    [SerializeField]
    public Bomb bomb;

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
        /*if(Input.GetKeyDown(KeyCode.Space))
        {
            this.startIce = true;
        }
        if(this.startIce)
        {
            this.startIce = false;
            this.setTileType(TileType.Snow);
        }*/
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
                this.gift.hide();
            }
            else if(this.bomb != null)
            {
                this.bomb.hide();
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
                Debug.Log("else2");
                StartCoroutine("destroyIce");
                //fazer um game over pelo game manageR
            }
        }
    }

    public IEnumerator destroyIce()
    {
        FindObjectOfType<AudioManager>().Play("glassCrack");
        //animação do gelo quebrando 

        if (this.bomb != null)
        { 
            bomb.show();

            yield return new WaitForSeconds(0.5f);

            bomb.explode();
        }
        //animação da bomba explodindo
       
        yield return new WaitForSeconds(1.6f);

        FindObjectOfType<GameManager>().gameOver();

        Debug.Log("gameover finish");
    }

    public void setTileType(TileType type)
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
