using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rewind : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool flag = false;
    public void OnPointerDown(PointerEventData eventData)
	{
        if(!flag){
            StartRewind();
        }
	}

    public void OnPointerUp(PointerEventData eventData)
	{
        EndRewind();
	}

    public void StartRewind(){
        CameraMovement camScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        camScript.rewind = true;

        CubeMovement[] cubeArray = GameObject.FindObjectsOfType<CubeMovement>();
        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i].isRewinding = true;
            cubeArray[i].canMove = false;
        }
        flag = false;
    }

    public void EndRewind(){
        CameraMovement camScript = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        camScript.rewind = false;

        CubeMovement[] cubeArray = GameObject.FindObjectsOfType<CubeMovement>();
        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i].isRewinding = false;
            cubeArray[i].canMove = true;
        }
        flag = false;
    }
}
