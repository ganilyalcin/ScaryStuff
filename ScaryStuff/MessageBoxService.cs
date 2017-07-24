using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScaryStuff
{
    public interface IMessageBoxService
    {
        void ShowMessage(string text, string caption, MessageType messageType);
    }


    public class MessageBoxService : IMessageBoxService
    {
        public void ShowMessage(string text, string caption, MessageType messageType)
        {
            int imageType = 0;

            switch (messageType)
            {
                case MessageType.Error:
                    imageType = (int)MessageBoxImage.Error;
                    break;
                case MessageType.Warning:
                    imageType = (int)MessageBoxImage.Warning;
                    break;
                case MessageType.Information:
                    imageType = (int)MessageBoxImage.Information;
                    break;
                default:
                    break;
            }

            // TODO: Choose MessageBoxButton and MessageBoxImage based on MessageType received
            MessageBox.Show(text, caption, MessageBoxButton.OK, (MessageBoxImage)imageType);
        }
    }
    public enum MessageType
    {
        Error,
        Warning,
        Information
    }
}
