using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract.Models;

namespace DataAccess.Demo
{
    public interface ISPADataAccess : IDisposable
    {
        SPADataContext DataContext { get; set; }
        Task<List<Alert>> GetAlertsAsync();
    }
}
