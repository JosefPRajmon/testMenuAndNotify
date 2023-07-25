using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace NotificationSenderApi
{
    public class MyDbContext
    {

        private static readonly MyDbContext instance = new MyDbContext();
        Dictionary<string,List<string>> _databases;
        static MyDbContext()
        {


            
        }        private MyDbContext()
        {

            _databases = new Dictionary<string,List<string>>();
            Load();

            
        }
        public static MyDbContext Instance
        {
            get
            {
                return instance;
            }
        }
        public void Saver()
        {
            var keys = _databases.Keys;
            foreach (var key in keys)
            {
                using (StreamWriter sw = new StreamWriter($@"{key}.txt"))
                {
                    foreach (var item in _databases[key])
                    {
                        sw.WriteLine(item);
                    }
                    sw.Flush();
                }
            }
            

                using (StreamWriter sw = new StreamWriter(@"keys.txt"))
                {foreach (var item in keys)
            {
                    
                        sw.WriteLine(item);
                    }
                    sw.Flush();
                
            }
        }
        public void Saver(string key)
        {
                using (StreamWriter sw = new StreamWriter($@"{key}.txt"))
                {
                    foreach (var item in _databases[key])
                    {
                        sw.WriteLine(item);
                    }
                    sw.Flush();
                }
            

        }
        public void IsseterArray()
        {
            if (_databases.Count<1)
            {
                Load();
            }
        }
        public List<string> Users(string key)
        {
            try
            {
                if (_databases.ContainsKey(key))
                {
                    return _databases[key];
                }
                else
                {
                    if(File.Exists($"{key}.txt"))
                    {
                        Load(key);
                        return _databases[key];
                    }
                    else
                    {
                        return new List<string>();
                    }
                }
            }
            catch (Exception)
            {
                return new List<string>() { "aplikace se nenasla"};
            }
        }
        public void Load(string key)
        {
            if (File.Exists($"{key}.txt"))
            {

            _databases[key] = new List<string>();
            using (StreamReader sr = new StreamReader($@"{key}.txt"))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    _databases[key].Add(s);
                }
            }
            }
        }        public void Load()
        {
            if (File.Exists(@"keys.txt"))
            {
                List<string> list = new List<string>();
                using (StreamReader sr = new StreamReader(@"keys.txt"))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        list.Add(s);
                    }
                }
                foreach (var key in list)
                {
                    using (StreamReader sr = new StreamReader($@"{key}.txt"))
                    {
                        string s;
                        while ((s = sr.ReadLine()) != null)
                        {
                            _databases[key].Add(s);
                        }
                    }
                }
            }
        }

        public void AddUser(string key, string value)
        {
            if (_databases.ContainsKey(key))
            {
                if (!_databases[key].Contains(value))
                {
                    _databases[key].Add(value);
                }
            }
            else
            {
                _databases.Add(key, new List<string>() { value });
            }
            Saver();
        }
    }

}
