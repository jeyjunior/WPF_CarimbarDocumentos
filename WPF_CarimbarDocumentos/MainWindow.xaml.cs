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
        string inputImagePath = @"...\002.tiff";
        string outputImagePath = @"...\002_Carimbado.tiff";
        string stampText = "Este documento foi carimbado";
        int positionX = 10;
        int positionY = 10;
        string backgroundImagePath = @"...\marcaDagua.png";


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
                    // Carrega a imagem de fundo, se disponível
                    if (!string.IsNullOrEmpty(backgroundImagePath) && File.Exists(backgroundImagePath))
                    {
                        using (MagickImage backgroundImage = new MagickImage(backgroundImagePath))
                        {
                            image.Composite(backgroundImage, CompositeOperator.Over); // Sobrepor a imagem de fundo
                        }
                    }

                    DrawableText text = new DrawableText(positionX, positionY, stampText);

                    image.Draw(text);

                    image.Write(outputImagePath);
                }

                MessageBox.Show("Arquivo carimbado com sucesso.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}