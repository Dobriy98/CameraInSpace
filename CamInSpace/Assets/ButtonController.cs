using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private CameraMovement camMoveScript;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button rewindButton;
    [SerializeField] private Button speedUpButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject prefCube;

    public static ButtonController instance = null;
    public bool pause = false;

    private float p_posX;
    private float p_posY;
    private float p_posZ;

    private float p_rotX;
    private float p_rotY;
    private float p_rotZ;

    private float p_time;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        resumeButton.interactable = false;
    }

    public void Pause()
    {
        pause = true;

        pauseButton.interactable = false;
        rewindButton.interactable = false;
        speedUpButton.interactable = false;
        resumeButton.interactable = true;

        CubeMovement[] cubeArray = GameObject.FindObjectsOfType<CubeMovement>();
        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i].canMove = false;
        }
    }
    public void Resume()
    {
        pause = false;

        pauseButton.interactable = true;
        rewindButton.interactable = true;
        speedUpButton.interactable = true;
        resumeButton.interactable = false;

        if (camMoveScript != null)
        {
            camMoveScript.speed = 4;
        }

        CubeMovement[] cubeArray = GameObject.FindObjectsOfType<CubeMovement>();
        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i].canMove = true;
        }
    }

    public void SetPositionX(string valueString)
    {
        int defaultValue = 5;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            p_posX = parseInt;
        }
        else
        {
            p_posX = defaultValue;
        }
    }

    public void SetPositionY(string valueString)
    {
        int defaultValue = 5;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            p_posY = parseInt;
        }
        else
        {
            p_posY = defaultValue;
        }
    }

    public void SetPositionZ(string valueString)
    {
        int defaultValue = 5;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            p_posZ = parseInt;
        }
        else
        {
            p_posZ = defaultValue;
        }
    }

    public void SetRotationX(string valueString)
    {
        int defaultValue = 5;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            p_rotX = parseInt;
        }
        else
        {
            p_rotX = defaultValue;
        }
    }

    public void SetRotationY(string valueString)
    {
        int defaultValue = 5;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            p_rotY = parseInt;
        }
        else
        {
            p_rotY = defaultValue;
        }
    }

    public void SetRotationZ(string valueString)
    {
        int defaultValue = 5;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            p_rotZ = parseInt;
        }
        else
        {
            p_rotZ = defaultValue;
        }
    }

    public void SetTime(string valueString)
    {
        int defaultValue = 5;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            p_time = parseInt;
        }
        else
        {
            p_time = defaultValue;
        }
    }

    public void CreatePoint()
    {
        Vector3 pos = new Vector3(p_posX, p_posY, p_posZ);
        Quaternion rot = Quaternion.Euler(p_rotX, p_posY, p_rotZ);
        Point p = new Point(pos, rot, p_time);

        GameObject cam = GameObject.Find("Main Camera");
        p.CreateCube(prefCube, cam.transform.position);
    }
}
