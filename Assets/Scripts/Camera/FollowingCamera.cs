using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    private GameObject player;
    private GameObject frostGuardianAvatar;
    public GameObject target;
    public float zSeparation;
    public bool canFollow = true;
    private GameObject cameraManager;

    private void Awake()
    {
        player = GameObject.Find("StandarInterface").GetComponent<Initialization>().player;
        frostGuardianAvatar = GameObject.Find("StandarInterface").GetComponent<Initialization>().frostGuardianAvatar;
        cameraManager = GameObject.Find("CameraManager");
    }

    private void LateUpdate()
    {
        if (canFollow)
        {
            FollowingTarget();
        }
    }

    public void FollowingTarget()
    {
        if (player.activeInHierarchy)
        {
            target = player;
        }
        else
        {
            target = frostGuardianAvatar;
        }

        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, zSeparation);
    }

    public void RestoreAllStopPoints()
    {
        if (cameraManager.transform.childCount > 0)
        {
            for (int i = 0; i < cameraManager.transform.childCount; i++)
            {
                cameraManager.transform.GetChild(i).GetComponent<StopCamera>().RestoreStopPoint();
            }

            canFollow = true;
        }
    }
}
