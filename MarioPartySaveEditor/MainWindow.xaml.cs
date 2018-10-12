using Microsoft.Win32;
using System;
using System.Windows;
using MahApps.Metro.Controls;
using System.Diagnostics;

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
                else
                {
                    MessageBox.Show("Invalid Save File !");
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/SubstituteCS/Super-Mario-Part-Save-Editor");
        }
    }
}
