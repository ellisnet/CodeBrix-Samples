using System;
using Android.Content;
using Android.OS;
using Android.Speech.Tts;
using CodeBrix;
using UsingDependencyService.Droid.Services;
using UsingDependencyService.Services;
using Xamarin.Forms;
using Debug = System.Diagnostics.Debug;
using Object = Java.Lang.Object;

[assembly: Dependency(typeof(TextToSpeech_Android))]

namespace UsingDependencyService.Droid.Services
{
    public class TextToSpeech_Android : Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech _speaker;
        private string _toSpeak;
        private string _uniqueUtteranceId = Guid.NewGuid().ToString();

        public void Speak(string text)
        {
            _toSpeak = text;
            if (_speaker == null)
            {
                //The first time that Speak() is called, the TextToSpeech instance will be created 
                // and initialized; and  then the _speaker.Speak() line in the OnInit() method will 
                // be called to actually do the speaking.

                Context ctx = ((Application.Current as CodeBrixApplication)?
                                  .PlatformConfiguration as AndroidPlatformConfigBase)?
                              .MainActivityContext
                              ?? throw new InvalidOperationException("Could not retrieve a valid Context.");

                Debug.WriteLine("creating speaker");
                _speaker = new TextToSpeech(ctx, this);  //After initialization this.OnInit() will be called.
            }
            else
            {
                //Subsequent times that Speak() is called, the _speaker will already be created and 
                // initialized, so this code will be executed.
                
                _uniqueUtteranceId = Guid.NewGuid().ToString();
                _speaker.Speak(_toSpeak, QueueMode.Flush, Bundle.Empty, _uniqueUtteranceId);
                Debug.WriteLine("spoke " + _toSpeak);
            }
        }

        #region IOnInitListener implementation

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("speaker init");
                _speaker.Speak(_toSpeak, QueueMode.Flush, Bundle.Empty, _uniqueUtteranceId);
            }
            else
            {
                Debug.WriteLine("was quiet");
            }
        }

        #endregion
    }
}