using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ContentManager : MonoBehaviour
{
    public List<Button> buttons; // T�m butonlar
    public List<ContentData> contents; // T�m i�erikler
    public ContentDisplay contentDisplay; // ��erik g�sterici
    public GameObject panel; // ��eri�in g�sterilece�i panel

    private void Start()
    {
        // Butonlar� dinamik olarak i�eriklere ba�la
        for (int i = 0; i < buttons.Count && i < contents.Count; i++)
        {
            int index = i; // Lambda ifadesi i�in yerel kopya
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    // Buton t�klamas�yla ilgili i�lem
    private void OnButtonClick(int contentIndex)
    {
        if (contentIndex >= 0 && contentIndex < contents.Count)
        {
            // Paneli aktif et
            panel.SetActive(true);

            // T�klanan i�eri�i g�ster
            contentDisplay.DisplayContent(contents[contentIndex]);

            // Di�er butonlar� gizle
            ToggleButtons(false);
        }
    }

    // Paneli kapat ve butonlar� geri getir
    public void ClosePanel()
    {
        panel.SetActive(false);
        contentDisplay.ClearContent();
        ToggleButtons(true);
    }

    // Butonlar�n g�r�n�rl�k durumunu de�i�tir
    private void ToggleButtons(bool state)
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(state);
        }
    }
}
