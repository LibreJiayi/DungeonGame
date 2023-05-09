using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllor : MonoBehaviour
{

    public static CameraControllor instance;

    public float speed;//Camera Speed
    //Destination
    public Transform target;

    
    
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
         if (target != null)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x,
             target.position.y, transform.position.z), speed * Time.deltaTime);
    }
    //TargetIf
    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
        
    }

}

