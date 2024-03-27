using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCamera : MonoBehaviour
{
    public bool xFreeze;
    public bool YFreeze;
    private float zSeparation = -10;
    public bool canStop;
    private bool canReposition = true;
    private Camera mainCamera;
    private Vector2 stopPosition;
    private FollowingCamera followingCamera;

    private void Awake()
    {
        mainCamera = GameObject.Find("StandarInterface").GetComponent<Initialization>().mainCamera.GetComponent<Camera>();
        followingCamera = mainCamera.GetComponent<FollowingCamera>();
    }

    private void LateUpdate()
    {
        if (canStop)
        {
            StopCameraPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.activeInHierarchy)
            {
                if (canReposition)
                {
                    stopPosition = followingCamera.target.transform.position;
                    canReposition = false;
                    canStop = true;
                    followingCamera.canFollow = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.activeInHierarchy)
            {
                RestoreStopPoint();
                followingCamera.canFollow = true;
            }
        }
    }

    public void RestoreStopPoint()
    {
        canReposition = true;
        canStop = false;
    }

    private void StopCameraPosition()
    {
        if (xFreeze && YFreeze)
        {
            mainCamera.transform.position = new Vector3(stopPosition.x, stopPosition.y, zSeparation);
        }
        else
        {
            if (xFreeze)
            {
                mainCamera.transform.position = new Vector3(stopPosition.x, followingCamera.target.transform.position.y, zSeparation);
            }

            if (YFreeze)
            {
                mainCamera.transform.position = new Vector3(followingCamera.target.transform.position.x, stopPosition.y, zSeparation);
            }
        }
    }
}
