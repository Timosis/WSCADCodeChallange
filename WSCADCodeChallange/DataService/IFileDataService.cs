using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCADCodeChallange.DataService
{
    /// <summary>
    /// Getting data from file or database. It can be also use another data storage.
    /// </summary>
    public interface IFileDataService
    {
        string GetFilePath();
        void CreateFile();
        Task<List<Object>> GetShape();
    }
}
