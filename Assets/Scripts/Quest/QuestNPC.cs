using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestNPC : MonoBehaviour
{
    private Vector3 distance;

    private GameObject player;

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
    private bool talking;

    private float lastTalk;

    // ���۰��� 0, ����Ʈ�� 1, �Ϸᰡ�� 2, �Ϸ� 3
    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (GameManager.Instance.paused || GameManager.Instance.shop || GameManager.Instance.equipShop)
            return;

        distance = new Vector3(player.transform.position.x - gameObject.transform.position.x, gameObject.transform.position.y, player.transform.position.z - gameObject.transform.position.z);

        if (Input.GetKeyDown(KeyCode.F) && lastTalk > 0.1f)
        {
            lastTalk = 0;

            if (Mathf.Abs(distance.magnitude) < 2.5f && !talking && !GameManager.Instance.talkEvent)
            {
                GameManager.Instance.StartTalking();
                talkingCanvas.SetActive(true);
                talkNum = 0;

                switch (Player.instance.questState[questId])
                {
                    case 0:
                        StartTalking(beforeQuest);
                        break;
                    case 1:
                        StartTalking(questing);
                        break;
                    case 2:
                        StartTalking(completeQuest);
                        break;
                    case 3:
                        StartTalking(afterQuest);
                        break;
                }
            }
            else if (GameManager.Instance.talkEvent)
            {
                if (talking)
                {
                    switch (Player.instance.questState[questId])
                    {
                        case 0:
                            SkipTalking(beforeQuest);
                            break;
                        case 1:
                            SkipTalking(questing);
                            break;
                        case 2:
                            SkipTalking(completeQuest);
                            break;
                        case 3:
                            SkipTalking(afterQuest);
                            break;
                    }
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
    }

    private void LateUpdate()
    {
        Questing();

        lastTalk += Time.unscaledDeltaTime;
    }

    void StartTalking(string[] talk)
    {
        Debug.Log("��� ����");
        nameText.text = npcName;
        talkText.text = "";
        StartCoroutine(Talking(talk));
    }

    IEnumerator Talking(string[] talk)
    {
        Debug.Log("��� ��");
        talking = true;

        for (int index = 0; index < talk[talkNum].Length; index++)
        {
            yield return new WaitForSecondsRealtime(0.05f);

            if (!talking)
                break;

            talkText.text += talk[talkNum][index];
        }

        talking = false;

        yield return null;
    }

    void NextTalking(string[] talk)
    {
        if (talkNum < talk.Length - 1)
        {
            Debug.Log("���� ���");
            talkNum++;
            StartTalking(talk);
        }
        else
        {
            EndTalking();
        }
    }

    void SkipTalking(string[] talk)
    {
        Debug.Log("��� ��ŵ");
        talking = false;
        StopCoroutine(Talking(talk));
        talkText.text = talk[talkNum];
    }

    void EndTalking()
    {
        Debug.Log("��� ��");
        talkingCanvas.SetActive(false);
        GameManager.Instance.EndTalking();

        if (Player.instance.questState[questId] == 0)
        {
            Player.instance.questState[questId] = 1;
        }
        else if (Player.instance.questState[questId] == 2)
        {
            Player.instance.questState[questId] = 3;
            Player.instance.money += Player.instance.questRewardMoney[questId];
            Player.instance.exp += Player.instance.questRewardExp[questId];
        }
    }

    void Questing()
    {
        if (Player.instance.questValue[questId] >= Player.instance.questCompleteValue[questId] && Player.instance.questState[questId] == 1)
        {
            Player.instance.questState[questId] = 2;
        }
    }
}
