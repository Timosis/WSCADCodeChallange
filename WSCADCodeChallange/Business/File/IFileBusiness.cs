using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCADCodeChallange.Business.File
{
    /// <summary>
    /// Interface for getting shapes from file.
    /// According to the separation of concern approach this file class is separated from filedataservice,
    /// because when we get data from database or another data storage we may want to change or update data which comes from that source
    /// but we still want to keep the orginal data.    
    /// </summary>
    public interface IFileBusiness
    {
        Task<List<Object>> GetShapeFromFile();
    }
}
