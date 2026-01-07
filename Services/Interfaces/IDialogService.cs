using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Services.Interfaces
{
    public interface IDialogService
    {
        Task<string> ShowInputDialogAsync(string title, string prompt, string defaultValue = "");
        void ShowMessage(string message, string title = "Informacja");
        void ShowError(string message, string title = "Błąd");
        bool ShowConfirmation(string message, string title = "Potwierdzenie");
    }
}
