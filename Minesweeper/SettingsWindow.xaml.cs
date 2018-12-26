﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_OnClosing(object sender, CancelEventArgs e)
        {
            ((GuiController)DataContext).SaveSettings();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ((GuiController) DataContext)?.SetDifficultLevel(((ToggleButton)sender).Tag.ToString());
        }
    }
}