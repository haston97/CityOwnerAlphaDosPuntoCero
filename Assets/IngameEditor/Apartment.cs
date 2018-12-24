using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
struct rtile
{
    
}
public class Apartment : MonoBehaviour
{
    int[,] idmap;
    private List<Tilemap> rooms;
    public int id, posx, posy, sizx, sizy, nofrm, avx, avy;
    Grid grid;
    Tilemap tilemap;
    Tile tile;
    int[] canapear;
    public Apartment(int iid, int iposx, int iposy, int isizx, int isizy, int inofrm, Tilemap itilemap, Tile itile, Grid igrid)
    {

        id = iid;
        posx = iposx;
        posy = iposy;
        sizx = isizx;
        sizy = isizy;
        nofrm = inofrm;
        tilemap = itilemap;
        rooms = new List<Tilemap> { };
        tile = itile;
        grid = igrid;
        for (int i = posx; i < sizx+posx; i++)
        {
            for (int j = posy; j < sizy+posy; j++)
            {
                tilemap.SetTile(new Vector3Int(i, j, 0), tile);
            }
        }
        for (int i = 0; i < nofrm; i++)
        {
            Tilemap cacota = Instantiate(tilemap, grid.transform) as Tilemap;
            cacota.name = i.ToString();
            Vector3 pos = tilemap.transform.position;
            cacota.transform.position = new Vector3(pos.x, pos.y, pos.z - i - 1);
            for (int g = posx; g < sizx; g++)
            {
                for (int j = posy; j < sizy; j++)
                {
                    cacota.SetTile(new Vector3Int(g, j, 0), null);
                }
            }
            rooms.Insert(i, cacota);
        }
        idmap = new int[sizx, sizy];
        generateRooms(nofrm);
    }
    private void generateRooms(int numofrooms)
    {
        
        canapear = new int[numofrooms];
        for (int i = 0; i < sizx; i++)
        {
            for (int j = 0; j < sizy; j++)
            {
                idmap[i, j] = -1;
            }
        }
        for (int i = 0; i < nofrm; i++)
        {
            bool exit = false;
            while (!exit)
            {
                int cacota1 = Random.Range(0, sizx);
                int cacota2 = Random.Range(0, sizy);
                if (idmap[cacota1, cacota2] == -1) {
                    Debug.Log(cacota1.ToString() + cacota2.ToString());
                    idmap[cacota1, cacota2] = i;
                    exit = true;
                }
            }

        }
        bool exitw = false;
        while(!exitw)
        {
            exitw = true;
            for (int i = 0; i < sizx; i++)
            {
                for (int j = 0; j < sizy; j++)
                {
                    if (idmap[i, j] == -1)
                    {
                        exitw = false;
                        idmap[i, j] = RandomGen(i, j);
                    }
                }
            }
        }

        for (int i = 0; i < sizx; i++)
        {
            for (int j = 0; j < sizy; j++)
            {
                if (idmap[i, j] > -1) {
                    rooms[idmap[i, j]].SetTile(new Vector3Int(i+posx, j+posy, 0), tile);
                }
            }
        }
    }
    private int RandomGen(int gposx, int gposy)
    {
        Debug.Log(gposx.ToString()+ gposy.ToString());
        List<int> posVar = new List<int>();
        if (gposx == 0 && gposy != 0)
        {
            if (gposy == sizy-1)
            {
                if (idmap[gposx, gposy - 1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy - 1]);
                }
                if (idmap[gposx + 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx + 1, gposy]);
                }
            }
            else
            {
                if (idmap[gposx, gposy+1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy+1]);
                }
                if (idmap[gposx, gposy - 1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy - 1]);
                }
                if (idmap[gposx + 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx + 1, gposy]);
                }
            }
        }
        if (gposx != 0 && gposy != 0)
        {
            if (gposx == sizx-1 && gposy == sizy-1)
            {
                if (idmap[gposx - 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx - 1, gposy]);
                }
                if (idmap[gposx, gposy - 1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy - 1]);
                }
            }
            if (gposx != sizx - 1 && gposy != sizy - 1)
            {
                if (idmap[gposx - 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx - 1, gposy]);
                }
                if (idmap[gposx, gposy - 1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy - 1]);
                }
                if (idmap[gposx + 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx + 1, gposy]);
                }
                if (idmap[gposx, gposy+1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy + 1]);
                }
            }
            if (gposx != sizx - 1 && gposy == sizy - 1)
            {
                if (idmap[gposx - 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx - 1, gposy]);
                }
                if (idmap[gposx, gposy - 1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy - 1]);
                }
                if (idmap[gposx + 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx + 1, gposy]);
                }
            }
            if (gposx == sizx - 1 && gposy != sizy - 1)
            {
                if (idmap[gposx - 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx - 1, gposy]);
                }
                if (idmap[gposx, gposy + 1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy + 1]);
                }
                if (idmap[gposx, gposy-1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy-1]);
                }
            }
        }
        if (gposx != 0 && gposy == 0)
        {
            if (gposx == sizx - 1)
            {
                if (idmap[gposx - 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx - 1, gposy]);
                }
                if (idmap[gposx, gposy + 1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy + 1]);
                }
            }
            else
            {
                if (idmap[gposx - 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx - 1, gposy]);
                }
                if (idmap[gposx, gposy + 1] != -1)
                {
                    posVar.Add(idmap[gposx, gposy + 1]);
                }
                if (idmap[gposx + 1, gposy] != -1)
                {
                    posVar.Add(idmap[gposx + 1, gposy]);
                }

            }
        }
        if (gposx == 0 && gposy == 0)
        {
            if (idmap[gposx + 1, gposy] != -1)
            {
                posVar.Add(idmap[gposx + 1, gposy]);
            }
            if (idmap[gposx, gposy + 1] != -1)
            {
                posVar.Add(idmap[gposx, gposy + 1]);
            }
        }
        
        if(posVar.Count != 0)
        {
            return posVar[Random.Range(0, posVar.Count)];
        }
        else
        {
            return -1;
        }
    }

}
