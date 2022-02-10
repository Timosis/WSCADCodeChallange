using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSCADCodeChallange.DataService;

namespace WSCADCodeChallange.Business.File
{
    /// <summary>
    /// Concrete class of IFileBusiness
    /// </summary>
    public class FileBusiness : IFileBusiness
    {
        IFileDataService dataService;

        public FileBusiness(IFileDataService dataService)
        {
            this.dataService = dataService;
        }

        public Task<List<Object>> GetShapeFromFile()
        {
            return dataService.GetShape();
        }
    }
}
