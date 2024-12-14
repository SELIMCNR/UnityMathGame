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
    private GameObject kokÝciPrefab;

    [SerializeField]
    private Transform content;

    [SerializeField]
    private Sprite[] kokÝciResimler;


    [SerializeField]
    private Sprite[] kokDýsýResimler;

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

        kokKisiImage.sprite = kokDýsýResimler[0];
    }
    void ilkAyariyap()
    {
        fadePnl.SetActive(false);
        aciklamaText.text = "Alttaki panelden resimleri sürükleyerek istediðiniz resme týklayarak kök deðerlerini öðrenebilirsiniz.";
        SesiCikar(Alistirmaclip);
        ButonlariAc();
        KokÝciResimleriOlustur();
    }
    
    void ButonlariAc()
    {
        startBtn.GetComponent<RectTransform>().DOScale(1f,1f).SetEase(Ease.OutBounce);
        geriDonbtn.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBounce);
    }


    void KokÝciResimleriOlustur()
    {
        for (int i = 0; i < kokÝciResimler.Length; i++)
        {
            GameObject kokÝciItem = Instantiate(kokÝciPrefab, content);

            kokÝciItem.GetComponent<kokÝciButtonManager>().butonNo = i;

            kokÝciItem.transform.GetChild(3).GetComponent<Image>().sprite = kokÝciResimler[i];
        
        }


    }
    public void KokDisiResimiGoster(int butonNo)
    {
        kokKisiImage.sprite = kokDýsýResimler[butonNo];
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
