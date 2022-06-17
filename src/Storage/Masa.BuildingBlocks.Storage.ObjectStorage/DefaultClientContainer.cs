﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.BuildingBlocks.Storage.ObjectStorage;

public class DefaultClientContainer<TContainer>
    : DefaultClientContainer, IClientContainer<TContainer> where TContainer : class
{
    public DefaultClientContainer(IClient client, IBucketNameProvider<TContainer> bucketNameProvider)
        : base(client, bucketNameProvider)
    {
    }
}

public class DefaultClientContainer : IClientContainer
{
    private readonly IClient _client;
    private readonly IBucketNameProvider _bucketNameProvider;
    private string _bucketName => _bucketNameProvider.BucketName;

    public DefaultClientContainer(IClient client, IBucketNameProvider bucketNameProvider)
    {
        _client = client;
        _bucketNameProvider = bucketNameProvider;
    }

    public TemporaryCredentialsResponse GetSecurityToken() => _client.GetSecurityToken();

    public string GetToken() => _client.GetToken();

    public Task GetObjectAsync(string objectName, Action<Stream> callback, CancellationToken cancellationToken = default)
        => _client.GetObjectAsync(_bucketName, objectName, callback, cancellationToken);

    public Task GetObjectAsync(string objectName,
        long offset,
        long length,
        Action<Stream> callback,
        CancellationToken cancellationToken = default)
        => _client.GetObjectAsync(_bucketName, objectName, offset, length, callback, cancellationToken);

    public Task PutObjectAsync(string objectName, Stream data, CancellationToken cancellationToken = default)
        => _client.PutObjectAsync(_bucketName, objectName, data, cancellationToken);

    public Task<bool> ObjectExistsAsync(string objectName, CancellationToken cancellationToken = default)
        => _client.ObjectExistsAsync(_bucketName, objectName, cancellationToken);

    public Task DeleteObjectAsync(string objectName, CancellationToken cancellationToken = default)
        => _client.DeleteObjectAsync(_bucketName, objectName, cancellationToken);

    public Task DeleteObjectAsync(IEnumerable<string> objectNames, CancellationToken cancellationToken = default)
        => _client.DeleteObjectAsync(_bucketName, objectNames, cancellationToken);
}
