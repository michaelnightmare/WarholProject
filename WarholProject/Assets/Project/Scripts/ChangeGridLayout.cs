using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGridLayout : MonoBehaviour {

    GridLayoutGroup grid;

    public List<GameObject> displays = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        grid = GetComponent<GridLayoutGroup>();
        ChangeLayout(4);
	}
	
    public void ChangeLayout(int num)
    {
        for (int i = 0; i < 9; i++)
        {
            if(i < num)
            {
                displays[i].SetActive(true);
            }
            else
            {
                displays[i].SetActive(false);
            }
        }

        if(num == 9)
        {
            grid.constraintCount = 3;
        }
        else
        {
            grid.constraintCount = 2;
        }
    }
}
