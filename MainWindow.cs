using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace GMitM
{
    class MainWindow : Window
    {
        [UI] Box BoxList;

        [UI] Viewport Vie;
        [UI] Button but1;
        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            
            for (int i = 0; i< 20; i++)
            {
                Box box = new(Orientation.Horizontal, 3);

                Label index = new ($"{i}");
                index.WidthRequest = 50;

                Label time = new ("2 : 30");
                time.WidthRequest = 80;

                box.PackStart(index, false, true, 0);
                box.PackStart(new Label($"What Could Have Been feat"), true, true, 0);
                box.PackStart(time, false, true, 0);
                
                BoxList.PackStart(new Button(box), true, true, 0);
            }

            ShowAll();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }
    }
}
