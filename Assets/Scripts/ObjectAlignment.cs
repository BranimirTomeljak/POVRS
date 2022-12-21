using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAlignment : MonoBehaviour
{
    [SerializeField]
    private LayerMask WhatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SurfaceAlignment();
    }

    private void SurfaceAlignment() {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();
        if(Physics.Raycast(ray, out info, WhatIsGround)) {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, info.normal);
        }
    }
}
