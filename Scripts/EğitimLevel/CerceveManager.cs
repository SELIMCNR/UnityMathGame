using UnityEngine;
using UnityEngine.UI;



public class CerceveManager : MonoBehaviour
{

    private Image cerceveResmi;

    int randomDeger;
    Color color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        cerceveResmi = GetComponent<Image>();
        RengiDegistir();


    }

    // Update is called once per frame
    void Update()
    {
        


    }


    void RengiDegistir()
    {
        randomDeger = Random.Range(0, 50);
        if (randomDeger <= 10)
        {
            color = Color.magenta;
        }
        else if (randomDeger <= 20)
        {
            color = Color.red;
        }
        else if (randomDeger <= 30)
        {
            color = Color.green;
        }
        else if (randomDeger <=40)
        {
            color = Color.blue;
        }
        else if (randomDeger <= 50)
        {
            color = Color.red;
        }


        if (cerceveResmi != null)
        {
            cerceveResmi.color = color;
        }

    }
}
