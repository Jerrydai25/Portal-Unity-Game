using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public float speed;
    float lookHorizontal = 0;
    float lookVertical = 0;
    public GameObject blueTp;
    public GameObject orangeTp;

    public GameObject blueTpPrefab;
    public GameObject orangeTpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * 100 * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * 10 * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {

            if (orangeTp != null) Destroy(orangeTp);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {

            if (blueTp != null) Destroy(blueTp);
        }

        lookHorizontal += Input.GetAxis("Mouse X");
        lookVertical += Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(-lookVertical, lookHorizontal, 0f);

        if (Input.GetMouseButtonDown(1)) 
        {
            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);
            // Shoot a ray, and check if it hits//

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Quaternion rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                //if it hits, then do something//

                if (orangeTp != null)
                
                    Destroy(orangeTp);

                    orangeTp = Instantiate(orangeTpPrefab, hit.point, rotation);
                
            }
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            ray.origin = Camera.main.transform.position;
            ray.direction = Camera.main.transform.forward;
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);
            // Shoot a ray, and check if it hits//

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                Quaternion rotation = Quaternion.LookRotation(hit.normal, Vector3.up);
                //if it hits, then do something//

                if (orangeTp != null)

                    Destroy(blueTp);

                blueTp = Instantiate(blueTpPrefab, hit.point, rotation);

            }

        }
    }
}