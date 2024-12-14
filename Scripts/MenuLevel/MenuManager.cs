using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening; 

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject hakkimdaPanel;

    bool panelAcikmi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

   }

    public void OyunaBasla()
    {
        SceneManager.LoadScene("EgitimLevel");


    }

    public void HakkimdaPaneliniAc()
    {
        if (!panelAcikmi)
        {
            hakkimdaPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        }
        else
        {
            hakkimdaPanel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);

        }

        panelAcikmi = !panelAcikmi;

    }

    public void OyundanCik()
    {
        Application.Quit();
    }

}
