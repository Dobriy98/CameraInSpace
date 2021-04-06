﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject cubeToSpawn;
    void Update()
    {
        if(Input.GetMouseButtonUp(0) && !ButtonController.instance.pause){
            if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            ray.origin = ray.GetPoint(240);
            ray.direction = -ray.direction;
            
            if(Physics.Raycast(ray,out hit)){
                if(hit.transform.name == "ColliderToCheck"){
                    Point p = new Point(hit.point);
                    p.CreateCube(cubeToSpawn, transform.position);
                }
            }
        }
    }
}
