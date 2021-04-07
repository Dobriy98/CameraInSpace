using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public bool canMove = true;
    public float speed;

    private Vector3 p_pos;
    private float p_time;
    private float distance = 10;
    private Renderer cubeRenderer;
    public bool isRewinding = false;
    public bool isSpeedUp = false;

    private List<Vector3> positions;
    public void Initialization(Vector3 p_pos, float p_time)
    {
        this.p_pos = p_pos;
        this.p_time = p_time;
        speed = distance / p_time;
    }

    public void ChangeTime(float time){
        float distanceToCheck = Vector3.Distance(transform.position, p_pos);
        distance = distanceToCheck;
        this.p_time = time;
        speed = distance / p_time;
    }

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        positions = new List<Vector3>();
    }

    void Update()
    {
        if (canMove && !isRewinding)
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

            transform.position = Vector3.MoveTowards(transform.position, p_pos, step);
            float distanceToCheck = Vector3.Distance(transform.position, p_pos);

            if (distanceToCheck <= 0)
            {
                cubeRenderer.material.color = Color.red;
                canMove = false;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isRewinding)
        {
            float distanceToCheck = Vector3.Distance(transform.position, p_pos);
            if (distanceToCheck > 0)
            {
                cubeRenderer.material.color = Color.white;
            }
            Rewind();
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
