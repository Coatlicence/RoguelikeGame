using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLineTracer : MonoBehaviour
{
    //[SerializeField] float InvisibilityLevel = 0.1f;
    [SerializeField] Collider Player = null;
    [SerializeField] float test = 10;
    Camera cam = null;
    List<Collider> InvisibleColliders = new List<Collider>();

    void Start()
    {
        cam = GetComponent<Camera>();    
    }

    void Update()
    {
        float distance = (transform.position - Player.transform.position).magnitude - test;

        RaycastHit[] hit = Physics.RaycastAll(cam.transform.position, cam.transform.forward, distance);

        if (InvisibleColliders.Count > 0)
            for (int i = 0; i < InvisibleColliders.Count; i++)
            {
                Collider obj = InvisibleColliders[i];

                
            }
        
    }


}
