using UnityEngine;

public class Huevo : MonoBehaviour
{
    public float speed = 15f;
    private Vector2 direccion = Vector2.down;

    void Start()
    {
        BulletCounter.bulletCount++;
    }

    void Update()
    {
        transform.Translate(direccion * speed * Time.deltaTime);
    }

    public void SetDireccion(Vector2 nuevaDireccion)
    {
        direccion = new Vector2(nuevaDireccion.x, Mathf.Abs(nuevaDireccion.y) * -1).normalized;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        BulletCounter.bulletCount--;
    }
}
