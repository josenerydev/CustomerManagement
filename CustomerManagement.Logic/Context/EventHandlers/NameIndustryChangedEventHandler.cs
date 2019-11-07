using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Logic.Model
{
    public class NameIndustryChangedEventHandler : INotificationHandler<NameIndustryChangedEvent>
    {
        public Task Handle(NameIndustryChangedEvent notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine(notification.Name);
            return Task.CompletedTask;
        }
    }
}
