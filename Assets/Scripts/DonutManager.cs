using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutManager : MonoBehaviour {
    
    public GameObject donut;
    public GameObject opc1;
    public GameObject opc2;
    public GameObject opc3;
    public GameObject opc4;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            donut.SetActive(true);
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            donut.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        }

        if (Input.GetMouseButton(0)) {
            float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

            //Debug.Log(distance_to_screen);

            Ray ray = new Ray(pos, transform.up);
            //Debug.DrawRay(pos, transform.up, Color.green);

            RaycastHit hitData;
            
            if (Physics.Raycast(ray, out hitData)) {
                if (hitData.collider.gameObject.tag == "donutOpc1") {
                    Debug.Log("1");
                    opc1.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                    opc2.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc3.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc4.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                } else if (hitData.collider.gameObject.tag == "donutOpc2") {
                    Debug.Log("2");
                    opc1.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc2.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                    opc3.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc4.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                } else if (hitData.collider.gameObject.tag == "donutOpc3") {
                    Debug.Log("3");
                    opc1.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc2.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc3.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                    opc4.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                } else if (hitData.collider.gameObject.tag == "donutOpc4") {
                    Debug.Log("4");
                    opc1.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc2.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc3.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
                    opc4.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                }
            } else {
                opc1.GetComponent<MeshRenderer>().materials[0].color =
                opc2.GetComponent<MeshRenderer>().materials[0].color =
                opc3.GetComponent<MeshRenderer>().materials[0].color =
                opc4.GetComponent<MeshRenderer>().materials[0].color = Color.grey;    
            }

        }

        if (Input.GetMouseButtonUp(0)) {
            opc1.GetComponent<MeshRenderer>().materials[0].color =
            opc2.GetComponent<MeshRenderer>().materials[0].color =
            opc3.GetComponent<MeshRenderer>().materials[0].color =
            opc4.GetComponent<MeshRenderer>().materials[0].color = Color.grey;
            donut.SetActive(false);
        }
    }
}