using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 4f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerPR"))
        {
            Destroy(other.gameObject); // Destruye el objeto con el que colisionó
            Destroy(gameObject); // Destruye el proyectil
            PlayerController.canShoot = true;
        }
        if (other.CompareTag("Tower"))
        {

            Destroy(gameObject); // Destruye el proyectil
            DestroyTowerFloor(other.gameObject);
            PlayerController.canShoot = true;
        }
        //Debug.Log(other.tag);
    }
    void DestroyTowerFloor(GameObject towerPart)
    {
        Transform parentTower = towerPart.transform.parent;
        if (parentTower != null && parentTower.childCount > 0)
        {
            // Encuentra y destruye el último piso (empezando por arriba)
            Transform topFloor = parentTower.GetChild(parentTower.childCount - 1);
            Destroy(topFloor.gameObject);

            // Opcional: Verifica si la torre ya no tiene pisos y toma acción adicional si es necesario
            if (parentTower.childCount == 0)
            {
                // Por ejemplo, destruir la base de la torre si se desea
                // Destroy(parentTower.gameObject);
            }
        }
    }
}

