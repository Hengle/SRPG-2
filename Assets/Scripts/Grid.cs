using System.Collections;
using System.Collections.Generic;

public class Grid
{
    private Hex[][] map;
    public Hex[][] Map
    {
        get { return map; }
    }

    public void CreateGrid(int w, int h, int[] types)
    {
        int count = 0;
        map = new Hex[w][];
        for (int i = 0; i < w; i++)
        {
            map[i] = new Hex[h];
            for (int j = 0; j < h; j++)
                map[i][j] = new Hex((Hex.TileType)types[count++]);
        }
    }
}