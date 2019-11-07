using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerManagement.Logic.Model
{
    public class NameIndustryEventHandler : IRequestHandler<NameIndustryChangedEvent>
    {
        public Task<Unit> Handle(NameIndustryChangedEvent request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.Name);
            return Task.FromResult(Unit.Value);
        }
    }
}
