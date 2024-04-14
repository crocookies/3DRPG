using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    [SerializeField]
    private float atk;
    [SerializeField]
    private float mtk;
    [SerializeField]
    private float minAtk;
    [SerializeField]
    private float maxAtk;
    [SerializeField]
    private float minMtk;
    [SerializeField]
    private float maxMtk;

    private Monster monster;

    void Start()
    {
        monster = GetComponentInParent<Monster>();
        atk = monster.atk;
        mtk = monster.mtk;
        minAtk = monster.maxAtk;
        maxAtk = monster.minAtk;
        minMtk = monster.maxMtk;
        maxMtk = monster.minMtk;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !PlayerController.instance.hit && !PlayerController.instance.dash)
        {
            Debug.Log("몬스터 공격");

            float deviation = Random.Range(minAtk, maxAtk);
            float damage = (atk - Player.instance.def) * deviation;

            if (damage > 0)
                Player.instance.curHP -= damage;
        }
    }
}
