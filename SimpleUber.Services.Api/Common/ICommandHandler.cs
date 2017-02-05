namespace SimpleUber.Services.Api.Common
{
    public interface ICommandHandler<TIn, TOut>
    {
        TOut Execute(TIn command);
    }

    public interface ICommandHandler<TIn>
    {
        void Execute(TIn command);
    }
}
