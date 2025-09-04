using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 50f;
    void Update()
    {
        //transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
