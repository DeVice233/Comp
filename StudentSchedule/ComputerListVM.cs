using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Mvvm1125;

namespace Comp
{
    public class ComputerListVM : MvvmNotify, IPageVM
    {
        Model model;
        public ObservableCollection<Computer> Computers { get; set; }
        public Computer SelectedComputer { get => model.SelectedComputer; set => model.SelectedComputer = value; }

        public MvvmCommand CreateComputer { get; set; }
        public MvvmCommand EditComputer { get; set; }
        public MvvmCommand RemoveComputer { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            Computers = new ObservableCollection<Computer>(model.GetComputers());

            CreateComputer = new MvvmCommand(() => model.CreateComputer(), () => true);
            EditComputer = new MvvmCommand(() => model.EditComputer(), () => SelectedComputer != null);
            RemoveComputer = new MvvmCommand(() => model.RemoveComputer(), () => SelectedComputer != null);

            model.ComputersChanged += Model_ComputersChanged;
            PageManager.CurrentPageChanged += PageManager_CurrentPageChanged;
        }

        private void PageManager_CurrentPageChanged(object sender, PageType e)
        {
            Computers = new ObservableCollection<Computer>(model.GetComputers());
            NotifyPropertyChanged("Computers");
        }

        private void Model_ComputersChanged(object sender, EventArgs e)
        {
            Computers = new ObservableCollection<Computer>(model.GetComputers());
            NotifyPropertyChanged("Computers");
        }
    }
}
