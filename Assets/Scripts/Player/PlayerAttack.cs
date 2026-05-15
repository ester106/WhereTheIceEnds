using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject snowballPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject snowball = Instantiate(
            snowballPrefab,
            firePoint.position,
            Quaternion.identity
        );

        Rigidbody2D rb = snowball.GetComponent<Rigidbody2D>();

        float direction = transform.localScale.x;

        rb.velocity = new Vector2(direction * 20f, 0);
    }
}