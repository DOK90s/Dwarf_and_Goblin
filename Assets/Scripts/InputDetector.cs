using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputDetector : MonoBehaviour
{
    void Update()
    {
        // Controlla se il pulsante sinistro del mouse è stato cliccato
        if (Input.GetMouseButtonDown(0))
        {
            // Esegui un Raycast dalla posizione del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Controlla se l'oggetto colpito ha uno script "Regione"
                Territory territory = hit.collider.GetComponent<Territory>();
                if (territory != null)
                {
                    // Chiama il metodo OnMouseClick della regione
                    territory.OnLeftMouseClick();
                }
            }
        }else
        // Controlla se il pulsante destro del mouse è stato cliccato
        if (Input.GetMouseButtonDown(1))
        {
            // Esegui un Raycast dalla posizione del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Controlla se l'oggetto colpito ha uno script "Regione"
                Territory territory = hit.collider.GetComponent<Territory>();
                if (territory != null)
                {
                    // Chiama il metodo OnMouseClick della regione
                    territory.OnRightMouseClick();
                }
            }
        }
    }
}
