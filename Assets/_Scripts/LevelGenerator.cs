using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelBlock;

    [SerializeField]
    private int renderDistance = 20; // Will set the minimum distance that will be covered by level blocks at all times ahead the player

    [SerializeField]
    private GameObject playerPosition;

    [SerializeField]
    private float levelBlockLength = 30f;

    int levelBlockDistance; // To know what distance each level block can cover
    int randomNumber;       
    int buildedDistance;    // To know how much track we have already build
    float groundToCover;
    float currBuiltDistance = 0;

    void FixedUpdate()
    {
        groundToCover = playerPosition.transform.position.z - currBuiltDistance + renderDistance;

        if (groundToCover > 0)
        {
            BuildLevel();
        }

    }

    void BuildLevel()
    {
        randomNumber = UnityEngine.Random.Range(0, levelBlock.Length - 1);

        GameObject currentLevelBlock;
        currentLevelBlock = Instantiate(levelBlock[randomNumber], new Vector3(0, 0, currBuiltDistance + levelBlockLength), Quaternion.identity);
        currBuiltDistance += levelBlockLength;

    }

}
