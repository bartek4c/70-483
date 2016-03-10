using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsExpressions.EventsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Button button = new Button();
            //ButtonHandler is invoked as a delegate method and added to the stack thanks to event keyword
            button.Click += ButtonHandler;
            //therefore ButtonHandler will be used as Click in OnClick method
            button.SimulateClick();

            button.Click -= ButtonHandler;
        }

        static public void ButtonHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked");
            Console.ReadLine();
        }
    }

    public class Button
    {
        public delegate void ClickHandler(object sended, EventArgs e);
        //there is an event on this class
        //it will handle adding new delegate methods and removing exisiting ones
        public event ClickHandler Click;

        protected void OnClick()
        {
            if (Click != null)
            {
                Click(this, EventArgs.Empty);
            }
        }

        public void SimulateClick()
        {
            OnClick();
        }
    }

    //IMPORTANT! Event handler that can be used for different event args
    //EventHandler<TEventArgs> Delegate
    //https://msdn.microsoft.com/en-us/library/db0etb8x%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396
}
