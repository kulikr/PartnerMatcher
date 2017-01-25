using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PartnerMatcher.myController;
using PartnerMatcher.myModel;

namespace PartnerMatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// On startup function that opens when the project starts
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            IController controller = new Controller();
            IModel model = new Model(controller);
            MainWindow view = new MainWindow(ref controller);
            controller.setModel(model);
            controller.setView(view);
            view.Show();
        }
    }

}
