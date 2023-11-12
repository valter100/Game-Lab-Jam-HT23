using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollectible : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 0.04f;
    private float time;
    [SerializeField] float bounceMultiplier = 0.0001f;
    void Update()
    {
        time += Time.deltaTime;
        Rotate();
        Bounce();
    }
    private void Rotate()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }
    private void Bounce()
    {
        float newY = Mathf.Sin(time)  * bounceMultiplier;
        transform.position = new Vector3(transform.position.x, transform.position.y + newY, transform.position.z);
    }
    public void CollectFood()
    {

    }
}
