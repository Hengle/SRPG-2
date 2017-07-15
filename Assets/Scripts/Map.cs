using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject hexPrefab;
    public GameObject[] tilesPrefabs;
    private Grid grid;

    //Size of map in terms of hextiles
    public static int width = 5;
    public static int height = 5;

    float xOffset = 0.594f;
    float yOffset = 0.39f;

    // Use this for initialization
    void Start () {

        grid = new Grid();
        int[] types = {0, 0, 0, 0, 0,
                       0, 0, 0, 0, 0,
                       0, 0, 0, 0, 0,
        0, 0, 0, 0, 0,
        0, 0, 0, 0, 0};

        grid.CreateGrid(width, height, types);

        Hex[][] map = grid.Map;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x * xOffset;

                //Odd row?
                if (y % 2 == 1)
                {
                    xPos = xPos + xOffset / 2f;
                }
                Hex t = map[x][y];
                GameObject pref = tilesPrefabs[(int)t.type];
                GameObject hex_go = (GameObject)Instantiate(pref, new Vector3(xPos, y * yOffset, 0f), Quaternion.identity, gameObject.transform);
                hex_go.name = t.type.ToString();

                //Name and order game objects
                hex_go.GetComponentInChildren<SpriteRenderer>().sortingOrder = y * -1;
                hex_go.name = "Hex_" + x + "_" + y;
                hex_go.GetComponent<Hex>().x = x;
                hex_go.GetComponent<Hex>().y = y;

                //Parent this hex to the map
                hex_go.transform.SetParent(this.transform);
            }
        }
        Unit hound = GameObject.Find("Hellhound sprite").GetComponent<Unit>();
        GameObject hex = GameObject.Find("Hex_0_0");
        hound.currentHex = hex;
        //GameObject.Find("Hellhound sprite").GetComponent<Unit>().currentHex = GameObject.Find("Hex_0_0");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
