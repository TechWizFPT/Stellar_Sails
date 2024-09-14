using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_UI : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    [SerializeField] SpaceShipController currentShip;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    SpaceShipController spaceShipController;
    [SerializeField] Transform partBtnContaint;
    [SerializeField] SpaceShipPartBtn spaceShipPartPrefab;
    List<SpaceShipPartBtn> listPartBtn = new List<SpaceShipPartBtn>();

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
    private void Awake()
    {

    }

    private void OnEnable()
    {
        UI_Observer.Instance.ShowUpgradeSpaceShipUI += OpenUpgradeUI;
        UI_Observer.Instance.ShowPartInfo += ShowPartInfo;

        upgradeBtn.onClick.AddListener(UpgradeSpaceShipPart);
    }

    private void OnDisable()
    {
        UI_Observer.Instance.ShowPartInfo -= ShowPartInfo;
        UI_Observer.Instance.ShowUpgradeSpaceShipUI -= OpenUpgradeUI;

        upgradeBtn.onClick.RemoveListener(UpgradeSpaceShipPart);

    }

    private void OnDestroy()
    {
        //upgradeBtn.onClick.RemoveListener(UpgradeSpaceShipPart);

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

    void Init()
    {
        seletedPart =null;
        listPartBtn.Clear();

        for (int i = 0; i < 5; i++)
        {
            //Instantiate(spaceShipPartPrefab, partBtnContaint.transform);
            var tmp = Instantiate(spaceShipPartPrefab, partBtnContaint.transform);
            tmp.gameObject.SetActive(false);
            listPartBtn.Add(tmp);
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
            listPartBtn[i].Init(spaceShip.spaceShipParts[i]);
            listPartBtn[i].gameObject.SetActive(true);
        }

        upgradePanel.SetActive(true);

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

        if(part.spaceShipPartData.partInfo.Count <= 0) {
            Debug.Log("SpaceShipPartData  partInfo list = 0 ");
            return; }
        switch (part.spaceShipPartData.partType)
        {
            case SpaceShipPartData.PartType.Gun:
                
                AmountPanel.gameObject.SetActive(true);
                amountText.text = part.spaceShipPartData.partInfo[0].amount.ToString();
                DamagePanel.gameObject.SetActive(true);
                damageText.text = part.spaceShipPartData.partInfo[0].damage.ToString();
                ASPDPanel.gameObject.SetActive(true);
                aspdText.text = part.spaceShipPartData.partInfo[0].attackTime.ToString();

                break;
            case SpaceShipPartData.PartType.Cago:
                SlotPanel.gameObject.SetActive(true);
                slotText.text = part.spaceShipPartData.partInfo[0].attackTime.ToString();

                break;
            case SpaceShipPartData.PartType.Engine:
                MoveSpeedPanel.gameObject.SetActive(true);
                moveSpeedText.text = part.spaceShipPartData.partInfo[0].attackTime.ToString();

                break;
        }
        //textMeshProUGUI.text = gun.gunName;
    }


    public void UpgradeSpaceShipPart()
    {
        seletedPart?.Upgrade();
    }
}
