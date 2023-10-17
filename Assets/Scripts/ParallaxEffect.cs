using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float startingPosition;
    private float lengthOfSprite;
    public float amountOfParallax;
    public Camera MainCamera;

    private void Start()
    {
        startingPosition = transform.position.x;
        lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        Vector3 Position = MainCamera.transform.position;
        float Temp = Position.x * (1 - amountOfParallax);
        float Distance = Position.x * amountOfParallax;

        Vector3 NewPosition = new Vector3(startingPosition + Distance, Position.y, transform.position.z);

        transform.position = NewPosition;

        if (Temp > startingPosition + (lengthOfSprite / 2))
        {
            startingPosition += lengthOfSprite;
        }
        else if (Temp < startingPosition - (lengthOfSprite / 2))
        {
            startingPosition -= lengthOfSprite;
        }
    }
}
