using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shadi_Homework
{
    public class DataBase : IDatabaseManager
    {
        private static string path = "C:\\Users\\moham\\Desktop\\Json_ttask.json";
        public bool CheckFile()
        {
            bool fileExists = File.Exists(path);

            if (!fileExists)
            {
                File.AppendAllText(path, null);
                SetupFile(path);
            }

            return (fileExists);
        }

        public void AddData(User data)
        {
            List<User> myUsers = ReadFile();

            data.Id = myUsers.Count + 1;
            myUsers.Add(data);
            string allUsers = JsonConvert.SerializeObject(myUsers);
            WriteFile(allUsers, path);

        }

        public void UpdateData(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users);
            WriteFile(json, path);
        }

        public void SetupFile(string path)
        {
            List<User> Users = new();
            string UsersJson = JsonConvert.SerializeObject(Users);
            WriteFile(UsersJson, path);
        }

        public List<User> ReadFile()
        {
            var content = File.ReadAllText(path);
            List<User> Users = JsonConvert.DeserializeObject<List<User>>(content);
            return Users;
        }

        public void WriteFile(string json, string path)
        {
            File.WriteAllText(path, json);
        }
    }
}
