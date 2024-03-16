using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draging : MonoBehaviour
{
    Vector3 mousePosition;

    private Vector3 GetMousePos() //nesnenin d�nyadaki konumunu cameran�n(ekran) (x, y) kordinatlar�na g�re d�n�st�r�r.
    {
        return Camera.main.WorldToScreenPoint(transform.position);
        /*
        kameran�n rotasyonu ve konumuna g�re ekrandaki yerini bulur.
        Bu yuzden kamera hareket ettiginde kordinatlar degisir.
        (x--> y) (y--> z) (z--> x)
        */
    }
    private void OnMouseDown() //kullanici fareyle cisme bastiginda
    {
        mousePosition = Input.mousePosition - GetMousePos(); //cisim ile mouseun kordinat fark�n� hesapl�yor
        mousePosition.z = 5f - GetMousePos().z;
    }
    private void OnMouseDrag() //as�l islem
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }
}
