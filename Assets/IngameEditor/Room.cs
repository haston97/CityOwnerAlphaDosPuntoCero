using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour{
    public int id, posx, posy, sizx, sizy, poszroom;
    Tilemap tilemap;
    Tile tile;
    public Room(int iid, int iposx, int iposy, int isizx, int isizy, Tilemap itilemap, Tile itile)
    {
        id = iid;
        posx = iposx;
        posy = iposy;
        sizx = isizx;
        sizy = isizy;
        tilemap = itilemap;
        tile = itile;
        for (int i = posx; i < sizx; i++)
        {
            for (int j = posy; j < sizy; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0), tile);
            }
        }
    }
}
