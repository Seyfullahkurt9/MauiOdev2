using System;


namespace MauiApp1;

public partial class KrediHesaplama : ContentPage
{
    public KrediHesaplama()
    {
        InitializeComponent();
    }
    private void Hesapla_Clicked(object sender, EventArgs e)
    {
        
        double krediTutari = Convert.ToDouble(txtKrediTutari.Text);
        double faizOrani = Convert.ToDouble(txtFaizOrani.Text);
        int vade = Convert.ToInt32(sliderVade.Value);

        
        double KKDF = 0, BSMV = 0;

        switch (pickerKrediTuru.SelectedItem.ToString())
        {
            case "Ýhtiyaç Kredisi":
                KKDF = 0.15; 
                BSMV = 0.10; 
                break;
            case "Konut Kredisi":
                KKDF = 0;    
                BSMV = 0;    
                break;
            case "Taþýt Kredisi":
                KKDF = 0.15; 
                BSMV = 0.05; 
                break;
            case "Ticari Kredi":
                KKDF = 0;    
                BSMV = 0.05; 
                break;
        }

        // Aylýk faiz oranýný hesaplayýn
        double brutFaiz = ((faizOrani + (faizOrani * BSMV) + (faizOrani * KKDF)) / 100);

        
        double taksit = ((Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1)) * krediTutari;

        
        double toplam = taksit * vade;

        
        double toplamFaiz = toplam - krediTutari;

       
        lblAylýkTaksit.Text = "Aylýk Taksit: " + taksit.ToString("C2");
        lblToplamOdeme.Text = "Toplam Ödeme: " + toplam.ToString("C2");
        lblToplamFaiz.Text = "Toplam Faiz: " + toplamFaiz.ToString("C2");
    }
    private void TxtVade_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(txtVade.Text))
        {
            int value;
            if (int.TryParse(txtVade.Text, out value))
            {
                
                sliderVade.Value = value;
            }
        }
    }
}
