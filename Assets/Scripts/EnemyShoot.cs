using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil a disparar
    public Transform firePoint; // Punto desde donde el enemigo dispara
    public float lifeTime = 5.0f;

   

    void Update()
    {
        AttemptToShoot();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerPR") || other.CompareTag("Tower"))
        {
            Destroy(other.gameObject); // Destruye el objeto con el que colisionó
            Destroy(gameObject); // Destruye el proyectil
        }
    }

    public void AttemptToShoot()
    {
        if (Random.Range(0, 2000) < 1) // 1/1000 de probabilidad de disparar
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 shootPosition = firePoint.position + new Vector3(0, .5f, 0);
        Instantiate(projectilePrefab, shootPosition, Quaternion.Euler(90, 0, -90));
    }
}
