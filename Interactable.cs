using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private GameObject player;

    public float maxDistanceToPlayer = 2f;

    public virtual void Interact()
    {
        Debug.Log("Interact");
    }

    public virtual bool CanInteract()
    {
        if (player)
        {
            // Check distance to player
            return Vector3.Distance(this.transform.position, player.transform.position) <= maxDistanceToPlayer;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerInteractionScript playerInteraction = collision.gameObject.GetComponent<PlayerInteractionScript>();
        if (playerInteraction)
        {
            player = collision.gameObject;
            playerInteraction.SubscribeInteractable(this);
        }        
    }

    private void OnCollisionExit(Collision collision)
    {
        PlayerInteractionScript playerInteraction = collision.gameObject.GetComponent<PlayerInteractionScript>();
        if (playerInteraction)
        {
            playerInteraction.UnsubscribeInteractable();
            player = null;
        }
    }

}
