using UnityEngine;

public class MF : MonoBehaviour
{
    public GameObject objectToMove; // Asigna este en el Inspector
    public float moveDistance = 1.0f; // La distancia que el objeto se moverá hacia adelante

    // Esta función se llamará cuando el botón sea presionado
    public void MoveObjectForward()
    {
        if (objectToMove != null)
        {
            // Mueve el objeto hacia adelante
            objectToMove.transform.Translate(Vector3.forward * moveDistance);
        }
    }
}
