using UnityEngine;
using UnityEngine.Pool;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private float _Speed = 8f;

    private IObjectPool<FireBall> _ManagedPool;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _Speed);
    }

    private void OnEnable()
    {
        
    }

    public void SetManagedPool(IObjectPool<FireBall> pool)
    {
        _ManagedPool = pool;
    }

    public void Shoot(Vector3 pos, float rot)
    {
        gameObject.transform.position = pos;
        gameObject.transform.rotation = Quaternion.Euler(0, rot, 0);

        Invoke("DestroyBullet", 2.5f);
    }

    public void DestroyBullet()
    {
        _ManagedPool.Release(this);
    }
}
