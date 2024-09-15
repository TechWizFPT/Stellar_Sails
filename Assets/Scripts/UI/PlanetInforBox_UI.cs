using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInforBox_UI : MonoBehaviour
{
    public ItemData itemData;
    [Space]
    public Image icon;
    public TextMeshProUGUI info;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(ItemData _itemData)
    {
        itemData = _itemData;
        icon.sprite = itemData.itemIcon;
        info.text = itemData.itemInfo;
    }
}
