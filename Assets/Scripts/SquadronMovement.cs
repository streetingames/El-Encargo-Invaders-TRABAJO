
using UnityEngine;

public class SquadronMovement : MonoBehaviour
{
    public static float lateralSpeed = 3.0f; // Velocidad de movimiento lateral.
    public float advanceAmount = 5.0f; // Cuánto avanza el escuadrón en cada paso.
   
    public float jumpTime = 10;
    public float jumpSize = 1;

    public static bool movingRight = true; // Comienza moviéndose hacia la derecha al inicio.
    public static bool canAdvance=true;
   
    private int jumpTimeCounter=0;

    void FixedUpdate()
    {
        jumpTimeCounter++;
        if (jumpTimeCounter>= jumpTime)
        {
            jumpTimeCounter = 0; 

            if (movingRight)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * lateralSpeed * Time.deltaTime*jumpSize); // Moverse lateralmente hacia la derecha.
     
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * lateralSpeed * Time.deltaTime * jumpSize); // Moverse lateralmente hacia la izquierda.

    }

    public void Advance()
    {
        //float advanceStep = advanceAmount / EnemySquadronGenerator.rows;
        //transform.Translate(Vector3.forward * advanceStep); 
        transform.Translate(Vector3.forward * advanceAmount); // Mover hacia adelante en el eje X.
    }
}