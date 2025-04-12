using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance; 

    [SerializeField] protected float onFiring;
    public float OnFiring => onFiring;

    protected Vector4 direction;

    public Vector4 Direction => direction; 

    
      
    [SerializeField] protected Vector3 mouseWorldPos;
    public Vector3 MousePosition { get => mouseWorldPos; }
    private void Awake()
    {
        if (InputManager.instance != null) Debug.LogError("Only 1 InputManager allow to exits");
        InputManager.instance = this;
    }

    private void Update()
    {
        this.GetMouseDown();
        this.GetDirectionInputByKeyDown();
    }

    void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }

    protected virtual void GetMousePos()
    {
            this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetDirectionInputByKeyDown()
    {
        this.direction.x = (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) ? 1 : 0;
        this.direction.y = (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) ? 1 : 0;
        this.direction.z = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) ? 1 : 0;
        this.direction.w = (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) ? 1 : 0;

        //if (this.direction.x == 1) Debug.Log($"Left");
        //if (this.direction.y == 1) Debug.Log($"Righta");
        //if (this.direction.z == 1) Debug.Log($"Up");
        //if (this.direction.w == 1) Debug.Log($"Down");
    }
}
