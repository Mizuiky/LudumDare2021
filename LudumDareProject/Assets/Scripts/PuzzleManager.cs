using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Tile[] tileList;

    public Tile[] giftTile;
    public Tile[] bombTile;

    public void changeTile(TileType type)
    {
        foreach(Tile tile in tileList)
        {
            tile.setTileType(type);
        }
    }

    public void showItens()
    {
        foreach (Tile g in giftTile)
        {
            if(g.gift != null)
            {
                g.gift.show();
            }
        }
        foreach (Tile b in bombTile)
        {
            if (b.bomb != null)
            {
                b.bomb.show();
            }
        }
    }

    public void hideItens()
    {
        foreach (Tile g in giftTile)
        {
            if (g.gift != null)
            {
                g.gift.hide();
            }
        }
        foreach (Tile b in bombTile)
        {
            if (b.bomb != null)
            {
                b.bomb.hide();
            }
        }
    }

    public void showTiles()
    {
        foreach (Tile t in tileList)
        {
            t.gameObject.SetActive(true);
        }
    }
}
