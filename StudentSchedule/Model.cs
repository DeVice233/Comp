using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Comp
{
    public class Model
    {
        ComputerManager computerManager = new ComputerManager();
        Computer selectedComputer;

        public event EventHandler ComputersChanged;
        public event EventHandler SelectedComputerChanged;

        public Computer SelectedComputer
        {
            get => selectedComputer;
            set { selectedComputer = value; SelectedComputerChanged?.Invoke(this, null); }
        }

        internal List<Computer> GetComputers()
        {
            return computerManager.Computers;
        }

        internal void Save()
        {
            computerManager.Save();
        }

        internal void CreateComputer()
        {
            SelectedComputer = computerManager.CreateComputer();
            PageManager.ChangePageTo(PageType.EditComputer);
            ComputersChanged?.Invoke(this, null);
        }

        internal void EditComputer()
        {
            PageManager.ChangePageTo(PageType.EditComputer);
        }

        internal void RemoveComputer()
        {
            computerManager.RemoveComputer(SelectedComputer);
            ComputersChanged?.Invoke(this, null);
        }

    }
}
