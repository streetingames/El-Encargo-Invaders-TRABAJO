using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject projectilePrefab;
    public static bool canShoot = true; // Ahora es estática

    // Procesamos la entrada en Update para no perder pulsaciones y movernos de
    // forma suave independientemente del framerate.
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
            canShoot = false; // Deshabilita disparos subsiguientes
        }
    }

    void Shoot()
    {
        //Vector3 shootPosition = transform.position + new Vector3(0, 10f, 0);
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
      
    }
}
