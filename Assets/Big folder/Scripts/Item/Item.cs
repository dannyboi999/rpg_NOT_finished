using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //use the item
        //something might happen 

        Debug.Log("Item Used!!!!");
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.remove(this);
    }
}
 
