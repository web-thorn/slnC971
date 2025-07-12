using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WGU.Models;
using WGU.Services;
using Xamarin.Forms;

namespace WGU.ViewModels
{
    public class TermsViewModel : BaseViewModel
    {
        private Term _selectedTerm;

        public ITermDataStore<Term> TermDataStore => DependencyService.Get<ITermDataStore<Term>>();

        public ObservableCollection<Term> Terms { get; }
        public Command LoadTermsCommand { get; }
        public Command AddTermsCommand { get; }
        public Command<Term> TermTapped { get; }
        public TermsViewModel()
        {
            Title = "Terms";
            Terms = new();
            LoadTermsCommand = new Command(async () => await ExecuteLoadTermsCommand());
        }

        private async Task ExecuteLoadTermsCommand()
        {
            IsBusy = true;

            try
            {
                Terms.Clear();
                var terms = await TermDataStore.GetItemsAsync(true);
                foreach (var term in terms)
                {
                    Terms.Add(term);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            _selectedTerm = null;
        }
    }
}
