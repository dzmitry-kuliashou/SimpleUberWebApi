namespace SimpleUber.Services.Api.Common
{
    public interface IQueryHandler<TIn, TOut>
    {
        TOut Execute(TIn query);
    }

    public interface IQueryHandler<TOut>
    {
        TOut Execute();
    }
}
