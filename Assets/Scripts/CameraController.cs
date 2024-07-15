using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float scrollSpeed = 10f;
    public Vector2 panLimitX = new Vector2(-20f, 20f);
    public Vector2 panLimitY = new Vector2(-10f, 10f);
    public Vector2 panLimitZ = new Vector2(-20f, 20f);

    public Vector3 startingDelta = new Vector3(0f,15,0f);

    public GameObject map;
    private Vector3 initialPosition;
    //public float centerSpeed = 5f;
    public Camera camera;

    private Vector3 lastMousePosition;

    private void Start()


    {
        //Trova la il MapManager e setta la posizione iniziale della camera
        map = GameObject.FindWithTag("Level");
        map.transform.position = initialPosition;
        // Posiziona la telecamera nella initialPosition all'inizio
        transform.position = initialPosition + startingDelta;
        initialPosition.z = startingDelta.z;
    }

    void Update()
    {
        // Controlla se il tasto destro del mouse è premuto
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 deltaMouse = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

            // Movimento della camera basato sul delta del mouse
            Vector3 newPosition = transform.position;

            // Movimenti sui tre assi
            newPosition.x -= deltaMouse.x * panSpeed * Time.deltaTime;
            newPosition.z -= deltaMouse.y * panSpeed * Time.deltaTime;

            // Limita il movimento della camera sugli assi X e Z
            newPosition.x = Mathf.Clamp(newPosition.x, panLimitX.x, panLimitX.y);
            newPosition.z = Mathf.Clamp(newPosition.z, panLimitZ.x, panLimitZ.y);

            transform.position = newPosition;
        }

        // Movimento sull'asse Y con la rotella del mouse
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0f)
        {
            // Zoom verso il puntatore del mouse
            Vector3 mousePosition = Input.mousePosition;
            Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, camera.nearClipPlane));
            Vector3 direction = mouseWorldPosition - transform.position;

            Vector3 newPosition = transform.position;
            newPosition += direction * scroll * scrollSpeed * Time.deltaTime;

            // Limita il movimento della camera sugli assi
            newPosition.x = Mathf.Clamp(newPosition.x, panLimitX.x, panLimitX.y);
            newPosition.y = Mathf.Clamp(newPosition.y, panLimitY.x, panLimitY.y);
            newPosition.z = Mathf.Clamp(newPosition.z, panLimitZ.x, panLimitZ.y);

            // Interpola verso la posizione iniziale quando si dezzomma (scroll negativo)
            if (scroll < 0f)
            {
                newPosition = Vector3.Lerp(newPosition, new Vector3(initialPosition.x, newPosition.y, initialPosition.z), scrollSpeed * Time.deltaTime);
            }

            transform.position = newPosition;
        }
    }
}