using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using Xamarin.CommunityToolkit.UI.Views;

namespace XamarinTestApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            try
            {
                InitializeComponent();
                VideoPlayu();
            }
            catch (Exception ex)
            {

            }
        }

        async void VideoPlayu()
        {
            try
            {
                YoutubeClient youtube = new YoutubeClient();

                StreamManifest streamManifest = await youtube.Videos.Streams.GetManifestAsync("https://www.youtube.com/watch?v=3jCsZBEuvvw");

                IVideoStreamInfo streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                if (streamInfo != null)
                {
                    Media.Source = streamInfo.Url;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
