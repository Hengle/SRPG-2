using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hex : MonoBehaviour
{
    public int x;
    public int y;
    public bool walkable;
    public int coverValue;
    public TileType type;

    public enum TileType
    {
        GRASS,
        WATER
    }

    public Hex(TileType type)
    {
        this.type = type;
    }
}