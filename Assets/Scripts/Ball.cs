using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("���� �浹");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ʈ���� �ȿ� ����");
    }
}
