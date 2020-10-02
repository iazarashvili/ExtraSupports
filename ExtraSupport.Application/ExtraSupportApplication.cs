using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Commands;
using EventFlow.Core;
using EventFlow.Queries;
using ExtraSupport.Application.ReadModels;
using ExtraSupport.Domain;
using ExtraSupport.Domain.Commands;
using ExtraSupport.Domain.Queries;

namespace ExtraSupport.Application
{
    public class ExtraSupportApplication
    {
        private readonly ICommandBus commandBus;
        private readonly IQueryProcessor queryProcessor;

        public ExtraSupportApplication(ICommandBus commandBus, IQueryProcessor queryProcessor)
        {
            this.commandBus = commandBus;
            this.queryProcessor = queryProcessor;
        }

        public async Task<List<TicketReadModel>> GetAllTickets()
        {
            return await queryProcessor.ProcessAsync(new AllTicketsQuery(), CancellationToken.None);
        }
        public async Task PublishAsync(ICommand command)
        {
            await command.PublishAsync(commandBus, CancellationToken.None);
        }

        public async Task CloseTicketAsync(TicketId id, string closeComment)
        {
            var command = new CloseTicket(id, closeComment);
            await commandBus.PublishAsync(command, CancellationToken.None);
        }


        public async Task DeleteTicketAsync(TicketId id)
        {
            var command = new DeleteTicket(id);
            await commandBus.PublishAsync(command, CancellationToken.None);
        }
    }
}
