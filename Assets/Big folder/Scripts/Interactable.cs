using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    bool isFocused = false;
    bool hasInteracted = false; //lets it only interact once 
    Transform player;

    public virtual void Interact ()
    {
        //this method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    void Update()
    {
        //checks if its within radius to interact with something 
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    
    //this and the next one makes it so you can focus on and item and interact with it 
    public void OnFocused (Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
