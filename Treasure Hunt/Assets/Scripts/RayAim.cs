using UnityEngine;
using System.Collections;

public class rayAim : MonoBehaviour{
    private Camera camera1;
    void Start(){
        camera1 = GetComponent<Camera>();
    }

    void Update(){
        if (Input.GetMouseButton(0))
        {
            Vector3 point = new Vector3(camera1.pixelWidth/2, camera1.pixelHeight/2, 0);
            Ray ray = camera1.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                StartCoroutine(SphereIndicator(hit.point));
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos){
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
}