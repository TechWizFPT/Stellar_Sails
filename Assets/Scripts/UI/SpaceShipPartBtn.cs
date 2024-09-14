using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpaceShipPartBtn : MonoBehaviour
{
    [SerializeField] SpaceShipPart part;
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI partNameUI;
    private void Awake()
    {
        button = GetComponent<Button>();
        partNameUI = GetComponentInChildren<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        button.onClick.AddListener(ShowPartInfo);

    }

    private void OnDisable()
    {
        button.onClick.AddListener(ShowPartInfo);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(SpaceShipPart _part)
    {
        part = _part;
        partNameUI.text = part.spaceShipPartData.partName;
    }

    public void ShowPartInfo()
    {
        Debug.Log("Show part info Btn trigger");
        if (part == null) { return;}
        UI_Observer.Instance.ShowPartInfo?.Invoke(part);
    }
}
