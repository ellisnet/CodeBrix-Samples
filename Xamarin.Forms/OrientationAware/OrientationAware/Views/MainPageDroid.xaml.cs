using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBrix.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrientationAware.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageDroid : OrientationAwareContentPage
	{
		public MainPageDroid ()
		{
			InitializeComponent ();
		}
	}
}