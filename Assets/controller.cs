using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float moveSpeed = 10f; // Increased movement speed
    public float moveInterval = 2f; // Adjust this to control the interval between movements

    private Vector3 upPosition;
    private Vector3 downPosition;
    public Transform top;
    private Coroutine moveCoroutine; // Track the current movement coroutine

    void Start()
    {
        // Calculate global target positions
        upPosition = new Vector3(top.position.x, 0.8f, top.position.z);
        downPosition = new Vector3(top.position.x, -19.2f, top.position.z); // Adjusted to -40.2

        // Start invoking the moveUp function repeatedly with the specified interval
        
    }
    public void moveUp() {
        CancelInvoke("moveDown1");
        InvokeRepeating("moveUp1", 0f, moveInterval); 
    }
    public void moveDown()
    {
        CancelInvoke("moveUp1");
        InvokeRepeating("moveDown1", 0f, moveInterval);
    }
    public void moveUp1()
    {
        //Debug.Log("Moving up to position: " + upPosition);
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveToPosition(upPosition));
    }

    public void moveDown1()
    {
        //Debug.Log("Moving down to position: " + downPosition);
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveToPosition(downPosition));
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        //Debug.Log("Moving to position: " + targetPosition);
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Debug distance to target
            float distance = Vector3.Distance(transform.position, targetPosition);
            //Debug.Log("Distance to target: " + distance);

            yield return null;
        }
        // Ensure the object reaches the exact target position
        transform.position = targetPosition;
        //Debug.Log("Reached the target position: " + targetPosition);
    }
}
