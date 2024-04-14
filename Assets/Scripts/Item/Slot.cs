
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Slot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
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
        itemCount = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Player.instance.slotCnt[slotNum] <= 0)
        {
            image.sprite = empty;
            itemCount.SetActive(false);

            Player.instance.slotId[slotNum] = 0;
            Player.instance.slotCnt[slotNum] = 0;
            Player.instance.slotName[slotNum] = "";
            Player.instance.slotRecoveryHP[slotNum] = 0;
            Player.instance.slotRecoveryMP[slotNum] = 0;
        }
        else if (Player.instance.slotCnt[slotNum] > 0)
        {
            image.sprite = Player.instance.slotIcon[slotNum];
            itemCount.SetActive(true);
            itemCount.GetComponent<Text>().text = Player.instance.slotCnt[slotNum].ToString();
        }
    }

    private void LateUpdate()
    {
        lastClick += Time.unscaledDeltaTime;

        if (lastClick > 0.5f)
            doubleClick = false;
    }

    public void OnBeginDrag(PointerEventData eventData) // 드래그 시작
    {
        Inventory.instance.draging = true;
    }

    public void OnDrag(PointerEventData eventData) // 드래그 중
    {

    }

    public void OnEndDrag(PointerEventData eventData) // 드래그 끝
    {
        Inventory.instance.draging = false;
        Inventory.instance.SlotChange(Inventory.instance.slotNum, Inventory.instance.otherSlotNum);
    }

    public void OnPointerClick(PointerEventData eventData) // 클릭
    {
        lastClick = 0;

        UseItem();
    }

    public void OnPointerEnter(PointerEventData eventData) // 커서 올림
    {
        Inventory.instance.onSlot = true;

        if (!Inventory.instance.draging)
        {
            Inventory.instance.slotNum = slotNum;
        }
        else
        {
            Inventory.instance.otherSlotNum = slotNum;
        }
    }

    public void OnPointerExit(PointerEventData eventData) // 커서 내림
    {
        Inventory.instance.onSlot = false;
    }

    private void UseItem()
    {
        if (doubleClick && Player.instance.slotCnt[slotNum] > 0)
        {
            doubleClick = false;
            SoundEffect.instance.Item();
            Player.instance.slotCnt[slotNum]--;
            Player.instance.curHP += Player.instance.slotRecoveryHP[slotNum];
            Player.instance.curMP += Player.instance.slotRecoveryMP[slotNum];
        }
        else
        {
            doubleClick = true;
        }
    }
}