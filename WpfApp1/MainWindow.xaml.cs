using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;





namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private string wygenerowaneHaslo = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGeneruj_Click(object sender, RoutedEventArgs e)
        {
            int dlugosc;
            if (!int.TryParse(txtDlugosc.Text, out dlugosc) || dlugosc < 4)
            {
                MessageBox.Show("Podaj poprawną długość (minimum 4).");
                return;
            }

            string maleLitery = "abcdefghijklmnopqrstuvwxyz";
            string duzeLitery = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cyfry = "0123456789";
            string znakiSpecjalne = "!@#$%^&*()_+-=";

            Random rand = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dlugosc; i++)
                sb.Append(maleLitery[rand.Next(maleLitery.Length)]);

            if (chkLitery.IsChecked == true && dlugosc > 0)
                sb[0] = duzeLitery[rand.Next(duzeLitery.Length)];

            if (chkCyfry.IsChecked == true && dlugosc > 1)
                sb[1] = cyfry[rand.Next(cyfry.Length)];

            if (chkZnaki.IsChecked == true && dlugosc > 2)
                sb[2] = znakiSpecjalne[rand.Next(znakiSpecjalne.Length)];

            wygenerowaneHaslo = sb.ToString();

            MessageBox.Show("Wygenerowane hasło: " + wygenerowaneHaslo, "Hasło");
        }

        private void btnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(wygenerowaneHaslo))
            {
                MessageBox.Show("Najpierw wygeneruj hasło!");
                return;
            }

            string imie = txtImie.Text;
            string nazwisko = txtNazwisko.Text;
            string stanowisko = (cmbStanowisko.SelectedItem as ComboBoxItem)?.Content.ToString();

            string info = $"Dane pracownika:\nImię: {imie}\nNazwisko: {nazwisko}\nStanowisko: {stanowisko}\nHasło: {wygenerowaneHaslo}";
            MessageBox.Show(info, "Podsumowanie");
        }
    }
}
