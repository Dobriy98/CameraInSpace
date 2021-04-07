using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private Vector3 p_pos;
    private Quaternion p_rot;
    private float p_time;
    private float distance;

    public Point(Vector3 pos){
        p_pos = pos;
        p_rot = Quaternion.identity;
        p_time = 10f;
        distance = 10f;
    }

    public Point(Vector3 pos, Quaternion rot, float time){
        p_pos = pos;
        p_rot = rot;
        p_time = time;
        distance = 10f;
    }

    public void CreateCube(GameObject pref, Vector3 camPos){
        #region Detect position
        Vector3 delta = p_pos - camPos;
        float len = Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y + delta.z * delta.z );
        float dx = delta.x/len;
        float dy = delta.y/len;
        float dz = delta.z/len;

        float endX = p_pos.x + distance * dx;
        float endY = p_pos.y + distance * dy;
        float endZ = p_pos.z + distance * dz;

        Vector3 pos = new Vector3(endX, endY, endZ);
        #endregion

        GameObject cube = Instantiate(pref, pos, p_rot);
        if(p_rot == Quaternion.identity){
            cube.transform.LookAt(p_pos, Vector3.up);
        }
        cube.GetComponent<CubeMovement>().Initialization(p_pos,p_time);
    }

}
