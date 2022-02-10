using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCADCodeChallange.Model;

namespace WSCADCodeChallange.DataService
{
    public class FileDataService : IFileDataService
    {
        public void CreateFile()
        {
            File.Create(DataFile.Path + DataFile.Name);
        }

        public async Task<List<Object>> GetShape()
        {
            List<Object> shape = new List<Object>();

            await Task.Run(() =>
            {
                string filePath = GetFilePath();
                if (string.IsNullOrEmpty(filePath))
                {
                    CreateFile();
                }
                else
                {
                    using (StreamReader textReader = new StreamReader(filePath))
                    {
                        using (var reader = new JsonTextReader(textReader))
                        {
                            while (reader.Read())
                            {
                                if (reader.TokenType == JsonToken.StartObject)
                                {
                                    var obj = JObject.Load(reader);
                                    shape.Add(obj);
                                }
                            }
                        }
                    }
                }
            });

            return shape;
        }

        public string GetFilePath()
        {
            DirectoryInfo topDir = Directory.GetParent(System.Environment.CurrentDirectory);
            string pathto = topDir.Parent.Parent.FullName;
            return pathto + DataFile.Path + DataFile.Name;
        }
    }
}
