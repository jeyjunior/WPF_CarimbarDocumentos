using System;
using System.IO;
using System.Windows;
using ImageMagick;

namespace WPF_CarimbarDocumentos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string inputImagePath = @"...\001.tiff";
        string outputImagePath = @"...\001_Carimbado.tiff";
        string stampText = "Este documento foi carimbado";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCarimbar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MagickImage image = new MagickImage(inputImagePath))
                {
                    DrawableText text = new DrawableText(10, 10, stampText);
                    image.Draw(text);

                    image.Write(outputImagePath);
                }

                MessageBox.Show("Marca d'água adicionada com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}