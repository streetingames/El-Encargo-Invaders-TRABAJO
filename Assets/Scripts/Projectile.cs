using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;
    public float lifeTime = 5.0f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("EnemyPR"))
        {
            Destroy(other.gameObject); // Destruye el objeto con el que colisionó
            Destroy(gameObject); // Destruye el proyectil
            PlayerController.canShoot = true;
        }
        if (other.CompareTag("Enemy"))
        {
            EnemyProps enemyProps = other.gameObject.GetComponent<EnemyProps>();
            Destroy(gameObject); // Destruye el proyectil
           
            SquadronMovement.lateralSpeed = SquadronMovement.lateralSpeed + .2f;

            // Calcula los puntos basados en la fila del enemigo.
            int puntos = 0;

            if (enemyProps.fila < 2) // Primera y segunda fila.
            {
                puntos = 10;
            }
            else if (enemyProps.fila < 4) // Tercera y cuarta fila.
            {
                puntos = 20;
            }
            else // Última fila.
            {
                puntos = 30;
            }
            
            Destroy(other.gameObject); // Destruye el objeto con el que colisionó
            // Añade los puntos a la puntuación.
            ScoreManager.instance.AddScore(puntos); PlayerController.canShoot = true;
        }
        if (other.CompareTag("Tower"))
        {
      
            Destroy(gameObject); // Destruye el proyectil
            DestroyTowerFloor(other.gameObject);
            PlayerController.canShoot = true;
        }
        Debug.Log(other.tag);
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
    void OnDestroy()
    {
        PlayerController.canShoot = true; // Permite disparar de nuevo cuando el proyectil se destruye
    }
    
}
