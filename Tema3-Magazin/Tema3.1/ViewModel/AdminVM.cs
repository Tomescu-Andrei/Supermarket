﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3._1.Helpers;
using Tema3._1.View.Admin;

namespace Tema3._1.ViewModel
{
    public class AdminVM
    {
        private ICommand openWindowCommand;
        public ICommand OpenWindowCommand
        {
            get
            {
                if (openWindowCommand == null)
                {
                    openWindowCommand = new RelayCommand(OpenWindow);
                }
                return openWindowCommand;
            }
        }
        public void OpenWindow(object obj)
        {
            string nr = obj as string;
            switch (nr)
            {
             
                case "2":
                    CategoriesView categoriesView = new CategoriesView();
                    categoriesView.ShowDialog();
                    break;
                case "3":
                   ProducerView producersView = new ProducerView();
                   producersView.ShowDialog();
                   break;
                case "4":
                    ProductView productView = new ProductView();
                    productView.ShowDialog();
                    break;
                case "5":
                    StockView producerProductsView = new StockView();
                    producerProductsView.ShowDialog();
                    break;
                case "6":
                    UserView stocksView = new UserView();
                    stocksView.ShowDialog();
                    break;
                case "7":
                    ProducerStatsView productsView = new ProducerStatsView();
                    productsView.ShowDialog();
                    break;
                case "8":
                    AllCategoriesView categoryStatsView = new AllCategoriesView();
                    categoryStatsView.ShowDialog();
                    break;
                case "9":
                     SalesStats sales = new SalesStats();
                    sales.ShowDialog();
                    break;
              
                default:
                    break;
            }
        }


    }
}
