using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestNPC1 : MonoBehaviour
{
    private Vector3 distance;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float talkDis;
    [SerializeField]
    private string npcName;
    [SerializeField]
    private int questId;

    [SerializeField]
    private string[] beforeQuest;
    [SerializeField]
    private string[] questing;
    [SerializeField]
    private string[] completeQuest;
    [SerializeField]
    private string[] afterQuest;

    [SerializeField]
    private GameObject talkingCanvas;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private Text talkText;

    private int talkNum;

    private float lastTalk;

    // questState 시작가능 0, 퀘스트중 1, 완료가능 2, 완료 3
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (GameManager.Instance.paused || GameManager.Instance.shop || GameManager.Instance.equipShop)
            return;

        distance = new Vector3(player.transform.position.x - gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z - gameObject.transform.position.z);

        Interaction();
        Questing();
    }

    private void LateUpdate()
    {
        lastTalk += Time.unscaledDeltaTime;
    }

    private void Interaction()
    {
        if (Input.GetKeyDown(KeyCode.F) && Mathf.Abs(distance.magnitude) < 2.5f && lastTalk > 0.1f)
        {
            lastTalk = 0;

            if (!GameManager.Instance.talkEvent)
            {
                StartTalking();
            }
            else
            {
                switch (Player.instance.questState[questId])
                {
                    case 0:
                        NextTalking(beforeQuest);
                        break;
                    case 1:
                        NextTalking(questing);
                        break;
                    case 2:
                        NextTalking(completeQuest);
                        break;
                    case 3:
                        NextTalking(afterQuest);
                        break;
                }
            }
        }
    }

    private void StartTalking()
    {
        talkingCanvas.SetActive(true);
        nameText.text = npcName;
        talkNum = 0;
        GameManager.Instance.StartTalking();

        switch (Player.instance.questState[questId])
        {
            case 0:
                Talking(beforeQuest);
                break;
            case 1:
                Talking(questing);
                break;
            case 2:
                Talking(completeQuest);
                break;
            case 3:
                Talking(afterQuest);
                break;
        }
    }

    private void Talking(string[] talk)
    {
        talkText.text = talk[talkNum];
    }

    private void NextTalking(string[] talk)
    {
        talkNum++;

        if (talkNum < talk.Length)
        {
            switch (Player.instance.questState[questId])
            {
                case 0:
                    Talking(beforeQuest);
                    break;
                case 1:
                    Talking(questing);
                    break;
                case 2:
                    Talking(completeQuest);
                    break;
                case 3:
                    Talking(afterQuest);
                    break;
            }
        }
        else
        {
            ExitTalking();
        }
    }

    private void ExitTalking()
    {
        switch (Player.instance.questState[questId])
        {
            case 0:
                Player.instance.questState[questId] = 1;
                break;
            case 1:
                break;
            case 2:
                Player.instance.money += Player.instance.questRewardMoney[questId];
                Player.instance.exp += Player.instance.questRewardExp[questId];
                Player.instance.questState[questId] = 3;
                break;
            case 3:
                break;
        }

        GameManager.Instance.EndTalking();
        talkingCanvas.SetActive(false);
    }

    private void Questing()
    {
        if (Player.instance.questValue[questId] >= Player.instance.questCompleteValue[questId] && Player.instance.questState[questId] == 1)
        {
            Player.instance.questState[questId] = 2;
        }
    }
}
