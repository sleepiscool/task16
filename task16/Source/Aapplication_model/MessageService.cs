using System.Windows.Forms;
using Model;

namespace Aapplication_model
{
    public class MessageService : IMessageService
    {
         public void ThrowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }

    public interface IMessageService
    {
    }
}
