using System;
using CRUDWithWinForms._Repositories;
using CRUDWithWinForms.Models;
using CRUDWithWinForms.Views;

namespace CRUDWithWinForms.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowItemView += ShowItemView;
        }

        private void ShowItemView(object sender, EventArgs e)
        {
            IItemView view = ItemView.GetInstace((MainView)mainView);
            IItemRepository repository = new ItemRepository(sqlConnectionString);
            new ItemPresenter(view, repository);
        }
    }
}
