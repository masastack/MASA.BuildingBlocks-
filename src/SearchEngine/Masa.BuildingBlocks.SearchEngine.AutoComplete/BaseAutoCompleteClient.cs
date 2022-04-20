﻿namespace Masa.BuildingBlocks.SearchEngine.AutoComplete;
public abstract class BaseAutoCompleteClient : IAutoCompleteClient
{
    public virtual Task<GetResponse<AutoCompleteDocument<Guid>, Guid>> GetAsync(string keyword, AutoCompleteOptions? options = null,
        CancellationToken cancellationToken = default)
        => GetAsync<Guid>(keyword, options, cancellationToken);

    public virtual Task<GetResponse<AutoCompleteDocument<TValue>, TValue>> GetAsync<TValue>(string keyword,
        AutoCompleteOptions? options = null,
        CancellationToken cancellationToken = default) where TValue : notnull
        => GetAsync<AutoCompleteDocument<TValue>, TValue>(keyword, options, cancellationToken);

    public abstract Task<GetResponse<TAudoCompleteDocument, TValue>> GetAsync<TAudoCompleteDocument, TValue>(string keyword,
        AutoCompleteOptions? options = null,
        CancellationToken cancellationToken = default) where TAudoCompleteDocument : AutoCompleteDocument<TValue> where TValue : notnull;

    public virtual Task<SetResponse> SetAsync(AutoCompleteDocument<Guid> document, SetOptions? options = null,
        CancellationToken cancellationToken = default)
        => SetAsync<AutoCompleteDocument<Guid>, Guid>(document, options, cancellationToken);

    public virtual Task<SetResponse> SetAsync(IEnumerable<AutoCompleteDocument<Guid>> documents, SetOptions? options = null,
        CancellationToken cancellationToken = default)
        => SetAsync<AutoCompleteDocument<Guid>, Guid>(documents, options, cancellationToken);

    public virtual Task<SetResponse> SetAsync<TValue>(AutoCompleteDocument<TValue> document, SetOptions? options = null,
        CancellationToken cancellationToken = default) where TValue : notnull
        => SetAsync<AutoCompleteDocument<TValue>, TValue>(document, options, cancellationToken);

    public virtual Task<SetResponse> SetAsync<TValue>(IEnumerable<AutoCompleteDocument<TValue>> documents, SetOptions? options = null,
        CancellationToken cancellationToken = default) where TValue : notnull
        => SetAsync<AutoCompleteDocument<TValue>, TValue>(documents, options, cancellationToken);

    public virtual Task<SetResponse> SetAsync<TAudoCompleteDocument, TValue>(TAudoCompleteDocument document, SetOptions? options = null,
        CancellationToken cancellationToken = default) where TAudoCompleteDocument : AutoCompleteDocument<TValue> where TValue : notnull
        => SetAsync<TAudoCompleteDocument, TValue>(new List<TAudoCompleteDocument> { document }, options, cancellationToken);

    public abstract Task<SetResponse> SetAsync<TAudoCompleteDocument, TValue>(IEnumerable<TAudoCompleteDocument> documents,
        SetOptions? options = null,
        CancellationToken cancellationToken = default) where TAudoCompleteDocument : AutoCompleteDocument<TValue> where TValue : notnull;

    public abstract Task<DeleteResponse> DeleteAsync(string id, CancellationToken cancellationToken = default);

    public virtual Task<DeleteResponse> DeleteAsync<T>(T id, CancellationToken cancellationToken = default) where T : IComparable
        => DeleteAsync(id!.ToString() ?? throw new ArgumentNullException($"{id} is not null", nameof(id)), cancellationToken);

    public abstract Task<DeleteMultiResponse> DeleteAsync(IEnumerable<string> ids, CancellationToken cancellationToken = default);

    public virtual Task<DeleteMultiResponse> DeleteAsync<T>(IEnumerable<T> ids, CancellationToken cancellationToken = default) where T : IComparable
    {
        var type = typeof(T);
        if (!type.IsPrimitive && type != typeof(Guid) && type != typeof(string))
            throw new NotSupportedException("Unsupported types, id only supports simple types or guid, string");

        return DeleteAsync(ids.Select(id => id.ToString() ?? throw new ArgumentNullException($"{id} is not null", nameof(id))), cancellationToken);
    }
}
