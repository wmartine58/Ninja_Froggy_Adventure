using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FloatingObject : MonoBehaviour
{
    private Vector2 startPosition;
    public float xMaxPoxition = 0.4f;
    public float yMaxPoxition = 0.4f;
    private float xDisplacement;
    private float yDisplacement;
    public float speed = 0.05f;
    private float waitTime;
    public float startWaitTime = 1f;

    private void Awake()
    {
        startPosition = transform.position;
        waitTime = startWaitTime;
        xDisplacement = startPosition.x;
        yDisplacement = startPosition.y;
    }

    private void FixedUpdate()
    {
        if (waitTime <= 0)
        {
            SetDisplacements();
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(xDisplacement, yDisplacement), speed * Time.deltaTime);
    }

    private void SetDisplacements()
    {
        if (Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(startPosition.x, 0)) < 0.01f)
        {
            xDisplacement = UnityEngine.Random.Range(startPosition.x - xMaxPoxition, startPosition.x + xMaxPoxition);
        }
        else if (Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(xDisplacement, 0)) < 0.01f)
        {
            xDisplacement = startPosition.x;
        }

        if (Vector2.Distance(new Vector2(0, transform.position.y), new Vector2(0, startPosition.y)) < 0.01f)
        {
            yDisplacement = UnityEngine.Random.Range(startPosition.y - yMaxPoxition, startPosition.y + yMaxPoxition);
        }
        else if (Vector2.Distance(new Vector2(0, transform.position.y), new Vector2(0, yDisplacement)) < 0.01f)
        {
            yDisplacement = startPosition.y;
        }
    }
}
