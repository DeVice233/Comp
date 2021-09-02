using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Comp
{
    public class ComputerManager
    {
        public List<Computer> Computers { get; set; } = new List<Computer>();

        public ComputerManager()
        {
            Computers.Add(new Computer { Ip = 32});
            Computers.Add(new Computer { DomenName = "324"});
            Load();
        }

        internal void SaveComputer(Computer orig, Computer copy)
        {
            int index = Computers.IndexOf(orig);
            Computers[index] = copy;
            Save();
        }

        internal Computer CreateComputer()
        {
            Computer newComputer = new Computer();
            Computers.Add(newComputer);
            return newComputer;
        }

        internal void RemoveComputer(Computer Computer)
        {
            Computers.Remove(Computer);
            Save();
        }

        public void Save()
        {
            var json = JsonSerializer.Serialize(Computers, typeof(List<Computer>));
            File.WriteAllText("comps.db", json);
        }

        public void Load()
        {
            string file = "comps.db";
            if (!File.Exists(file) || new FileInfo(file).Length == 0)
            {
                Computers = new List<Computer>();
                return;
            }
            string json = File.ReadAllText(file);
            Computers = (List<Computer>)JsonSerializer.Deserialize(json, typeof(List<Computer>));
        }
    }
}
