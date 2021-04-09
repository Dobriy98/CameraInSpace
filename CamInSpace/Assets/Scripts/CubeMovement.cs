using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour
{
    public bool canMove = true;
    public float speed;

    public bool isRewinding = false;
    public bool isSpeedUp = false;

    private Vector3 p_pos;
    private float p_time;
    private float distance = 10;
    private Renderer cubeRenderer;
    private Text timer;
    private float timeToMove;

    private List<Vector3> positions;
    public void Initialization(Vector3 p_pos, float p_time)
    {
        this.p_pos = p_pos;
        this.p_time = p_time;
        speed = distance / p_time;
    }

    public void ChangeTime(float time)
    {
        float distanceToCheck = Vector3.Distance(transform.position, p_pos);
        this.p_time = time;
        speed = distanceToCheck / p_time;
    }
    private void Start()
    {
        timer = GameObject.Find("TimerText").GetComponent<Text>();
        cubeRenderer = GetComponent<Renderer>();

        timeToMove = float.Parse(timer.text);

        positions = new List<Vector3>();
        positions.Insert(0, transform.position);
    }

    void Update()
    {
        if (canMove && !isRewinding && !ButtonController.instance.pause)
        {
            float step;
            if (isSpeedUp)
            {
                step = speed * 2 * Time.deltaTime;
            }
            else
            {
                step = speed * Time.deltaTime;
            }

            float distanceToCheck = Vector3.Distance(transform.position, p_pos);
            if(float.Parse(timer.text) >= timeToMove){
                transform.position = Vector3.MoveTowards(transform.position, p_pos, step);
            }   

            if (distanceToCheck <= 0)
            {
                cubeRenderer.material.color = Color.red;
                canMove = false;
            }
        }

        if (isRewinding)
        {
            Rewind();
            float distanceToCheck = Vector3.Distance(transform.position, p_pos);
            if (distanceToCheck > 0)
            {
                cubeRenderer.material.color = Color.white;
            }
        }
        else
        {
            Record();
        }
    }

    private void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
    }

    private void Record()
    {
        positions.Insert(0, transform.position);
    }
}
