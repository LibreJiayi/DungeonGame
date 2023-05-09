using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject doorLeft, doorRight, doorUp, doorDown; // The object related to the door
    public bool isComplete = false; // check if the mission is finished

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // when touch the the key, key touch the door, the lock will disappear
            Destroy(gameObject);
            OppenTheDoor();
            Debug.Log("You picked the door, you can open the door");

            
        }
    }
    public void OppenTheDoor(){
        doorLeft.GetComponent<DoorController>().isLocked = false;
        doorRight.GetComponent<DoorController>().isLocked = false;
        doorUp.GetComponent<DoorController>().isLocked = false;
        doorDown.GetComponent<DoorController>().isLocked = false;

        doorLeft.GetComponent<BoxCollider2D>().isTrigger = true;
        doorRight.GetComponent<BoxCollider2D>().isTrigger = true;
        doorDown.GetComponent<BoxCollider2D>().isTrigger = true;
        doorUp.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void CloseTheDoor(){
        doorLeft.GetComponent<DoorController>().isLocked = true;
        doorRight.GetComponent<DoorController>().isLocked = true;
        doorUp.GetComponent<DoorController>().isLocked = true;
        doorDown.GetComponent<DoorController>().isLocked = true;

        doorLeft.GetComponent<BoxCollider2D>().isTrigger = false;
        doorRight.GetComponent<BoxCollider2D>().isTrigger = false;
        doorDown.GetComponent<BoxCollider2D>().isTrigger = false;
        doorUp.GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
