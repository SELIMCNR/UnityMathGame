using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text zamanText;

    [SerializeField]
    private GameObject sonucPaneli;

    int kalanSure ;
    bool sureSayisinmi;

    GameManager gameManager;
    SonucManager sonucManager;

    [SerializeField]
    private AudioClip oyunBitisSesi;

    private void Awake()
    {
        gameManager = Object.FindAnyObjectByType<GameManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kalanSure = 90;
        sureSayisinmi = true;
        StartCoroutine(SureTimerRoutine());

    }


    IEnumerator SureTimerRoutine()
    {
        while (sureSayisinmi)
        {
            yield return new WaitForSeconds(1);
      
         
            if (kalanSure < 10)
            {
                
                zamanText.text = "0" +kalanSure.ToString();
                zamanText.color = Color.red;
            }
            else
            {
                zamanText.text = kalanSure.ToString();
            }
            if (kalanSure <= 0)
            {
                sureSayisinmi = false;
                zamanText.text = "";
                sonucPaneli.SetActive(true);

                SesiCikar(oyunBitisSesi);

                if (sonucPaneli != null)
                {
                    sonucManager = Object.FindAnyObjectByType<SonucManager>();
                    sonucManager.SonuclariYazdir(gameManager.dogruAdeti,gameManager.yanlisAdeti,gameManager.toplamPuan);
                }
            }

            kalanSure--;

        }
    }

    void SesiCikar(AudioClip clip)
    {

        if (clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
        }
    }
}
