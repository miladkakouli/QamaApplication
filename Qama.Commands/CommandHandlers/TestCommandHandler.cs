using System;
using System.Threading.Tasks;
using Qama.Commands.Commands;
using Qama.Events.Events;
using Qama.Framework.Core.Abstractions.Commands;
using Qama.Framework.Core.Abstractions.Events;
using Qama.Framework.Core.Abstractions.Logging;
using Qama.Framework.Core.Abstractions.Persistence;
using Qama.Framework.Core.Abstractions.ServiceLocator;
using Qama.Framework.Core.EventBus.RabbitMQ;
using Qama.Persistence.Entities;

namespace Qama.Commands.CommandHandlers
{
    class TestCommandHandler : ICommandHandler<TestCommand>
    {
        private readonly IEverythingLogger _logger;
        private readonly IRepository<TestEntity, Guid> _repository;
        private readonly IServiceLocator _serviceLocator;
        public TestCommandHandler(IEverythingLogger logger, IRepository<TestEntity, Guid> repository
            , IServiceLocator serviceLocator)
        {
            _logger = logger;
            _repository = repository;
            _serviceLocator = serviceLocator;
        }
        public Task Handle(TestCommand command)
        {
            _logger.LogInformation("This is How to Write Log Everywhere");
            var entity = new TestEntity(command.Ssn);
            _repository.Add(entity);
            return Task.CompletedTask;
        }

    }
}
