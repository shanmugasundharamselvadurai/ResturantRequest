using System;
using Xamarin.Forms;

namespace Source.Presentation.CustomRenders
{
    public class EntryTrigger:TriggerAction<Entry>
    {
        public EntryTrigger()
        {
        }
        protected override void Invoke(Entry sender)
        {
            if(sender.Text.Equals(""))
            {
                sender.BackgroundColor = Color.Transparent;
            }
            else
            {
                sender.BackgroundColor = Color.Red;
            }
        }
    }
}
