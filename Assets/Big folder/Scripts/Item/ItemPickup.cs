using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        pickUp();

    }

    void pickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.add(item);

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
        //add to inventory
    }
}
