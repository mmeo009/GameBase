using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Rigidbody playerRb;
    public float moveSpeed;
    private void Awake()
    {
        player = GameObject.Find("Player");
        playerRb = GameObject.Find("Player").GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(cast, out hit))
            {
                if (hit.collider.tag == "Ground")
                {
                    if (player != null)
                    {
                        Vector3 direction = (hit.point - player.transform.position).normalized;
                        playerRb.MovePosition(player.transform.position + direction * moveSpeed * Time.deltaTime);
                    }
                }
                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);
            }
        }
    }
}
