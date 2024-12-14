using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class egitimManagerlevel : MonoBehaviour
{

    [SerializeField]
    private GameObject startBtn, geriDonbtn;

    [SerializeField]
    private GameObject fadePnl;

    [SerializeField]
    private GameObject kok�ciPrefab;

    [SerializeField]
    private Transform content;

    [SerializeField]
    private Sprite[] kok�ciResimler;


    [SerializeField]
    private Sprite[] kokD�s�Resimler;

    [SerializeField]
    private Image kokKisiImage;

    [SerializeField]
    private Text aciklamaText;

    [SerializeField]
    private AudioClip Alistirmaclip;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aciklamaText.text = "";
        fadePnl.SetActive(true);
        fadePnl.GetComponent<CanvasGroup>().alpha = 1;

        fadePnl.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(ilkAyariyap);
        if (startBtn != null)
        {
            startBtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        }

        if (geriDonbtn != null)
        {
            geriDonbtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        }

        fadePnl.GetComponent<CanvasGroup>().DOFade(0,1f).OnComplete(ilkAyariyap);

        kokKisiImage.sprite = kokD�s�Resimler[0];
    }
    void ilkAyariyap()
    {
        fadePnl.SetActive(false);
        aciklamaText.text = "Alttaki panelden resimleri s�r�kleyerek istedi�iniz resme t�klayarak k�k de�erlerini ��renebilirsiniz.";
        SesiCikar(Alistirmaclip);
        ButonlariAc();
        Kok�ciResimleriOlustur();
    }
    
    void ButonlariAc()
    {
        startBtn.GetComponent<RectTransform>().DOScale(1f,1f).SetEase(Ease.OutBounce);
        geriDonbtn.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }


    void Kok�ciResimleriOlustur()
    {
        for (int i = 0; i < kok�ciResimler.Length; i++)
        {
            GameObject kok�ciItem = Instantiate(kok�ciPrefab, content);

            kok�ciItem.GetComponent<kok�ciButtonManager>().butonNo = i;

            kok�ciItem.transform.GetChild(3).GetComponent<Image>().sprite = kok�ciResimler[i];
        
        }


    }
    public void KokDisiResimiGoster(int butonNo)
    {
        kokKisiImage.sprite = kokD�s�Resimler[butonNo];
    }

    public void MenuLevelineDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void OyunLevelineGit()
    {
        SceneManager.LoadScene("GameLevel");
    }



    void SesiCikar(AudioClip clip)
    {

        if (clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position,1f);
        }
    }


}
