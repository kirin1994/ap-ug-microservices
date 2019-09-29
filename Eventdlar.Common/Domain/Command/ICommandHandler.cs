using System.Threading.Tasks;
namespace Eventdlar.Common.Domain.Command
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}