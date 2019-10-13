using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PictureSnap
{
    public partial class CameraView : ContentPage
    {
        public CameraView()
        {
            InitializeComponent();

            BindingContext = new CameraViewViewModel();
        }
        
        public async void OnTakePictureClicked(object sender, EventArgs eventArgs)
        {
            if (CrossMedia.IsSupported)
            {
                var res = await DisplayActionSheet("Choose source", "Cancel", "Gallery", "Camera");

                if (res != "Cancel")
                {
                    var bc = (CameraViewViewModel)BindingContext;
                    
                    switch (res)
                    {
                        case "Gallery":
                            await bc.OnGalleryPickImage();
                            break;
                        case "Camera":
                            await bc.OnCameraTakeImage();
                            break;
                    }
                }
            }
        }
    }
}