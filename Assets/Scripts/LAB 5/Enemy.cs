using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    private Transform player;

    void Start()
    {
        player = GameManager.instance.player.transform;
    }

    void Update()
    {
        
    }

    public void MoveTowardsPlayer()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * speed; // sin deltaTime → movimiento por turno
    }
}