﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckGod : MonoBehaviour, OrganismGodInterface {

    public GameObject DUCK;
    public List<int> boundary_LRUD;
    private List<GameObject> ducks = new List<GameObject>();
    private int POPULATION = 0;

    // Use this for initialization
    void Start () {
        GetComponent<SpriteRenderer>().enabled = false;
        if (boundary_LRUD.Count < 4)
        {
            boundary_LRUD = new List<int>();
            boundary_LRUD.Insert(0, -10);
            boundary_LRUD.Insert(1, 10);
            boundary_LRUD.Insert(2, 10);
            boundary_LRUD.Insert(3, -10);
        }
    }

    public void SetBoundaryLRUD(List<int> LRUD)
    {
        boundary_LRUD = new List<int>();
        boundary_LRUD.Insert(0, LRUD[0]);
        boundary_LRUD.Insert(1, LRUD[1]);
        boundary_LRUD.Insert(2, LRUD[2]);
        boundary_LRUD.Insert(3, LRUD[3]);
    }

    public void UpdateEnvironmentalValues(float nutrients,
                                 float sunlight,
                                 float rain,
                                 float watertemp,
                                 float airtemp,
                                 float pH,
                                 float oxygen,
                                 float algaeHealth)
    {

    }
    // Update is called once per frame
    void Update () {
		
	}
    
    public void Kill(GameObject duck_)
    {
        ducks.Remove(duck_);
        Destroy(duck_);
        POPULATION--;
    }

    public void Spawn(int num, Vector3 position)
    {
        Quaternion spawnRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        GameObject duck = Instantiate(DUCK, position, spawnRotation) as GameObject;
        DuckController d = duck.GetComponent<DuckController>();
        d.SetGod(this.gameObject);
        d.boundary_LRUD = this.boundary_LRUD;
        ducks.Add(duck);
        ++POPULATION;
    }
    public void Spawn(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Vector3 position = new Vector3(Random.Range(boundary_LRUD[0], boundary_LRUD[1]), boundary_LRUD[2]);
            Spawn(1, position);
        }
    }
}