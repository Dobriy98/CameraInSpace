using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedUp : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool flag;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!flag)
        {
            StartSpeedUp();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        EndSpeedUp();
    }

    private void StartSpeedUp(){
        CameraMovement camScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        camScript.speedUp = true;
        camScript.speed *= 2;

        CubeMovement[] cubeArray = GameObject.FindObjectsOfType<CubeMovement>();
        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i].isSpeedUp = true;
        }
        flag = false;
    }

    private void EndSpeedUp(){
        CameraMovement camScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        camScript.speedUp = false;
        camScript.speed /= 2;

        CubeMovement[] cubeArray = GameObject.FindObjectsOfType<CubeMovement>();
        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i].isSpeedUp = false;
            cubeArray[i].canMove = true;
        }
        flag = false;
    }
}
