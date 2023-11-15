using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;


public class GameHandler : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;

    private Vector3 cameraFollowPosition;
    private float zoom=6f;

    private void Start()
    {
        cameraFollow.Setup(() => cameraFollowPosition, () => zoom);
    }

    private void Update()
    {

        HandleManualMovement();
        HandleEdheScrolling();
        HandleZoom();

    }

    private void HandleZoom()
    {
        float zoomChangeAmount = 5f;
        if (Input.GetKey(KeyCode.M))
        {
            zoom -= zoomChangeAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.N))
        {
            zoom += zoomChangeAmount * Time.deltaTime;
        }

    }


    private void HandleManualMovement()
    {
        float moveAmount = 20f;
        if (Input.GetKey(KeyCode.W))
        {
            cameraFollowPosition.y += moveAmount * Time.deltaTime * 0.2f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraFollowPosition.y -= moveAmount * Time.deltaTime * 0.2f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraFollowPosition.x -= moveAmount * Time.deltaTime * 0.2f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraFollowPosition.x += moveAmount * Time.deltaTime * 0.2f;
        }

    }

    private void HandleEdheScrolling()
    {
        float moveAmount = 20f;
        float edgeSize = 30f;
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            //Edge Right
            cameraFollowPosition.x += moveAmount * Time.deltaTime * 0.2f;
        }

        if (Input.mousePosition.x < edgeSize)
        {
            //Edge Left
            cameraFollowPosition.x -= moveAmount * Time.deltaTime * 0.2f;
        }

        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            //Edge up
            cameraFollowPosition.y += moveAmount * Time.deltaTime * 0.2f;
        }

        if (Input.mousePosition.y < edgeSize)
        {
            //Edge down
            cameraFollowPosition.y -= moveAmount * Time.deltaTime * 0.2f;
        }
    }


    /*
    public CameraFollow cameraFollow;
    public Transform playerTransform;

    public Transform character1Transform;
    public Transform character2Transform;
    public Transform manualMovementTransform;
    


    private void Start()
    {
        cameraFollow.Setup(() => playerTransform.position, () => 4f);

       
        CMDebug.ButtonUI(new Vector2(10, 330), "Player", () =>
        {
            cameraFollow.SetGetCameraFollowPositionFunc(() => playerTransform.position);
        });
        
       CMDebug.ButtonUI(new Vector2(10, 270), "Char 1", () =>
       {
           cameraFollow.SetGetCameraFollowPositionFunc(() => character1Transform.position);
       });

       CMDebug.ButtonUI(new Vector2(10, 210), "Char 2", () =>
       {
           cameraFollow.SetGetCameraFollowPositionFunc(() => character2Transform.position);
       });

       CMDebug.ButtonUI(new Vector2(10, 50), "Manual", () =>
       {
           cameraFollow.SetGetCameraFollowPositionFunc(() => manualMovementTransform.position);
       });

       */

}
