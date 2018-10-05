using Microsoft.Win32;
using System;
using System.Windows;
using MahApps.Metro.Controls;


namespace MarioPartySaveEditor
{

    public partial class MainWindow : MetroWindow
    {
        GameSave Save;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenSaveButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                if (GameSave.Read(openFileDialog.FileName, out Save))
                {
                    MessageBox.Show("Save is valid ... Loaded.");
                    try
                    {
                        DataContext = Save;
                    }
                    catch (Exception) { } //who cares
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Save == null)
            {
                MessageBox.Show("No Loaded Save !");
                return;
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                if (GameSave.Save(Save, saveFileDialog.FileName))
                {
                    MessageBox.Show("... Saved !");

                }
            }
        }
    }
}
