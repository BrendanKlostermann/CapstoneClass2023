using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Extremely_Casual_Game_Organizer.PageFiles
{
    /// <summary>
    ///  Created By: Jacob Lindauer
    ///  Date: 02/10/2023
    ///  
    /// This class file will handle any navigation procsses between the pages. 
    /// Depening on the page being views the naviagtion function buttons will change to cooralate what functions the next page will require.
    /// 
    /// This should take a page file input and show what buttons are required and then display next page along with necessary button functions.
    /// 
    /// After buttons are called they will be visible but NOT function. In order to do that you need to create click events in the code to handle these
    /// </summary>
    public class PageControl
    {
        MainWindow _mainWindow = null;

        public PageControl()
        {
           _mainWindow = (MainWindow)Application.Current.MainWindow;
        }
        public void LoadPage(Page pageFile)
        {
            if (pageFile != null)
            {
                try
                {
                    // Need to set content to NULL so page does not load previous pages.
                    _mainWindow.frameLoad.Content = null;

                    _mainWindow.grdFrameFunctions.Visibility = Visibility.Visible;

                    ResetButtons();
                    _mainWindow.frameLoad.Navigate(pageFile);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Failed loading next page", ex.InnerException.Message);
                }
            }
            else
            {
                MessageBox.Show("Failed loading next page" + "\n\n" + "Page does not exist");
            }
        }

        // Button Function Methods
        private void ResetButtons()
        {
            // Resets button content and visibility for each button
            foreach (Button button in _mainWindow.grdFrameFunctions.Children)
            {
                button.Visibility = Visibility.Hidden;
                button.Content = "";
            }
        }
        public Button ShowReadOnly()
        {
            Button viewButton = _mainWindow.btnFunction1;
            viewButton.Visibility = Visibility.Visible;

            viewButton.Content = "View";

            return viewButton;
        }
        public List<Button> ShowFullCRUD()
        {
            List<Button> buttonList = new List<Button>();

            Button addButton = _mainWindow.btnFunction1;
            addButton.Visibility = Visibility.Visible;

            addButton.Content = "Add New";

            buttonList.Add(addButton);

            Button viewButton = _mainWindow.btnFunction2;
            viewButton.Visibility = Visibility.Visible;

            viewButton.Content = "View";

            buttonList.Add(viewButton);

            Button updateButton = _mainWindow.btnFunction3;
            updateButton.Visibility = Visibility.Visible;

            updateButton.Content = "Edit";

            buttonList.Add(updateButton);

            Button removeButton = _mainWindow.btnFunction4;
            removeButton.Visibility = Visibility.Visible;

            removeButton.Content = "Delete";

            buttonList.Add(removeButton);

            return buttonList;
        }
        public Button ShowGoBack()
        {
            Button goBack = _mainWindow.btnFunction8;
            goBack.Visibility = Visibility.Visible;

            goBack.Content = "Go Back";

            return goBack;
        }
        public Button SetCustomButton(string content, int buttonNumber)
        {
            int enableButton = buttonNumber;
            // Button number will only work for int 1-8 as there are only 8 function buttons
            Button button = new Button();

            switch (enableButton)
            {
                case 1:
                    button = _mainWindow.btnFunction1;
                    button.Visibility = Visibility.Visible;
                    button.Content = content;
                    break;
                case 2:
                    button = _mainWindow.btnFunction2;
                    button.Visibility = Visibility.Visible;
                    button.Content = content;
                    break;
                case 3:
                    button = _mainWindow.btnFunction3;
                    button.Visibility = Visibility.Visible;
                    button.Content = content;
                    break;
                case 4:
                    button = _mainWindow.btnFunction4;
                    button.Visibility = Visibility.Visible;
                    button.Content = content;
                    break;
                case 5:
                    button = _mainWindow.btnFunction5;
                    button.Visibility = Visibility.Visible;
                    button.Content = content;
                    break;
                case 6:
                    button = _mainWindow.btnFunction6;
                    button.Visibility = Visibility.Visible;
                    button.Content = content;
                    break;
                case 7:
                    button = _mainWindow.btnFunction7;
                    button.Visibility = Visibility.Visible;
                    button.Content = content;
                    break;
                case 8:
                    button = _mainWindow.btnFunction8;
                    button.Visibility = Visibility.Visible;
                    button.Content = content;
                    break;
                default:
                    break;
            }
            return button;
        }
    }
}
