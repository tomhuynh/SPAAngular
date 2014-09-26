using System.Data.Entity;
using Contract.Models;

namespace DataAccess.Demo
{
    public class SPADataContext : DbContext
    {
        public SPADataContext(string demoConnectionString): base(demoConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new NullDatabaseInitializer<SPADataContext>());
        }

        public virtual IDbSet<Alert> Alerts { get; set; }

    }
}
