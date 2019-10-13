using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace PictureSnap
{
    public class CameraViewViewModel : INotifyPropertyChanged
    {
        private MediaFile _mediaImage;
        public event PropertyChangedEventHandler PropertyChanged;

        public async Task OnGalleryPickImage()
        {
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaImage = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                });
            }
        }

        public async Task OnCameraTakeImage()
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                MediaImage = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                });
            }
        }

        public MediaFile MediaImage
        {
            get => _mediaImage;
            set
            {
                _mediaImage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MediaImage)));
            }
        }
    }
}