namespace Arch.CrossCutting.CqrsContracts
{
    public interface IProcessor
    {
         void Send<TCommand>(TCommand command) where TCommand: ICommand;
         TResult Get<TResult>(IQuery<TResult> query);
    }
}