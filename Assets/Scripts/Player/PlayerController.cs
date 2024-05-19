using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float finalSpeed;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float dashForce;

    [SerializeField]
    private float magicCost;
    [SerializeField]
    private float runCost;
    [SerializeField]
    private float dashCost;

    [SerializeField]
    private float smoothness;

    private float lastJump;
    private float lastLand;
    private float lastHit;

    private bool run;
    public bool dash;
    public bool jumping;
    private bool landing;
    private bool attacking;
    private bool magic;
    public bool hit;
    private bool stun;
    private bool die;
    public bool wallCheck;

    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject attackCollider;
    [SerializeField]
    private GameObject slashEffect;
    [SerializeField]
    private GameObject fireballPrefab;

    private Monster monster;

    Vector3 forward;
    Vector3 right;
    Vector3 moveDir;

    private Animator animator;
    private Camera camera;
    private Rigidbody rigidbody;

    private IObjectPool<FireBall> _Pool;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
        _Pool = new ObjectPool<FireBall>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, maxSize: 10);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
        slashEffect.GetComponent<ParticleSystem>().Stop();
        slashEffect.GetComponent<ParticleSystem>().enableEmission = false;

        gameObject.transform.position = Player.instance.playerPos;
    }

    private void Update()
    {
        if (GameManager.Instance.paused || GameManager.Instance.shop || GameManager.Instance.equipShop || GameManager.Instance.talkEvent)
            return;

        Die();
        Revive();

        if (die || stun)
            return;

        InputManager();
        InputMovement();
        InputRotation();
        StateManager();
    }

    private void LateUpdate()
    {
        Player.instance.playerPos = gameObject.transform.position;

        if (die || stun || GameManager.Instance.paused || GameManager.Instance.shop || GameManager.Instance.equipShop || GameManager.Instance.talkEvent)
            return;

        lastJump += Time.deltaTime;
        lastHit += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rigidbody.angularVelocity = Vector3.zero;
    }

    // Object Pooling
    #region
    private FireBall CreateBullet()
    {
        FireBall bullet = Instantiate(fireballPrefab).GetComponent<FireBall>();
        bullet.SetManagedPool(_Pool);
        return bullet;
    }

    private void OnGetBullet(FireBall bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseBullet(FireBall bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(FireBall bullet)
    {
        Destroy(bullet.gameObject);
    }
    #endregion

    // Player Move Control
    #region
    private void InputMovement()
    {
        if (attacking || magic)
        {
            run = false;
            finalSpeed = 0;
            animator.SetFloat("Move", 0);
            return;
        }

        finalSpeed = (run) ? runSpeed : speed;

        forward = camera.transform.TransformDirection(Vector3.forward);
        right = camera.transform.TransformDirection(Vector3.right);

        moveDir = (forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal"));
        moveDir.y = 0;

        if (!wallCheck)
            rigidbody.transform.position += moveDir.normalized * finalSpeed * Time.deltaTime;

        float percent = ((run) ? 1 : 0.5f) * moveDir.normalized.magnitude;
        animator.SetFloat("Move", percent, 0.1f, Time.deltaTime);
    }

    private void InputRotation()
    {
        if (attacking || magic)
            return;

        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z)), Time.deltaTime * smoothness);
        }
    }
    #endregion

    // Player Control
    #region
    private void InputManager()
    {
        if (Input.GetButtonDown("Fire3") && (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) && landing && !dash && Player.instance.curSP > runCost)
        {
            run = true;

            if (Player.instance.curSP > dashCost)
            {
                StopAllCoroutines();
                animator.SetBool("Attack", false);
                animator.SetBool("Magic", false);
                slashEffect.GetComponent<ParticleSystem>().enableEmission = false;
                attackCollider.GetComponent<BoxCollider>().enabled = false;
                StartCoroutine(Dash());
                attacking = false;
                magic = false;
            } 
        }

        if (Input.GetButtonUp("Fire3"))
        {
            run = false;
        }

        if (Input.GetButtonDown("Jump"))
            Jump();

        if (Input.GetButtonDown("Fire1") && landing && !attacking && !magic)
        {
            StartCoroutine(Attack());
        }

        if (Input.GetButtonDown("Fire2") && landing && !attacking && !magic)
        {
            magic = true;
            StartCoroutine(Magic());
        }

        if (Input.GetButtonUp("Fire2"))
        {
            magic = false;
        }
    }

    private void StateManager()
    {
        if (run)
            Player.instance.curSP -= Time.deltaTime;

        if (Player.instance.curSP < 0)
            run = false;

        if (run || !landing)
            weapon.GetComponent<MeshRenderer>().enabled = false;
        else
            weapon.GetComponent<MeshRenderer>().enabled = true;

        if (landing)
            lastLand += Time.deltaTime;
        else
            lastLand = 0;

        if (magic)
            animator.SetBool("Magic", true);
        else
            animator.SetBool("Magic", false);

        

        if (Player.instance.curSP < Player.instance.maxSP && !run && !dash)
            Player.instance.curSP += Time.deltaTime;
    }

    private void Jump()
    {
        if (landing && !jumping && lastLand > 0.2f)
        {
            SoundEffect.instance.Jump();
            lastJump = 0;
            jumping = true;
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            StartCoroutine(JumpingAnimation());
        }
    }

    private IEnumerator Dash()
    {
        SoundEffect.instance.Dash();
        dash = true;
        Player.instance.curSP -= dashCost;
        runSpeed = 10;

        yield return new WaitForSeconds(0.3f);

        dash = false;
        runSpeed = 6;

        yield return null;
    }

    private IEnumerator Attack()
    {
        attacking = true;
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(0.4f);

        SoundEffect.instance.Attack();
        attackCollider.GetComponent<BoxCollider>().enabled = true;
        slashEffect.GetComponent<ParticleSystem>().enableEmission = true;
        slashEffect.GetComponent<ParticleSystem>().Stop();
        slashEffect.GetComponent<ParticleSystem>().Play();

        yield return new WaitForSeconds(0.7f);

        slashEffect.GetComponent<ParticleSystem>().enableEmission = false;
        attackCollider.GetComponent<BoxCollider>().enabled = false;

        yield return new WaitForSeconds(0.2f);

        animator.SetBool("Attack", false);
        attacking = false;

        yield return null;
    }

    private IEnumerator Magic()
    {
        animator.SetTrigger("Magic");

        while (magic && Player.instance.curMP >= magicCost)
        {
            SoundEffect.instance.Magic();
            Player.instance.curMP -= magicCost;
            var pos = gameObject.transform.position;
            var rot = gameObject.transform.localRotation.eulerAngles.y;
            var bullet = _Pool.Get();
            bullet.Shoot(pos, rot);

            yield return new WaitForSeconds(0.75f);
        }

        yield return null;
    }
    #endregion

    // Jump Animation
    #region
    private IEnumerator JumpingAnimation()
    {
        animator.SetBool("Jump", true);

        yield return new WaitForSeconds(0.1f);

        animator.SetTrigger("Air");

        yield return null;
    }

    private IEnumerator LandingAnimation()
    {
        animator.SetTrigger("Land");

        yield return new WaitForSeconds(0.1f);

        animator.SetBool("Jump", false);

        yield return null;
    }
    #endregion

    // Damaged
    #region
    private IEnumerator Hit()
    {
        SoundEffect.instance.Hit();
        hit = true;

        yield return new WaitForSeconds(0.25f);

        hit = false;

        yield return null;
    }

    private IEnumerator StunHit()
    {
        yield return null;
    }
    
    private void Die()
    {
        if (Player.instance.curHP < 0 && !die)
        {
            SoundEffect.instance.Die();
            die = true;
            StopAllCoroutines();
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("Stun");
            animator.SetTrigger("Die");
        }
    }

    private void Revive()
    {
        if (GameManager.Instance.paused)
            return;

        if (die && Input.GetKeyDown(KeyCode.R))
        {
            Player.instance.curHP = Player.instance.maxHP;
            animator.SetTrigger("Revive");
            gameObject.transform.position = new Vector3(0, 0, 0);
            die = false;
        }
    }
    #endregion

    // Collision & Trigger
    #region
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            landing = true;
            if (lastJump > 0.1f)
            {
                jumping = false;

                StartCoroutine(LandingAnimation());
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") && lastJump > 0.1f && jumping)
        {
            jumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            landing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MonsterAttack") && !die && !hit && !dash && lastHit > 0.1f)
        {
            lastHit = 0;
            StartCoroutine(Hit());
        }
    }
    #endregion
}
