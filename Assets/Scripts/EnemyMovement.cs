using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 targetPosition; // La posición final en la formación
    public float speed = 5.0f; // Velocidad de movimiento
   
    private bool isMovingToFormation;
    public SquadronMovement squadronMovement;



    void Start()
    {
        // Encuentra el objeto EnemySquad y su componente SquadronMovement.
        squadronMovement = GameObject.Find("EnemySquad").GetComponent<SquadronMovement>();
        if (squadronMovement != null)
        {
            // Activa el script SquadronMovement.
            // squadronMovement.enabled = true;
        }

    }
    void Update()
    {
        if (isMovingToFormation)
        {
            MoveToFormation();
            if (gameObject == EnemySquadronGenerator.lastEnemy && !isMovingToFormation)
            {
                Debug.Log("El último enemigo ha llegado a su posición.");
                squadronMovement.enabled = true;


            }
        }
    }

    



    public void StartMoving()
    {
        isMovingToFormation = true;
    }

    private void MoveToFormation()
    {
        // Mover al enemigo hacia la posición de la formación a lo largo del eje Y
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        // Si el enemigo alcanza la posición, deja de moverse
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // Una pequeña tolerancia
        {
            isMovingToFormation = false;
        }
    }


}
