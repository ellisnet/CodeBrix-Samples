using CodeBrix;
using ContosoCookbook.Business;
using Prism.Navigation;

namespace ContosoCookbook.ViewModels
{
    public class RecipePageViewModel : ViewModelBase
    {
        private readonly ICodeBrixContainer _container;

        private Recipe _recipe;
        public Recipe Recipe
        {
            get => _recipe;
            set => SetProperty(ref _recipe, value);
        }

        public RecipePageViewModel(ICodeBrixContainer container)
        {
            _container = container;
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("recipe"))
            {
                Recipe = (Recipe)parameters["recipe"];
            }
        }
    }
}