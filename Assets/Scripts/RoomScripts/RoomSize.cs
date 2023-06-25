using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class RoomSize : MonoBehaviour
{
    public int xScale = 6;

    public GameObject floor;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject roof;

    private void Update()
    {
        if (!Application.isPlaying)
        {
            Vector3 newScaleHorizontal = new Vector3(xScale + 0.2f, 0.2f, 1);
            
            Transform roofSize = roof.transform;
            roofSize.localScale = newScaleHorizontal;

            Transform floorSize = floor.transform;
            floorSize.localScale = newScaleHorizontal;

            float newXPosition = xScale / 2f;

            Transform rightWallPosition = rightWall.transform;
            Vector3 currentRightWallPos = rightWallPosition.localPosition;
            rightWallPosition.localPosition = new Vector3(newXPosition, currentRightWallPos.y, currentRightWallPos.z);

            Transform leftWallPosition = leftWall.transform;
            Vector3 currentLeftWallPos = leftWallPosition.localPosition;
            leftWallPosition.localPosition = new Vector3(newXPosition * -1f, currentLeftWallPos.y, currentLeftWallPos.z);

        }
    }
}
