using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;

    private Vector3 targetDistanceFromBallToCamera;
    private float lerpRate = 2; //The rate the camera changes position to follow the ball.

    // Start is called before the first frame update
    void Start()
    {
        targetDistanceFromBallToCamera = ball.transform.position - transform.position;
        GameManager.Instance.gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.gameOver)
        {
            Follow();
        }
    }

    private void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = ball.transform.position - targetDistanceFromBallToCamera;
        currentPos = Vector3.Lerp(currentPos, targetPos, lerpRate * Time.deltaTime);
        transform.position = currentPos;
    }
}
