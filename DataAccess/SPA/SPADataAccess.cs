using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Threading.Tasks;
using Contract.Models;
using System.Configuration;

namespace DataAccess.Demo
{
    public class SPADataAccess: ISPADataAccess
    {
        public SPADataContext DataContext { get; set; }

        private string _spaConnectionString;
        private volatile Type _dependency;

        public SPADataAccess(SPADataContext context)
        {
            DataContext = context;
        }

        public SPADataAccess()
        {
            //Fix EF bugs which regards to message: "No Entity Framework provider found for the ADO.NET provider with invariant name 'System.Data.SqlClient'. Make sure the provider is registered in the 'entityFramework' section of the application config file. See http://go.microsoft.com/fwlink/?LinkId=260882 for more information."
            _dependency = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            _spaConnectionString = "Data Source=OMANEL705\\TOM;Initial Catalog=SPA;Integrated Security=True";
            DataContext = new SPADataContext(_spaConnectionString);
        }

        public async Task<List<Alert>> GetAlertsAsync()
        {
            try
            {
                var ret = await DataContext.Alerts.ToListAsync();
                return ret;
            }
            catch (Exception e)
            {
                var err = e.Message;
            }

            return null;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.DataContext != null)
            {
                DataContext.Dispose();
            }
        }
        #endregion

    }
}
