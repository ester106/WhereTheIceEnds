using UnityEngine;

public class Snowball : MonoBehaviour
{
    private double startTime;
    private double lifeSpawn = 0.8;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime > lifeSpawn)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        EnemyHealth enemy = obj.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}