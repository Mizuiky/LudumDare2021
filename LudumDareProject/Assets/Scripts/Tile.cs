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

    public TileState state;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTileAnimation()
    {

    }

    public void resetAllState()
    {
        gameObject.SetActive(true);
        this.currentTileSprite.sprite = tileSpriteStates[0];
        this.state = TileState.Normal;
    }


}
