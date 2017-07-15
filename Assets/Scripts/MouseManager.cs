using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour {

    Unit unit;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        /*if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }*/


        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(worldPoint, Vector2.zero);
        if(hitInfo.collider == null) return;
        GameObject ourHitObject = hitInfo.collider.transform.gameObject;

        if(ourHitObject.GetComponent<Hex>() != null)
        {
            MouseOver_Hex(ourHitObject);
        }
        else if(ourHitObject.GetComponent<Unit>() != null)
        {
            MouseOver_Unit(ourHitObject);
        }
    }

    void MouseOver_Hex(GameObject ourHitObject)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(ourHitObject.name);

            if (unit != null)
            {

                if (IsIndistance(unit.currentHex.GetComponent<Hex>(), ourHitObject.GetComponent<Hex>(), unit.moveDistance))
                { 
                    unit.currentHex = ourHitObject;
                    unit.destination = ourHitObject.transform.position;
                    //selectedUnit = null;
                }
            }
        }
    }

    bool IsIndistance(Hex source, Hex destiny,int distance)
    {
        int distX = Mathf.Abs(source.x - destiny.x);
        int distY = Mathf.Abs(source.y - destiny.y);
        int actualDistance = Mathf.Max(distX, distY);
        if (distX > (distY - Mathf.Ceil(distY / 2.0f)) && distY > 0)
            actualDistance = distX + (int)Mathf.Ceil(distY / 2.0f);
        Debug.Log("Distance3: " + actualDistance);
        return (actualDistance <= distance);
    }

    void MouseOver_Unit(GameObject ourHitObject)
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(ourHitObject.name);
            unit = ourHitObject.GetComponent<Unit>();
        }
    }
}
