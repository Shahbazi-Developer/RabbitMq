using System.Threading.Tasks;
using Zamin.Extensions.DependencyInjection.Abstractions;

namespace Book.Core.Contracts.Books.Commands
{
    public interface IRabbitMqProducer : ISingletoneLifetime
    {
        Task SendMessageAsync<T>(T message);
    }
}
