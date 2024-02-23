using UnityEngine;

public class EnemyGridMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float descentHeight = 0.5f;
    public float boundaryRight = 5.0f;
    public float boundaryLeft = -5.0f;

    private bool movingRight = true;

    public void StartMovement()
    {
        // Puedes iniciar el movimiento aquí, por ejemplo, comenzar una coroutina
        // o simplemente establecer una variable que el Update usará para mover el escuadrón.
    }

    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x >= boundaryRight)
            {
                LowerAndChangeDirection();
            }
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            if (transform.position.x <= boundaryLeft)
            {
                LowerAndChangeDirection();
            }
        }
    }

    private void LowerAndChangeDirection()
    {
        // Mueve la formación hacia abajo y cambia la dirección
        Vector3 newPosition = transform.position + Vector3.down * descentHeight;
        transform.position = newPosition;
        movingRight = !movingRight;

        // Aquí puedes aumentar la velocidad si lo deseas, para simular la dificultad creciente.
        moveSpeed *= 1.1f;
    }
}
