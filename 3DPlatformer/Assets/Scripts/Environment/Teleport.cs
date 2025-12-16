using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("The destination object with a Teleporter script attached.")]
    public Teleport destinationTeleporter;

    [Tooltip("The effect to create when teleporting")]
    public GameObject teleportEffect;

    private bool teleporterAvailable = true;

    // OnTriggerEnter вызывается, когда Collider входит в триггер
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && teleporterAvailable == true && destinationTeleporter != null)
        {
            Debug.Log(other.name + " colided with " + this.transform.parent.name + " teleport to " + destinationTeleporter.transform.parent.name);

            if (teleportEffect != null) 
            {
                Instantiate(teleportEffect, transform.position, transform.rotation, null);
            }
            

            destinationTeleporter.teleporterAvailable = false;

            CharacterController characterController = other.gameObject.GetComponent<CharacterController>();
            if (characterController != null) 
            { 
                characterController.enabled = false;
            }

            float hightOffset = transform.position.y - other.transform.position.y;

            other.transform.position = destinationTeleporter.transform.position - new Vector3(0,hightOffset,0);

            if (characterController != null)
            {
                characterController.enabled = true;
            }
        }
    }

    // OnTriggerExit вызывается, когда Collider перестает касаться триггера
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            teleporterAvailable = true;
        } 

    }

}
