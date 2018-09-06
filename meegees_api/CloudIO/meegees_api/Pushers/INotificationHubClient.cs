using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meegees_api.Pushers
{
    public interface INotificationHubClient
    {
        void NotifyUser(string payload);
    }
}
