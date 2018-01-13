using ContosoCookbook.Business;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

using CodeBrix.Helpers;

namespace ContosoCookbook.Services
{
    public class RecipeService : IRecipeService
    {
        public async Task<IList<RecipeGroup>> GetRecipeGroups()
        {
            var obj = new { Groups = new List<RecipeGroup>() };
            var result = JsonConvert.DeserializeAnonymousType(await AppResourceHelper.GetEmbeddedResourceAsStringAsync("Data/RecipeData.json"), obj);
            return result.Groups;
        }
    }
}
