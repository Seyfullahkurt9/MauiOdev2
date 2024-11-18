using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Graphics;
using System;


namespace MauiApp1;

public partial class ColorPicker : ContentPage
{
	public ColorPicker()
	{
		InitializeComponent();
        redSlider.ValueChanged += ColorSlider_ValueChanged;
        greenSlider.ValueChanged += ColorSlider_ValueChanged;
        blueSlider.ValueChanged += ColorSlider_ValueChanged;

        UpdateColor();
    }
    private void ColorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        byte red = (byte)redSlider.Value;
        byte green = (byte)greenSlider.Value;
        byte blue = (byte)blueSlider.Value;

        Color color = new Color(red, green, blue);
        colorCode.Text = $"Color Code = #{red:X2}{green:X2}{blue:X2}";
        colorPreview.Color = color;
    }

    private void RandomButton_Clicked(object sender, EventArgs e)
    {
        Random random = new Random();
        redSlider.Value = random.Next(0, 256);
        greenSlider.Value = random.Next(0, 256);
        blueSlider.Value = random.Next(0, 256);
    }
    private void ColorCode_Tapped(object sender, EventArgs e)
    {
        var colorValue = colorCode.Text.Replace("Color Code = ", "");
        Clipboard.SetTextAsync(colorValue);
        
        DisplayAlert("Kopyalandý", "Renk kodu panoya kopyalandý.", "Tamam");
    }
}
