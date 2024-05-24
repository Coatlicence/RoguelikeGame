using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftManager : MonoBehaviour
{
    //GameObject draggetItem;
    //GameObject Thisobject;
    //GameObject Icon;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    Icon = Resources.Load<GameObject>("empty/icon");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if(draggetItem != null)
    //    {
    //        draggetItem.transform.position = Input.mousePosition;
    //    }
        
    //}
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    if(draggetItem==null&& eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        GameObject gameObject = eventData.pointerCurrentRaycast.gameObject;
    //        CraftInventory inventoryItem = gameObject.GetComponent<CraftInventory>();
    //        InventoryItem item= gameObject.GetComponent<InventoryItem>();
    //        if(item!=null|| inventoryItem != null) 
    //        {
                
    //            //var tmp = Instantiate(Icon);
    //            //tmp.transform.parent = transform;
    //            //var img =tmp.GetComponent<Image>();
    //            //img.sprite =gameObject.GetComponent<ItemCell>().GetImage().sprite;
    //            gameObject.transform.parent = transform;
    //            draggetItem =gameObject;
    //            gameObject.SetActive(false);
    //            item.heldItem = null;
    //            Thisobject = gameObject;
    //            //Last = gameObject;
    //        }
    //    }
    //    //Debug.Log(eventData.pointerCurrentRaycast.gameObject);
    //}
    //public void OnPointerUp(PointerEventData eventData)
    //{
    //    if(draggetItem!=null&&eventData.pointerCurrentRaycast.gameObject!=null&&eventData.button == PointerEventData.InputButton.Left)
    //    {
    //        GameObject cliked = eventData.pointerCurrentRaycast.gameObject;
            
    //        CraftInventory inventoryItem = cliked.GetComponent<CraftInventory>();
    //        if(inventoryItem!=null)
    //        {
    //            transform.parent = cliked.transform;
    //            InventoryItem item = Thisobject.GetComponent<InventoryItem>();
    //            Thisobject.SetActive(true);
    //            item.SetHeldItem(Thisobject);
    //            Destroy(draggetItem);
    //            draggetItem = null;
    //            Thisobject = null;
    //        }
    //    }
    //}
}
