using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Dice
    {
        public int red;
        public int white;
        public int blue;
        public int green;
        public int yellow;
        public int black;
    }
    public GameObject[] Prefabs;
    public Dice dice;
    List<Vector3> mySpawners = new List<Vector3>();
    List<GameObject> currentDice = new List<GameObject>();
    Transform[] myChildren;
	// Use this for initialization
	void Start ()
    {
        SpawnDice();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetDice();
            SpawnDice();
        }
	}

    void SpawnDice()
    {
        myChildren = GetComponentsInChildren<Transform>();
        foreach (Transform t in myChildren)
        {
            if (t != transform)
            {
                mySpawners.Add(t.position);
            }
        }
        for (int i = 0; i < dice.red; i++)
        {
            int r = Random.Range(0, mySpawners.Count);
            currentDice.Add( GameObject.Instantiate(Prefabs[0], mySpawners[r], Random.rotation));
            mySpawners.RemoveAt(r);
        }
        for (int i = 0; i < dice.white; i++)
        {
            int r = Random.Range(0, mySpawners.Count);
            currentDice.Add(GameObject.Instantiate(Prefabs[1], mySpawners[r], Random.rotation));
            mySpawners.RemoveAt(r);
        }
        for (int i = 0; i < dice.blue; i++)
        {
            int r = Random.Range(0, mySpawners.Count);
            currentDice.Add(GameObject.Instantiate(Prefabs[2], mySpawners[r], Random.rotation));
            mySpawners.RemoveAt(r);
        }
        for (int i = 0; i < dice.green; i++)
        {
            int r = Random.Range(0, mySpawners.Count);
            currentDice.Add(GameObject.Instantiate(Prefabs[3], mySpawners[r], Random.rotation));
            mySpawners.RemoveAt(r);
        }
        for (int i = 0; i < dice.yellow; i++)
        {
            int r = Random.Range(0, mySpawners.Count);
            currentDice.Add(GameObject.Instantiate(Prefabs[4], mySpawners[r], Random.rotation));
            mySpawners.RemoveAt(r);
        }
        for (int i = 0; i < dice.black; i++)
        {
            int r = Random.Range(0, mySpawners.Count);
            currentDice.Add(GameObject.Instantiate(Prefabs[5], mySpawners[r], Random.rotation));
            mySpawners.RemoveAt(r);
        }
    }

    void ResetDice()
    {
        foreach(GameObject g in currentDice)
        {
            Destroy(g);
        }
        currentDice.Clear();
    }
}
