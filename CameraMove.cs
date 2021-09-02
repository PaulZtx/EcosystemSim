using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public float speed = 10.0f;
    public float SensHor = 9.0f;
    public float SensVert = 9.0f;
    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;
    private float _rotationX = 0;
    private float fixedDeltaTime;
    public Slider slider;

    void Start()
    {
         slider = GameObject.Find("Canvas/Slider").gameObject.GetComponent<Slider>();
         this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void FixedUpdate()
    {
        KeyMove();
        Mouse();
        SliderEdit();
    }

    void KeyMove()
    {
        if (Input.GetKey("w")) transform.Translate(0, 0, speed);
        else if (Input.GetKey("s")) transform.Translate(0, 0, -speed);
        else if (Input.GetKey("a")) transform.Translate(-speed, 0, 0);
        else if (Input.GetKey("d")) transform.Translate(speed, 0, 0);
        else if (Input.GetKey("space")) transform.Translate(0, speed, 0, Space.World);
    }

    void SliderEdit()
    {
        Time.timeScale = slider.value;
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }

    void Mouse()
    {

        if (!Input.GetKey("left alt"))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _rotationX -= Input.GetAxis("Mouse Y") * SensVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = Input.GetAxis("Mouse X") * SensHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}