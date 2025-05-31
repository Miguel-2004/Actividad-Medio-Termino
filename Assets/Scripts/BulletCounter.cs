using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public static int bulletCount = 0;
    public TextMeshProUGUI contadorTexto;

    void Update()
    {
        contadorTexto.text = "Balas en pantalla: " + bulletCount;
    }
}
