using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Text timerText;

    public float timer = 0;
    public bool rewind = false;
    public bool speedUp = false;
    public float speed = 4;
    
    private float maxTimerValue = 60;
    private List<Vector3> positions;

    private void Start()
    {
        positions = new List<Vector3>();
    }
    void Update()
    {
        if (!ButtonController.instance.pause)
        {
            if (rewind)
            {
                 if (timer > 0)
                 {
                    timer -= Time.deltaTime;
                 }
            }
            else if (speedUp)
            {
                if (timer < maxTimerValue)
                {
                    timer += Time.deltaTime * 2;
                }
            }
            else
            {
                if (timer < maxTimerValue)
                {
                    timer += Time.deltaTime;
                }
            }

            timerText.text = timer.ToString("0.0");
            if (timer < maxTimerValue && !rewind)
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            }
        }
    }

    private void FixedUpdate()
    {
        if (rewind)
        {
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
        if (transform.position.z > 0 && timer < maxTimerValue)
        {
            positions.Insert(0, transform.position);
        }
    }
}
