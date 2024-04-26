using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed;
    public int damage;
    public bool freeze;
    public bool burn;
    public bool poison;
    float angle;
    public void InitializeBullet(float bulletSpeed, int bulletDamage, bool shouldFreeze, bool shouldBurn, bool shouldPoison, float bulletAngle, bool Player)
    {
        speed = bulletSpeed;
        damage = bulletDamage;
        freeze = shouldFreeze;
        burn = shouldBurn;
        poison = shouldPoison;
        angle = bulletAngle;

        if (Player)
        {
            transform.gameObject.tag = "Bullet";
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else
        {
            transform.gameObject.tag = "EnemyBullet";
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        BulletMovement();
    }

    void BulletMovement()
    {
        // Configurar la dirección y velocidad de la bala
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));

        // Mover la bala a la posición inicial basada en la velocidad
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Room")
        {
            Destroy(gameObject);
        }
    }
}
