using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class QuickSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private int slotNum;

    private float lastClick;

    private bool doubleClick;

    public Sprite empty;

    GameObject itemCount;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        slotNum = transform.GetSiblingIndex();
        itemCount = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (Player.instance.quickSlotCnt[slotNum] <= 0)
        {
            image.sprite = empty;
            itemCount.SetActive(false);

            Player.instance.quickSlotId[slotNum] = 0;
            Player.instance.quickSlotCnt[slotNum] = 0;
            Player.instance.quickSlotName[slotNum] = "";
            Player.instance.quickSlotRecoveryHP[slotNum] = 0;
            Player.instance.quickSlotRecoveryMP[slotNum] = 0;
        }
        else if (Player.instance.quickSlotCnt[slotNum] > 0)
        {
            image.sprite = Player.instance.quickSlotIcon[slotNum];
            itemCount.SetActive(true);
            itemCount.GetComponent<Text>().text = Player.instance.quickSlotCnt[slotNum].ToString();
        }
    }

    private void LateUpdate()
    {
        lastClick += Time.unscaledDeltaTime;

        if (lastClick > 0.5f)
            doubleClick = false;
    }

    public void OnBeginDrag(PointerEventData eventData) // �巡�� ����
    {
        Inventory.instance.draging = true;
    }

    public void OnDrag(PointerEventData eventData) // �巡�� ��
    {

    }

    public void OnEndDrag(PointerEventData eventData) // �巡�� ��
    {
        Inventory.instance.draging = false;
        Inventory.instance.SlotChange(Inventory.instance.slotNum, Inventory.instance.otherSlotNum, Inventory.instance.slotType, Inventory.instance.otherSlotType);
    }

    public void OnPointerClick(PointerEventData eventData) // Ŭ��
    {
        lastClick = 0;
    }

    public void OnPointerEnter(PointerEventData eventData) // Ŀ�� �ø�
    {
        Inventory.instance.onSlot = true;

        if (!Inventory.instance.draging)
        {
            Inventory.instance.slotType = "������";
            Inventory.instance.slotNum = slotNum;
        }
        else
        {
            Inventory.instance.otherSlotType = "������";
            Inventory.instance.otherSlotNum = slotNum;
        }
    }

    public void OnPointerExit(PointerEventData eventData) // Ŀ�� ����
    {
        Inventory.instance.onSlot = false;
    }
}
