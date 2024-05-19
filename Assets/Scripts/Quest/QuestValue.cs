using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestValue : MonoBehaviour
{
    [SerializeField]
    private int id;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDisable()
    {
        if (Player.instance.questState[id] == 1)
        {
            Player.instance.questValue[id]++;
        }
    }
}
