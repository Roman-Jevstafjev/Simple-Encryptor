using Jevstafjev.Encryptor.Contracts;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace Jevstafjev.Encryptor.Wpf.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly IEnumerable<ICipher> _ciphers;

        public ShellViewModel(IEnumerable<ICipher> ciphers)
        {
            _ciphers = ciphers;
            EncryptCommand = new DelegateCommand(EncryptCommandExecute);
            DecryptCommand = new DelegateCommand(DecryptCommandExecute);
        }

        public DelegateCommand EncryptCommand { get; set; }

        private void EncryptCommandExecute()
        {
            if (SelectedCipherName is null)
            {
                MessageBox.Show("Select a cipher method.");
                return;
            }

            var cipher = _ciphers.First(x => x.Name == SelectedCipherName);
            var result = cipher.Encrypt(Input);
            if (result is null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            Result = result;
        }

        public DelegateCommand DecryptCommand { get; set; }

        private void DecryptCommandExecute()
        {
            if (SelectedCipherName is null)
            {
                MessageBox.Show("Select a cipher method.");
                return;
            }

            var cipher = _ciphers.First(x => x.Name == SelectedCipherName);
            var result = cipher.Decrypt(Input);
            if (result is null)
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            Result = result;
        }

        public string? SelectedCipherName { get; set; }

        public List<string> CipherNames
        {
            get
            {
                return _ciphers.Select(x => x.Name).ToList();
            }
        }

        public string Input { get; set; } = string.Empty;

        private string _result = string.Empty;
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                SetProperty(ref _result, value);
            }
        }
    }
}
