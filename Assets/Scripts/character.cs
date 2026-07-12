using UnityEngine;

public class character : MonoBehaviour
{
    [SerializeField] private float walkspeed =5f;
    [SerializeField] private float runspeed = 10f;
    [SerializeField] private Transform cam;
    [SerializeField] private float MouseSensitivity = 2f;

    private CharacterController controller;
    private float pitch = 0f;
    private float yaw = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //walk and run
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool isRunning = Input.GetKey(KeyCode.LeftShift);//shift check
        Vector3 move = new Vector3(h,0f,v);

        controller.Move(move * walkspeed * Time.deltaTime);//walk
        if(isRunning == true){
            controller.Move(move * runspeed * Time.deltaTime);//run
        }

        //Mouse camera
        float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity;

        pitch -= mouseY;
        yaw += mouseX;

        pitch = Mathf.Clamp(pitch, -90f, 90f);
        //camera rotation
        cam.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
