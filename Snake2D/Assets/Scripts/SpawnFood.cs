using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {
    // Food Prefab
    public GameObject foodPrefab;

    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    // Use this for initialization
    void Start ()
    {
        this.FoodSpawn();
    }

    public void FoodSpawn()
    {
        int x = (int)Random.Range(borderLeft.position.x + 1, borderRight.position.x - 1);
        int y = (int)Random.Range(borderBottom.position.y - 1, borderTop.position.y + 1);

        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }
	
}
