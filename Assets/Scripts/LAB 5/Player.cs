using UnityEngine;

public class Player : MonoBehaviour
{
    public int str;
    public int dtx;
    public int spd;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            transform.position += Vector3.forward;

        if (Input.GetKeyDown(KeyCode.S))
            transform.position += Vector3.back;

        if (Input.GetKeyDown(KeyCode.A))
            transform.position += Vector3.left;

        if (Input.GetKeyDown(KeyCode.D))
            transform.position += Vector3.right;
    }

}
