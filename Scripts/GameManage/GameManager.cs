using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] kok›ciResimler;

    [SerializeField]
    private Sprite[] kokDisiResimler;

    [SerializeField]
    private Image morKokDisiResim, maviKokDisiResim, griKokDisiResim;

    [SerializeField]
    private Image sariKokDisiResim, pembeKokDisiResim, yesilKokDisiResim;

    [SerializeField]
    private Image ustKok›ciResim, altKok›ciResim;

    [SerializeField]
    private GameObject geriDonbtn;

    [SerializeField]
    private Text dogruText, yanlisText, puanText, zamanText;

    [SerializeField]
    private Transform sorularDairesi;


    [SerializeField]
    private Transform solBar, sagBar;

    [SerializeField]
    private GameObject trueIcon, falseIcon, dogruYanlisObje;

    [SerializeField]
    private GameObject bonusObje;


    int hangiSoru;


    bool dairUsttemi;
    bool daireDonsunmu;

    string buttondakiResim;

    Vector3 solBarBirinciYer = new Vector3(-122f, 49.70007f, 0f);
    Vector3 solBar›kinciYer = new Vector3(-70f, 49.70007f, 0f);
    Vector3 solBarUcuncuYer = new Vector3(-49f, 49.70007f, 0f);

    Vector3 sagBarBirinciYer = new Vector3(125f, 49.70007f, 0f);
    Vector3 sagBar›kinciYer = new Vector3(70f, 49.70007f, 0f);
    Vector3 sagBarUcuncuYer = new Vector3(45f, 49.70007f, 0f);

    int kacinciYanlis;
    public int dogruAdeti, yanlisAdeti;
    public int toplamPuan, puanArtisi;
    int bonusAdet;

    bool buttonaBasildimi;

    [SerializeField]
    private AudioClip baslangicClip;

    [SerializeField]
    private AudioClip daireSesi, barKapanisSesi;

    void Start()
    {
        foreach (var sprite in kokDisiResimler)
        {
            Debug.Log(sprite.name);
        }

        dairUsttemi = true;
        daireDonsunmu = true;
        buttonaBasildimi = true;
       
        ilkAyariyap();
    

        dogruAdeti = 0;
        yanlisAdeti = 0;
        kacinciYanlis = 0;
        toplamPuan = 0;
        puanArtisi = 0;
        bonusAdet = 0;
        puanText.text = toplamPuan.ToString();

        SesiCikar(baslangicClip);

        ResimleriYerlestir();
    }

    void ilkAyariyap()
    {
      
        dogruText.text = "0";
        yanlisText.text = "0";

        zamanText.text = "0";

 
        if (geriDonbtn != null)
        {
            geriDonbtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        geriDonbtn.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBounce);

    }

    void ResimleriYerlestir()
    {
        if (kokDisiResimler.Length < 3)
        {
            Debug.LogError("Yeterli say˝da resim yok!");
            return;
        }

        hangiSoru = UnityEngine.Random.Range(0, kokDisiResimler.Length - 3);




        int rasteleDeger = UnityEngine.Random.Range(0, 100);

        if (dairUsttemi)
        {
            if (rasteleDeger <= 33)
            {
                morKokDisiResim.sprite = kokDisiResimler[hangiSoru];
                maviKokDisiResim.sprite = kokDisiResimler[hangiSoru + 1];
                griKokDisiResim.sprite = kokDisiResimler[hangiSoru + 2];
            }
            else if ( rasteleDeger <= 66)
            {
                morKokDisiResim.sprite = kokDisiResimler[hangiSoru + 1];
                maviKokDisiResim.sprite = kokDisiResimler[hangiSoru];
                griKokDisiResim.sprite = kokDisiResimler[hangiSoru + 2];
            }
            else 
            {
                morKokDisiResim.sprite = kokDisiResimler[hangiSoru + 1];
                maviKokDisiResim.sprite = kokDisiResimler[hangiSoru + 2];
                griKokDisiResim.sprite = kokDisiResimler[hangiSoru];
            }
        }
        else
        {
            if (rasteleDeger <= 33)
            {
                sariKokDisiResim.sprite = kokDisiResimler[hangiSoru];
                pembeKokDisiResim.sprite = kokDisiResimler[hangiSoru + 1];
                yesilKokDisiResim.sprite = kokDisiResimler[hangiSoru + 2];
            }
            else if (rasteleDeger <= 66)
            {
                sariKokDisiResim.sprite = kokDisiResimler[hangiSoru + 1];
                pembeKokDisiResim.sprite = kokDisiResimler[hangiSoru];
                yesilKokDisiResim.sprite = kokDisiResimler[hangiSoru + 2];
            }
            else
            {
                sariKokDisiResim.sprite = kokDisiResimler[hangiSoru + 1];
                pembeKokDisiResim.sprite = kokDisiResimler[hangiSoru + 2];
                yesilKokDisiResim.sprite = kokDisiResimler[hangiSoru];
            }
        }

        if (dairUsttemi)
        {
            ustKok›ciResim.sprite = kok›ciResimler[hangiSoru];
          //  Canvas.ForceUpdateCanvases();
            Debug.Log($"Ortadaki Gˆrsel Sprite: {ustKok›ciResim.sprite.name}, Beklenen: {kok›ciResimler[hangiSoru].name}");

        }
        else
        {
            altKok›ciResim.sprite = kok›ciResimler[hangiSoru];
          //  Canvas.ForceUpdateCanvases();
            Debug.Log($"Ortadaki Gˆrsel Sprite: {altKok›ciResim.sprite.name}, Beklenen: {kok›ciResimler[hangiSoru].name}");

        }

        dairUsttemi = !dairUsttemi;


    }

    public void ButtonaBasildi()
    {
        buttondakiResim = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;

        if (buttonaBasildimi)
        {
            Debug.Log(buttondakiResim);
            buttonaBasildimi = false;
            SonucuKontrolEt();

        }




    }

    void SonucuKontrolEt()
    {
        if (buttondakiResim == kokDisiResimler[hangiSoru].name)
        {
            dogruAdeti++;
            bonusAdet++;
            Debug.Log($"Buttondaki Resim: {buttondakiResim}, Doru Cevap: {kokDisiResimler[hangiSoru].name}");

            dogruText.text = dogruAdeti.ToString();
            DogruYanlis›conGoster(true);
            DaireyiCevir();

            Debug.Log("Doru Cevap");
            if (bonusAdet >= 5 && bonusAdet <= 9)
            {
                puanArtisi += 30;
                BonusScaleOn();
            }
            else
            {

                puanArtisi += 20;
            }

            if (bonusAdet > 9)
            {
                bonusAdet = 0;
                BonusScaleOff();

            }


            //dogru.text = (int.Parse(dogru.text) + 1).ToString();
            // puan.text = (int.Parse(puan.text) + 10).ToString();
        }
        else
        {
            BonusScaleOff();
            yanlisAdeti++;
            bonusAdet = 0;
            yanlisText.text = yanlisAdeti.ToString();
            DogruYanlis›conGoster(false);
            kacinciYanlis++;
            BarlariKapat(kacinciYanlis);
            puanArtisi -= 5;
            Debug.Log("Yanl˝˛ Cevap");
            Debug.Log($"Buttondaki Resim: {buttondakiResim}, Doru Cevap: {kokDisiResimler[hangiSoru].name}");

            //  yanlis.text = (int.Parse(yanlis.text) + 1).ToString();
            // puan.text = (int.Parse(puan.text) - 5).ToString();
        }
      


        toplamPuan += puanArtisi;

        if (toplamPuan <= 0)
        {
            toplamPuan = 0;
        }

        puanArtisi = 0;
        puanText.text = toplamPuan.ToString();

    }

    void DaireyiCevir()
    {
        if (daireDonsunmu)
        {
            daireDonsunmu = false;

            kacinciYanlis = 0;
            solBar.DOLocalMove(solBarBirinciYer, 0.2f);
            sagBar.DOLocalMove(sagBarBirinciYer, 0.2f);
          
            SesiCikar(daireSesi);

            ResimleriYerlestir();
            sorularDairesi.DORotate(sorularDairesi.rotation.eulerAngles + new Vector3(0, 0, 180f), 0.5f).OnComplete(daireDonsunmuTrueYap);

        }
    }

    void daireDonsunmuTrueYap()
    {
        buttonaBasildimi = true;
        daireDonsunmu = true;
    }


    void BarlariKapat(int kacinciYanlis)
    {

        SesiCikar(barKapanisSesi);

        if (kacinciYanlis == 1)
        {
            buttonaBasildimi = true;
            solBar.DOLocalMove(solBar›kinciYer, 0.2f);
            sagBar.DOLocalMove(sagBar›kinciYer, 0.2f);
        }
        else if (kacinciYanlis == 2)
        {
            buttonaBasildimi = false;
            solBar.DOLocalMove(solBarUcuncuYer, 0.2f);
            sagBar.DOLocalMove(sagBarUcuncuYer, 0.2f).OnComplete(BarKapanisiniBekle);
        }
     
    }

    void BarKapanisiniBekle()
    {
        daireDonsunmu = true;
        Invoke("DaireyiCevir", 1f);
    }

    void DogruYanlis›conGoster(bool dogrumu)
    {
        dogruYanlisObje.GetComponent<CanvasGroup>().alpha = 0;
        if (dogrumu)
        {
            trueIcon.SetActive(true);
            falseIcon.SetActive(false);

        }
        else
        {
            trueIcon.SetActive(false);
            falseIcon.SetActive(true);
        }
        dogruYanlisObje.GetComponent<CanvasGroup>().DOFade(1, 0.2f).OnComplete(trueFalseIconuAlphaKapat);
    }

    void trueFalseIconuAlphaKapat()
    {
        dogruYanlisObje.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
    }

    



    void BonusScaleOn()
    {
        bonusObje.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutElastic);
    }

    void BonusScaleOff()
    {
        bonusObje.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InElastic);
    }


    public void MenuLevelineDon()
    {
        SceneManager.LoadScene("EgitimLevel");
    }


    void SesiCikar(AudioClip clip)
    {

        if (clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        }
    }
}




