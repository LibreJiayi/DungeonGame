using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
// Start is called before the first frame update
public GameObject doorLeft, doorRight, doorUp, doorDown; //Store doors at different positions
public bool roomLeft, roomRight, roomUp, roomDown; //Determine whether there are rooms above, below, left, and right

public Text text;

public int stepToStart; //Grid distance from the starting point

public int doorNumber; //Number of doors/entrances in the current room

private Key key; //Call the open and close door functions in the key script

void Start()
{
    doorLeft.SetActive(roomLeft);
    doorRight.SetActive(roomRight);
    doorUp.SetActive(roomUp);
    doorDown.SetActive(roomDown);
}

// Update is called once per frame
public void UpdateRoom(float xOffset,float yOffset)
{
    //Calculate grid distance from the starting point
    stepToStart = (int)(Mathf.Abs(transform.position.x / xOffset) + Mathf.Abs(transform.position.y / yOffset));

    text.text = stepToStart.ToString();

    if (roomUp)
        doorNumber++;
    if (roomDown)
        doorNumber++;
    if (roomLeft)
        doorNumber++;
    if (roomRight)
        doorNumber++;
}

private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        CameraControllor.instance.ChangeTarget(transform);
        
    }
}
}