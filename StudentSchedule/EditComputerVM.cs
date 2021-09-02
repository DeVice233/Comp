using Mvvm1125;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp
{
    public class EditComputerVM : MvvmNotify, IPageVM
    {
        Model model;

        public Computer SelectedComputer { get => model.SelectedComputer; set => model.SelectedComputer = value; }
        public Computer SelectedComputerCopy { get; set; }

        public MvvmCommand BackToList { get; set; }
        public MvvmCommand SaveComputer { get; set; }

        public void SetModel(Model model)
        {
            this.model = model;
            BackToList = new MvvmCommand(() => PageManager.ChangePageTo(PageType.ComputerList), () => true);
           // SaveComputer = new MvvmCommand(() => model.SaveComputer(SelectedComputer), () => true);

            model.SelectedComputerChanged += Model_SelectedComputerChanged;
        }

        private void Model_SelectedComputerChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("SelectedComputer");
            NotifyPropertyChanged("SelectedComputerCopy");
        }
    }
}
