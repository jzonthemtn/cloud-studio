using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudStudio.SharedLibrary.Domain;

namespace CloudStudio.DataAccess.Repositories {

    public interface IInstanceSSHConnectionRepository {

        InstanceSSHConnection GetByInstanceId(string instanceId, Guid cloudAccountId);

    }

}