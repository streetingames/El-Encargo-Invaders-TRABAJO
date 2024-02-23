using UnityEngine;

public class ChangeSquadDir : MonoBehaviour
{
    private SquadronMovement squadronMovement;
    


    void Start()
    {
        // Encuentra el objeto que contiene el script SquadronMovement. 
        // Esto asume que el script se encuentra en el mismo objeto o en uno asignado como 'squadron'.
        squadronMovement = FindObjectOfType<SquadronMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LimitL"))
        {
            Debug.Log("toca izquierda");
            if (SquadronMovement.canAdvance) { squadronMovement.Advance(); SquadronMovement.canAdvance = false; Debug.Log("Avanza"); }
            SquadronMovement.movingRight = false; // Cambia a moverse hacia la derecha
        }
        else if (other.CompareTag("LimitR"))
        {
            Debug.Log("toca derecha");
            if (SquadronMovement.canAdvance) { squadronMovement.Advance(); SquadronMovement.canAdvance = false; Debug.Log("Avanza"); }
            SquadronMovement.movingRight = true; // Cambia a moverse hacia la izquierda
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LimitL") || other.CompareTag("LimitR"))
        {
            SquadronMovement.canAdvance = true; // Restablece al salir de la colisión, permitiendo futuros cambios.
        }
    }
}
