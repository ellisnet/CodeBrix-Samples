using Newtonsoft.Json;
using System.Collections.Generic;
using Prism.Commands;

namespace ContosoCookbook.Business
{
    public class RecipeGroup
    {
        [JsonProperty("UniqueId")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string FlagPath { get; set; }
        public string ImagePath { get; set; }
        public string GroupImagePath { get; set; }
        public string Description { get; set; }
        [JsonProperty("Items")]
        public List<Recipe> Recipes { get; set; }

        //A couple of necessary ViewModel-ish properties
        [JsonIgnore]
        public bool IsSelected { get; set; }
        [JsonIgnore]
        public DelegateCommand SelectRecipeGroupCommand { get; set; }
    }
}
