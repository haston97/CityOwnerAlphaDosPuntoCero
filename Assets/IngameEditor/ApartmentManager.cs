using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ApartmentManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile tile;
    public Grid grid;
    int numrooms;
    Apartment Ap;
    //Use this for initialization

   void Start () {
        Ap = new Apartment(1, -5, -5, 10, 10, 5, tilemap, tile, grid);
	}

    //Update is called once per frame
    void Update()
    {

    }
}
