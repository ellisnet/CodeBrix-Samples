using System;
using System.Collections.Generic;
using CodeBrix;
using CodeBrix.Modularity;
using Prism.Modularity;
using UsingModules.SampleModule.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace UsingModules.SampleModule
{
    public class SampleModule : CodeBrixModuleBase
    {
        //Although this isn't required, it is a good idea to have a static ModuleName property on the 
        // module class so that any code can refer to this module by its correct name, without having
        // to create an instance of anything to get the correct name; especially in cases where the 
        // module name is something other than the typeof(ModuleClass).Name.
        public static string ModuleName => typeof(SampleModule).Name;

        public override void OnInitialized()
        {
            //Overriding the OnInitialized() method is optional - if you want to do special module
            // initialization logic, put that here.
            // This method will be called immediatly after RegisterTypes() and will be called on the
            // first LoadModule() request for "OnDemand" InitializationMode; or at application startup
            // for "WhenAvailable" InitializationMode.
        }

        public override void RegisterTypes(ICodeBrixContainer container)
        {
            //Perform any type or page or service registration required by the module here
            container.RegisterForNavigation<SamplePage>();            
        }
    }

    public class SampleModuleInfo : ICodeBrixModuleInfo<SampleModule>
    {
        //There are no special settings for this module; so setting its Settings dictionary to null
        public Dictionary<string, object> Settings { get; set; } = null;
        //We will default to on-demand for this module, but this can be set when the module is registered
        public InitializationMode InitializationMode { get; set; } = InitializationMode.OnDemand;
        public string ModuleName => SampleModule.ModuleName;
        public Type ModuleType => typeof(SampleModule);
        public ModuleInfo ModuleInfo => CodeBrixModuleBase.GetModuleInfo(this);
    }
}
