using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadi_Homework
{
    public interface IDatabaseManager
    {
        public bool CheckFile();
        public void AddData(User data);
        public void UpdateData(List<User> users);
        public void SetupFile(string path);
        public List<User> ReadFile();
        public void WriteFile(string json, string path);
    }
}
