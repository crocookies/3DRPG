using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private float curHP;
    [SerializeField]
    private float maxHP;
    [SerializeField]
    public float atk;
    [SerializeField]
    public float mtk;
    [SerializeField]
    public float minAtk;
    [SerializeField]
    public float maxAtk;
    [SerializeField]
    public float minMtk;
    [SerializeField]
    public float maxMtk;
    [SerializeField]
    private float def;
    [SerializeField]
    private float mdf;
    [SerializeField]
    private float exp;
    [SerializeField]
    private int minMoney;
    [SerializeField]
    private int maxMoney;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float maxDis;
    [SerializeField]
    private float minDis;

    [SerializeField]
    private Vector3 rezenPos;
    [SerializeField]
    private float rezenTime;

    private float lastAttack;

    private bool attcking;
    private bool hit;
    private bool die;

    private Vector3 distance;

    [SerializeField]
    private GameObject player;
    private GameObject attackCollider;

    Rigidbody rigidbody;
    Animator animator;

    private void Start()
    {
        player = GameObject.Find("Player");
        attackCollider = transform.GetChild(0).gameObject;

        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (die || hit)
            return;

        DistanceCheck();
        ChasePlayer();
        animator.SetFloat("Speed", rigidbody.velocity.magnitude);

        lastAttack += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rigidbody.angularVelocity = Vector3.zero;
    }

    private void OnEnable()
    {
        curHP = maxHP;
        die = false;
        gameObject.transform.position = rezenPos;
    }

    private void DistanceCheck()
    {
        distance = new Vector3(player.transform.position.x - gameObject.transform.position.x, player.transform.position.y - gameObject.transform.position.y, player.transform.position.z - gameObject.transform.position.z);

        if (Mathf.Abs(distance.magnitude) < minDis && !attcking && lastAttack > 2.5f)
        {
            StartCoroutine(Attack());
        }
    }

    private void ChasePlayer()
    {
        if ((Mathf.Abs(distance.magnitude) < maxDis && Mathf.Abs(distance.magnitude) > minDis && !attcking) || (curHP < maxHP && Mathf.Abs(distance.magnitude) > minDis && !attcking))
        {
            animator.SetBool("Move", true);
            transform.LookAt(player.transform);
            rigidbody.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private IEnumerator Attack()
    {
        attcking = true;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.2f);

        attackCollider.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(0.4f);

        attackCollider.GetComponent<BoxCollider>().enabled = false;

        lastAttack = 0;
        attcking = false;

        yield return null;
    }

    private IEnumerator Hit(float damage)
    {
        curHP -= damage;

        if (curHP < 0)
        {
            SoundEffect.instance.MonsterDie();
            die = true;
            animator.SetTrigger("Die");
            Player.instance.exp += exp;
            int money = Random.Range(minMoney, maxMoney);
            Player.instance.money += money;

            yield return new WaitForSeconds(2f);

            GameManager.Instance.MonsterRezen(gameObject, rezenPos, rezenTime);
        }
        else
        {
            hit = true;

            yield return new WaitForSeconds(0.2f);

            hit = false;
        }

        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Attack") && !hit && !die)
        {
            SoundEffect.instance.MonsterHit();
            float deviation = Random.Range(Player.instance.minAtk, Player.instance.maxAtk);
            float damage = (Player.instance.atk - def) * deviation;

            if (damage > 0)
                StartCoroutine(Hit(damage));
        }

        if (other.gameObject.CompareTag("Magic") && !hit && !die)
        {
            SoundEffect.instance.MonsterHit();
            float deviation = Random.Range(Player.instance.minMtk, Player.instance.maxMtk);
            float damage = (Player.instance.mtk - mdf) * deviation;

            if (damage > 0)
                StartCoroutine(Hit(damage));
        }
    }
}
