using UnityEngine;

public class GallinaShooter : MonoBehaviour
{
    public GameObject huevoPrefab;
    public Transform firePoint;
    public float tiempoEntreDisparos = 1.2f;
    private float temporizador = 0f;

    private int patronActual = 0;
    private float duracionPatron = 10f;
    private float tiempoPatron = 0f;

    void Update()
    {
        temporizador += Time.deltaTime;
        tiempoPatron += Time.deltaTime;

        if (tiempoPatron > duracionPatron)
        {
            patronActual = (patronActual + 1) % 3;
            tiempoPatron = 0f;
        }

        if (temporizador >= tiempoEntreDisparos)
        {
            FirePattern();
            temporizador = 0f;
        }
    }

    void FirePattern()
    {
        switch (patronActual)
        {
            case 0:
                FireFan();
                break;
            case 1:
                FireCircle();
                break;
            case 2:
                FirePetal();
                break;
        }
    }

    void FireFan()
    {
        float[] angles = { -20f, 0f, 20f };
        foreach (float angle in angles)
        {
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            GameObject huevo = Instantiate(huevoPrefab, firePoint.position, rot);
            huevo.GetComponent<Huevo>().SetDireccion(rot * Vector2.down);
        }
    }

    void FireCircle()
    {
        int bulletCount = 6;
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * 360f / bulletCount;
            Quaternion rot = Quaternion.Euler(0, 0, angle);
            Vector2 dir = rot * Vector2.down;

            if (dir.y < 0)
            {
                GameObject huevo = Instantiate(huevoPrefab, firePoint.position, rot);
                huevo.GetComponent<Huevo>().SetDireccion(dir);
            }
        }
    }

    void FirePetal()
    {
        int petalCount = 2;
        int bulletsPerPetal = 3;
        float spreadAngle = 20f;

        for (int i = 0; i < petalCount; i++)
        {
            float baseAngle = i * (180f / petalCount) - 45f;

            for (int j = 0; j < bulletsPerPetal; j++)
            {
                float offset = (j - (bulletsPerPetal - 1) / 2f) * (spreadAngle / bulletsPerPetal);
                float angle = baseAngle + offset;

                Quaternion rot = Quaternion.Euler(0, 0, angle);
                GameObject huevo = Instantiate(huevoPrefab, firePoint.position, rot);
                huevo.GetComponent<Huevo>().SetDireccion(rot * Vector2.down);
            }
        }
    }
}
