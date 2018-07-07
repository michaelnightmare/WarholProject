using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorSetter : MonoBehaviour
{

    public Color tint;

	void Start ()
    {
        Renderer r = GetComponent<Renderer>();
        r.material.SetColor("_Color", tint);
	}
	
	
}
