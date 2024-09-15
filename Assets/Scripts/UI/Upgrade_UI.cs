using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_UI : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    [SerializeField] SpaceShipController currentShip;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    SpaceShipController spaceShipController;
    [Space]
    [SerializeField] Transform partBtnContaint;
    [SerializeField] SpaceShipPartBtn_UI spaceShipPartBtnUIPrefab;
    List<SpaceShipPartBtn_UI> spaceShipPartBtnList = new List<SpaceShipPartBtn_UI>();

    [SerializeField] SpaceShipPart seletedPart;

    [Space]
    [SerializeField] GameObject AmountPanel;
    [SerializeField] TextMeshProUGUI amountText;

    [SerializeField] GameObject DamagePanel;
    [SerializeField] TextMeshProUGUI damageText;

    [SerializeField] GameObject ASPDPanel;
    [SerializeField] TextMeshProUGUI aspdText;

    [SerializeField] GameObject SlotPanel;
    [SerializeField] TextMeshProUGUI slotText;

    [SerializeField] GameObject MoveSpeedPanel;
    [SerializeField] TextMeshProUGUI moveSpeedText;

    [Space]
    [SerializeField] Button upgradeBtn;

    bool isActive;
    private void Awake()
    {
        UI_Observer.Instance.ShowUpgradeSpaceShipUI += OpenUpgradeUI;
        UI_Observer.Instance.ShowPartInfo += ShowPartInfo;

        upgradeBtn.onClick.AddListener(UpgradeSpaceShipPart);

    }

    private void OnEnable()
    {


    }

    
    // Start is called before the first frame update
    void Start()
    {
        upgradePanel.SetActive(false);
        //gameObject.SetActive(false);
        Init();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnDisable()
    {

    }

    private void OnDestroy()
    {
        if (Application.isPlaying)
        {
            UI_Observer.Instance.ShowPartInfo -= ShowPartInfo;
            UI_Observer.Instance.ShowUpgradeSpaceShipUI -= OpenUpgradeUI;
            upgradeBtn.onClick.RemoveListener(UpgradeSpaceShipPart);

        }

    }


    void Init()
    {
        seletedPart =null;
        spaceShipPartBtnList.Clear();

        for (int i = 0; i < 5; i++)
        {
            //Instantiate(spaceShipPartBtnUIPrefab, partBtnContaint.transform);
            var tmp = Instantiate(spaceShipPartBtnUIPrefab, partBtnContaint.transform);
            tmp.gameObject.SetActive(false);
            spaceShipPartBtnList.Add(tmp);
        }

        AmountPanel.gameObject.SetActive(false);
        DamagePanel.gameObject.SetActive(false);
        ASPDPanel.gameObject.SetActive(false);
        SlotPanel.gameObject.SetActive(false);
        MoveSpeedPanel.gameObject.SetActive(false);
    }

    void OpenUpgradeUI(SpaceShipController spaceShip)
    {
        Debug.Log("Open upgrade UI ");

        spaceShipController = spaceShip;

        for (int i = 0; i < spaceShip.spaceShipParts.Count; i++)
        {
            spaceShipPartBtnList[i].Init(spaceShip.spaceShipParts[i]);
            spaceShipPartBtnList[i].gameObject.SetActive(true);
        }

        //upgradePanel.SetActive(true);
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }

        upgradePanel.SetActive(isActive);


    }

    void ShowPartInfo(SpaceShipPart part)
    {
        seletedPart = part;
        Debug.Log("Show Part info " + part.partName);

        AmountPanel.gameObject.SetActive(false);
        DamagePanel.gameObject.SetActive(false);
        ASPDPanel.gameObject.SetActive(false);
        SlotPanel.gameObject.SetActive(false);
        MoveSpeedPanel.gameObject.SetActive(false);

        if(part.spaceShipPartData.partInfo.Count <= 0 || part == null) {
            Debug.Log("SpaceShipPartData  partInfo list = 0 ");
            return; }
        switch (part.spaceShipPartData.partType)
        {
            case SpaceShipPartData.PartType.Gun:
                
                AmountPanel.gameObject.SetActive(true);
                amountText.text = part.spaceShipPartData.partInfo[part.currentLv].amount.ToString();
                DamagePanel.gameObject.SetActive(true);
                damageText.text = part.spaceShipPartData.partInfo[part.currentLv].damage.ToString();
                ASPDPanel.gameObject.SetActive(true);
                aspdText.text = part.spaceShipPartData.partInfo[part.currentLv].attackTime.ToString();

                break;
            case SpaceShipPartData.PartType.Cago:
                SlotPanel.gameObject.SetActive(true);
                slotText.text = part.spaceShipPartData.partInfo[part.currentLv].slot.ToString();

                break;
            case SpaceShipPartData.PartType.Engine:
                MoveSpeedPanel.gameObject.SetActive(true);
                moveSpeedText.text = part.spaceShipPartData.partInfo[part.currentLv].moveSpeed.ToString();

                break;
        }
        //textMeshProUGUI.info = gun.gunName;
    }


    public void UpgradeSpaceShipPart()
    {
        seletedPart?.Upgrade();
        ShowPartInfo(seletedPart);
    }
}
