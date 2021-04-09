using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RayCast : MonoBehaviour
{
    [SerializeField] private GameObject cubeToSpawn;
    [SerializeField] private Button buttonToCreatePoint;
    [SerializeField] private Button buttonToChangePoint;
    void Update()
    {
        if(Input.GetMouseButtonUp(0)){
            if (EventSystem.current.IsPointerOverGameObject()){
            return;
        }
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            ray.origin = ray.GetPoint(240);
            ray.direction = -ray.direction;
            
            if(Physics.Raycast(ray,out hit)){
                if(hit.transform.name == "ColliderToCheck" && !ButtonController.instance.pause){
                    Point p = new Point(hit.point);
                    p.CreateCube(cubeToSpawn, transform.position);
                }
                if(hit.transform.GetComponent<CubeMovement>()){
                    buttonToCreatePoint.interactable = false;
                    buttonToChangePoint.interactable = true;
                    ButtonController.instance.SetCurrentCube(hit.collider.gameObject);
                }
            }
        }
    }
}
