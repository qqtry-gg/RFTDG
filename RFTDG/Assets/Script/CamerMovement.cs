using UnityEngine;

public class CamerMovement : MonoBehaviour
{
    [SerializeField] Camera camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            camera.orthographicSize -= scroll;
            camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 3f, 8.6f);
        }
        float movementVertical = Input.GetAxis("Vertical");
        float movementHorizontal = Input.GetAxis("Horizontal");
        Vector3 CurrentPosition = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);


        CurrentPosition.y = camera.transform.position.y + (movementVertical / 20 * Time.deltaTime);
        CurrentPosition.x = camera.transform.position.x + (movementHorizontal / 20 * Time.deltaTime);


        CurrentPosition.y = Mathf.Clamp(CurrentPosition.y, -6f, 6f);
        CurrentPosition.x = Mathf.Clamp(CurrentPosition.x, -10f, 10f);

        camera.transform.position = CurrentPosition;

    }
}
