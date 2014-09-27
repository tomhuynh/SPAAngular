﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract.Facades;
using DataAccess.SPA;

namespace Business.Facade.Alert
{
    public class AlertFacade : IAlertFacade, IDisposable
    {
        private readonly ISPADataAccess _demoDataAccess;

        public AlertFacade()
        {
            _demoDataAccess = new SPADataAccess();
        }


        public async Task<List<Contract.Models.Alert>> GetAlertsAsync()
        {
            return (await _demoDataAccess.GetAlertsAsync()).ToList();

        }




        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                var demoDataAccess = this._demoDataAccess as IDisposable;

                if (demoDataAccess != null)
                {
                    demoDataAccess.Dispose();
                }
            }
        }

        #endregion
    }
}
