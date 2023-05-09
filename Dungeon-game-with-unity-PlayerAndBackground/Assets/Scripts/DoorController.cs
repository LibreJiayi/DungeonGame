using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorController : MonoBehaviour
{
    public bool isLocked = true; // If locked
    public GameObject task; // Related Target
    // Start is called before the first frame update
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isLocked)
            {
                // If locked, check
                if (task != null && task.GetComponent<Key>().isComplete)
                {
                    // if mission success, unlock
                    isLocked = false;
                    Debug.Log("mission success, open the door");
                }
                else
                {
                    Collider playerCollider = other.GetComponent<Collider>();
                    if (playerCollider != null)
                    {
                        Physics.IgnoreCollision(playerCollider, GetComponent<Collider>());
                    }
                    // Ban the player access the door, if the mission is not successful
                    Debug.Log("The door is locked, you should finish the mission");
                }
            }

            if (!isLocked)
            {
                // if the door is unlocked, you can access the door
                Debug.Log("if the door is unlocked, you can access the door");
                
            }
        }
    }
}