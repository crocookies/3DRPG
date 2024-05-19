using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
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
    private float midDis;
    [SerializeField]
    private float minDis;

    [SerializeField]
    private Vector3 rezenPos;
    [SerializeField]
    private float rezenTime;

    private float lastAttack;
    private float lastHit;

    private bool attacking;
    private bool jumpAttacking;
    private bool hit;
    private bool die;

    private Vector3 distance;

    [SerializeField]
    private GameObject player;
    private GameObject attackCollider;

    [SerializeField]
    private Image HPBar;

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

    private void LateUpdate()
    {
        HPBar.fillAmount = curHP / maxHP;
        lastHit += Time.deltaTime;
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

        if (Mathf.Abs(distance.magnitude) < minDis && !attacking && !jumpAttacking && lastAttack > 2.5f)
        {
            StartCoroutine(Attack());
        }
        else if (Mathf.Abs(distance.magnitude) > minDis && Mathf.Abs(distance.magnitude) < midDis && !attacking && lastAttack > 2.5f)
        {
            StartCoroutine(JumpAttack());
        }
    }

    private void ChasePlayer()
    {
        if ((Mathf.Abs(distance.magnitude) < maxDis && Mathf.Abs(distance.magnitude) > minDis && !attacking) || (curHP < maxHP && Mathf.Abs(distance.magnitude) > minDis && !attacking))
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
        attacking = true;
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.2f);

        attackCollider.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(0.4f);

        attackCollider.GetComponent<BoxCollider>().enabled = false;

        lastAttack = 0;
        attacking = false;

        yield return null;
    }

    private IEnumerator JumpAttack()
    {
        jumpAttacking = true;
        rigidbody.AddForce(Vector3.up, ForceMode.Impulse);

        yield return new WaitForSeconds(0.2f);
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
        if (other.gameObject.CompareTag("Attack") && !hit && !die && lastHit > 0.1f)
        {
            lastHit = 0;
            SoundEffect.instance.MonsterHit();
            float deviation = Random.Range(Player.instance.minAtk, Player.instance.maxAtk);
            float damage = (Player.instance.atk - def) * deviation;

            if (damage > 0)
                StartCoroutine(Hit(damage));
        }

        if (other.gameObject.CompareTag("Magic") && !hit && !die && lastHit > 0.1f)
        {
            lastHit = 0;
            SoundEffect.instance.MonsterHit();
            float deviation = Random.Range(Player.instance.minMtk, Player.instance.maxMtk);
            float damage = (Player.instance.mtk - mdf) * deviation;

            if (damage > 0)
                StartCoroutine(Hit(damage));
        }
    }
}
