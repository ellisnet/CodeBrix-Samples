using System;
using System.Collections.Generic;
using ContosoCookbook.Business;
using ContosoCookbook.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CodeBrix.Services;
using ContosoCookbook.Views;

namespace ContosoCookbook.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IRecipeService _recipeService;
        private readonly IPlatformInfoService _infoService;
        private readonly IUserDialogService _dialogService;

        public string AppTitle => $"Contoso Cookbook - v{_infoService.AppVersion}";

        #region SelectRecipe command implementation

        DelegateCommand<Recipe> _selectRecipeCommand;
        public DelegateCommand<Recipe> SelectRecipeCommand => _selectRecipeCommand ?? (_selectRecipeCommand = new DelegateCommand<Recipe>(DoSelectRecipe));

        private async void DoSelectRecipe(Recipe recipe)
        {
            var p = new NavigationParameters { { "recipe", recipe } };
            await _navigationService.NavigateAsync(nameof(RecipePage), p);
        }

        #endregion

        #region SelectRecipeGroup command implementation 

        private void DoSelectRecipeGroup(string groupId)
        {
            if (!String.IsNullOrWhiteSpace(groupId) 
                && groupId != _selectedRecipeGroup?.Id 
                && _recipeGroups.FirstOrDefault(f => f.Id == groupId) is RecipeGroup newGroup)
            {
                foreach (RecipeGroup group in _recipeGroups)
                {
                    group.IsSelected = (group.Id == newGroup.Id);
                }
                ResetRecipeGroups();
                SelectedRecipeGroup = newGroup;
            }
        }

        private RecipeGroup _selectedRecipeGroup;
        public RecipeGroup SelectedRecipeGroup
        {
            get => _selectedRecipeGroup;
            set
            {
                SetProperty(ref _selectedRecipeGroup, value);
                NotifyPropertyChanged(nameof(Recipes));
            }
        }

        private void ResetRecipeGroups()
        {
            //This "reset" operation shouldn't be necessary, but appears to be
            // needed to work around some quirks in the RepeaterView's handling
            // of updates to its ItemsSource
            List<RecipeGroup> groups = RecipeGroups.Select(s => s).ToList();
            foreach (RecipeGroup group in groups)
            {
                RecipeGroups.Remove(group);
            }
            foreach (RecipeGroup group in groups)
            {
                RecipeGroups.Add(group);
            }
        }

        #endregion

        private ObservableCollection<RecipeGroup> _recipeGroups;
        public ObservableCollection<RecipeGroup> RecipeGroups
        {
            get => _recipeGroups;
            set => SetProperty(ref _recipeGroups, value);
        }

        public List<Recipe> Recipes => _selectedRecipeGroup?.Recipes ?? new List<Recipe>();

        public MainPageViewModel(INavigationService navigationService, 
            IRecipeService recipeService, 
            IPlatformInfoService infoService, 
            IUserDialogService dialogService)
        {
            _navigationService = navigationService;
            _recipeService = recipeService;
            _infoService = infoService;
            _dialogService = dialogService;
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (RecipeGroups == null)
            {
                _recipeGroups = new ObservableCollection<RecipeGroup>(await _recipeService.GetRecipeGroups());
                foreach (RecipeGroup group in _recipeGroups)
                {
                    group.SelectRecipeGroupCommand = new DelegateCommand(() => DoSelectRecipeGroup(group.Id));
                }
                NotifyPropertyChanged(nameof(RecipeGroups));
                (SelectedRecipeGroup = RecipeGroups[0]).IsSelected = true;

                await Task.Delay(5000); //short delay to make sure the view has loaded, before showing the toast

                _dialogService.Toast("Contoso Cookbook adapted for Xamarin.Forms by Jeff Prosise, and for Prism by Brian Lagunas.",
                    TimeSpan.FromSeconds(3));
            }
        }
    }
}
