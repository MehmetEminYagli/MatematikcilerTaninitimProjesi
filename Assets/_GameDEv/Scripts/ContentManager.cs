using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ContentManager : MonoBehaviour
{
    public List<Button> buttons; // Tüm butonlar
    public List<ContentData> contents; // Tüm içerikler
    public ContentDisplay contentDisplay; // Ýçerik gösterici
    public GameObject panel; // Ýçeriðin gösterileceði panel

    private void Start()
    {
        // Butonlarý dinamik olarak içeriklere baðla
        for (int i = 0; i < buttons.Count && i < contents.Count; i++)
        {
            int index = i; // Lambda ifadesi için yerel kopya
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    // Buton týklamasýyla ilgili iþlem
    private void OnButtonClick(int contentIndex)
    {
        if (contentIndex >= 0 && contentIndex < contents.Count)
        {
            // Paneli aktif et
            panel.SetActive(true);

            // Týklanan içeriði göster
            contentDisplay.DisplayContent(contents[contentIndex]);

            // Diðer butonlarý gizle
            ToggleButtons(false);
        }
    }

    // Paneli kapat ve butonlarý geri getir
    public void ClosePanel()
    {
        panel.SetActive(false);
        contentDisplay.ClearContent();
        ToggleButtons(true);
    }

    // Butonlarýn görünürlük durumunu deðiþtir
    private void ToggleButtons(bool state)
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(state);
        }
    }
}
