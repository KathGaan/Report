using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObj : MonoBehaviour
{
    private Item info;

    public Item Info
    {
        set { info = value; }
        get { return info; }
    }

    private Image image;

    private Color selectedColor = new Color(1, 1, 0, 1);
    private Color deSelectedColor = new Color(1, 1, 0, 0);

    private bool selected;

    [SerializeField] Image itemImage;

    public Image ItemImage
    {
        get { return itemImage; }
    }
    
    //Start
    private void Start()
    {
        image = GetComponent<Image>();
    }

    //Button
    public void Select()
    {
        if (InventoryManager.selectedObject != null && InventoryManager.selectedObject != this)
            return;

        if(!selected)
        {
            image.color = selectedColor;
            InventoryManager.selectedObject = this;
            selected = true;
        }
        else
        {
            image.color = deSelectedColor;
            InventoryManager.selectedObject = null;
            selected = false;
        }
    }
    
}
