using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draging : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePos() //nesnenin dünyadaki konumunu cameranýn(ekran) (x, y) kordinatlarýna göre dönüstürür.
    {
        return Camera.main.WorldToScreenPoint(transform.position);
        /*
        kameranýn rotasyonu ve konumuna göre ekrandaki yerini bulur.
        Bu yuzden kamera hareket ettiginde kordinatlar degisir.
        (x--> y) (y--> z) (z--> x)
        */
    }
    private void OnMouseDown() //kullanici fareyle cisme bastiginda
    {
        mousePosition = Input.mousePosition - GetMousePos(); //cisim ile mouseun kordinat farkýný hesaplýyor
        mousePosition.z = 5f - GetMousePos().z;
    }
    private void OnMouseDrag() //asýl islem
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
