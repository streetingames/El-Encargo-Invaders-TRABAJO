using System.Collections;
using UnityEngine;

public class EnemySquadronGenerator : MonoBehaviour
{
    public GameObject enemyType1Prefab;
    public GameObject enemyType2Prefab;
    public static GameObject lastEnemy;
    public Transform enemiesParent; // Agregar una referencia al objeto padre
    public Vector3 spawnPoint;
    public static int rows = 5;
    public int columns = 10;
    public float delayBetweenSpawns = 0f;
    public static Vector3 lastEnemyPos;
    private EnemyGridMovement gridMovementScript; // Referencia al script de movimiento del bloque
    void Start()
    {
        gridMovementScript = enemiesParent.GetComponent<EnemyGridMovement>();
        lastEnemyPos = CalculateFormationPosition(rows-1, columns-1);
        //Debug.Log(lastEnemyPosition);

        StartCoroutine(GenerateSquadron());
    }

    IEnumerator GenerateSquadron()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                GameObject enemyPrefab = (row < 2 || row == rows - 1) ? enemyType1Prefab : enemyType2Prefab;
                Vector3 formationPosition = CalculateFormationPosition(row, col);
                //Debug.Log(formationPosition);

                // Instancia el enemigo como hijo del objeto padre
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.Euler(0, -90, 0), enemiesParent);

                // Asigna la posición de la formación al enemigo
                EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
                enemyMovement.targetPosition = formationPosition;

                // Comienza el movimiento hacia la formación
                enemyMovement.StartMoving();

                yield return new WaitForSeconds(delayBetweenSpawns);
                if (row == rows - 1 && col == columns - 1) // Último enemigo
                {
                    lastEnemy = enemy; // Asegúrate de asignar correctamente el último enemigo aquí
                }
            }
        }
        // Añadir aquí la llamada a la inicialización del movimiento de la formación si es necesario
      // gridMovementScript.StartMovement();
       //Debug.Log("completa");
    }
 
    private Vector3 CalculateFormationPosition(int row, int col)
    {
        return new Vector3(row * 2.5f - 15, 0, col * 2.5f - 35);
    }

}
