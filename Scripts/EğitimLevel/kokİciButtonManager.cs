using UnityEngine;
using UnityEngine.UI;

public class kokİciButtonManager : MonoBehaviour
{
    [SerializeField]
    private Image kokiciImage;

    public int butonNo;

    egitimManagerlevel egitimManagerlevel;

    private void Awake()
    {
        egitimManagerlevel = Object.FindAnyObjectByType<egitimManagerlevel>();  
    }


    public void ButonaTiklandi()
    {
        Debug.Log("Tıklandı "+butonNo);
        egitimManagerlevel.KokDisiResimiGoster(butonNo);
    }


}
