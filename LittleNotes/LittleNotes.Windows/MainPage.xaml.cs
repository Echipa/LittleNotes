using Windows.ApplicationModel.DataTransfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace LittleNotes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {

            this.InitializeComponent();
            // Tell Windows 8 that our app can share.
            DataTransferManager.GetForCurrentView().DataRequested += MainPage_DataRequested;
        }

        private void NewNoteBtn_Click(object sender, RoutedEventArgs e)
        {

            // Hide the menu.
            NotesGrid.Visibility = Visibility.Collapsed;
            // Reset the content of the text editor since we are starting a blank note.
            Notepad.Text = "";
            // Show text editor.
            Notepad.Visibility = Visibility.Visible;


        }

        private void NotesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveClose_Click(object sender, RoutedEventArgs e)
        {
            // If we are in text editing mode.
            if (Notepad.Visibility == Visibility.Visible)
            {
                // Creates a new textblock that for this note.
                TextBlock block = new TextBlock();
                block.Width = 250;
                block.Height = 125;
                block.Text = Notepad.Text;

                // Assign the click function.
                block.Tapped += block_Tapped;

                // Add that note to the grid.
                NotesGrid.Items.Add(block);

                // Go back to main menu.
                Notepad.Visibility = Visibility.Collapsed;
                NotesGrid.Visibility = Visibility.Visible;

            }
        }
        private void block_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Get a reference to the block that has been tapped.
            TextBlock block = sender as TextBlock;

            // Open the text editor with the content of that block.
            Notepad.Text = block.Text;
            NotesGrid.Visibility = Visibility.Collapsed;
            Notepad.Visibility = Visibility.Visible;

            // Since we are currently editing this block, remove it from the menu.
            // It will be added again once we save the note.
            NotesGrid.Items.Remove(block);
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in NotesGrid.SelectedItems)
            {
                // Don't delete the "New Note" button.
                if (element.GetType() != typeof(Button))
                    NotesGrid.Items.Remove(element);
            }
        }
        void MainPage_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            // We only have text to share when a note is selected.
            if (Notepad.Visibility == Visibility.Visible)
            {
                DataPackage requestData = args.Request.Data;
                requestData.Properties.Title = "My little note";
                requestData.SetText(Notepad.Text);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // If we are in text editing mode.
            if (Notepad.Visibility == Visibility.Visible)
            {
                // Creates a new textblock that for this note.
                TextBlock block = new TextBlock();
                block.Width = 250;
                block.Height = 125;
                block.Text = Notepad.Text;

                // Assign the click function.
                block.Tapped += block_Tapped;

                // Add that note to the grid.
                NotesGrid.Items.Add(block);


            }


        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            // If we are in text editing mode.
            if (Notepad.Visibility == Visibility.Visible)
            {
                // Go back to main menu.
                Notepad.Visibility = Visibility.Collapsed;
                NotesGrid.Visibility = Visibility.Visible;

            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    }

    // You should use the MediaElement.IsFullWindow property instead
    // to enable and disable full window rendering.
    private bool _isFullscreenToggle = false;
    public bool IsFullscreen
    {
        get { return _isFullscreenToggle; }
        set { _isFullscreenToggle = value; }
    }



   
        
  


    private void btnPlay_Click(object sender, RoutedEventArgs e)
    {
        if (videoMediaElement.DefaultPlaybackRate != 1)
        {
            videoMediaElement.DefaultPlaybackRate = 1.0;
        }

        videoMediaElement.Play();
    }

    private void btnPause_Click(object sender, RoutedEventArgs e)
    {
            videoMediaElement.Pause();
    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
        videoMediaElement.Stop();
    }

    private void btnForward_Click(object sender, RoutedEventArgs e)
    {
        videoMediaElement.DefaultPlaybackRate = 2.0;
        videoMediaElement.Play();
    }

    private void btnReverse_Click(object sender, RoutedEventArgs e)
    {
        videoMediaElement.DefaultPlaybackRate = -2;
        videoMediaElement.Play();;
    }

    private void btnVolumeDown_Click(object sender, RoutedEventArgs e)
    {
        if (videoMediaElement.IsMuted)
        {
            videoMediaElement.IsMuted = false;
        }

        if (videoMediaElement.Volume < 1)
        {
            videoMediaElement.Volume += .1;
        }
    }

    private void btnMute_Click(object sender, RoutedEventArgs e)
    {
        videoMediaElement.IsMuted = !videoMediaElement.IsMuted;
    }

    private void btnVolumeUp_Click(object sender, RoutedEventArgs e)
    {
        if (videoMediaElement.IsMuted)
        {
            videoMediaElement.IsMuted = false;
        }

        if (videoMediaElement.Volume > 0)
        {
            videoMediaElement.Volume -= .1;
        }
    }

    private void cbAudioTracks_SelectionChanged(
        object sender, SelectionChangedEventArgs e)
    {
        videoMediaElement.AudioStreamIndex = cbAudioTracks.SelectedIndex;
    }
    
    private void PopulateAudioTracks(
        MediaElement media, ComboBox audioSelection)
    {
        if (media.AudioStreamCount > 0)
        {
            for (int index = 0; index < media.AudioStreamCount; index++)
            {
                ComboBoxItem track = new ComboBoxItem();
                track.Content = media.GetAudioStreamLanguage(index);
                audioSelection.Items.Add(track);
            }
        }
    }

    



    private bool _sliderpressed = false;


    void timelineSlider_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
    {
        if (!_sliderpressed)
        {
            videoMediaElement.Position = TimeSpan.FromSeconds(e.NewValue);
        }
    }

   

    private void videoMediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
    {
        // get HRESULT from event args 
        string hr = GetHresultFromErrorMessage(e);

        // Handle media failed event appropriately 
    }

    private string GetHresultFromErrorMessage(ExceptionRoutedEventArgs e)
    {
        String hr = String.Empty;
        String token = "HRESULT - ";
        const int hrLength = 10;     // eg "0xFFFFFFFF"

        int tokenPos = e.ErrorMessage.IndexOf(token, StringComparison.Ordinal);
        if (tokenPos != -1)
        {
            hr = e.ErrorMessage.Substring(tokenPos + token.Length, hrLength);
        }

        return hr;
    }

    private DispatcherTimer _timer;

   

 

  

   

    private double SliderFrequency(TimeSpan timevalue)
    {
        double stepfrequency = -1;

        double absvalue = (int)Math.Round(
            timevalue.TotalSeconds, MidpointRounding.AwayFromZero);

        stepfrequency = (int)(Math.Round(absvalue / 100));

        if (timevalue.TotalMinutes >= 10 && timevalue.TotalMinutes < 30)
        {
            stepfrequency = 10;
        }
        else if (timevalue.TotalMinutes >= 30 && timevalue.TotalMinutes < 60)
        {
            stepfrequency = 30;
        }
        else if (timevalue.TotalHours >= 1)
        {
            stepfrequency = 60;
        }

        if (stepfrequency == 0) stepfrequency += 1;

        if (stepfrequency == 1)
        {
            stepfrequency = absvalue / 100;
        }

        return stepfrequency;
    }
}
    }




