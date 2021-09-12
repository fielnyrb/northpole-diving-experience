using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CrystalVary : MonoBehaviour
{
    public Sprite[] crystalVariations;

    // Start is called before the first frame update
    void Awake()
    {
        int index = Random.Range(0, crystalVariations.Length);

        GetComponent<SpriteRenderer>().sprite = crystalVariations[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
