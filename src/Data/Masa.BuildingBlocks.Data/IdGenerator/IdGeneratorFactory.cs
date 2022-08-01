﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.BuildingBlocks.Data;

public class IdGeneratorFactory : IIdGeneratorFactory
{
    private IGuidGenerator? _guidGenerator;

    public IGuidGenerator GuidGenerator => _guidGenerator ??=
        _serviceProvider.GetService<IGuidGenerator>() ?? throw new Exception($"Unsupported {nameof(GuidGenerator)}");

    private ISequentialGuidGenerator? _sequentialGuidGenerator;

    public ISequentialGuidGenerator SequentialGuidGenerator => _sequentialGuidGenerator ??=
        _serviceProvider.GetService<ISequentialGuidGenerator>() ?? throw new Exception($"Unsupported {nameof(SequentialGuidGenerator)}");

    private ISnowflakeGenerator? _snowflakeGenerator;

    public ISnowflakeGenerator SnowflakeGenerator => _snowflakeGenerator ??=
        _serviceProvider.GetService<ISnowflakeGenerator>() ?? throw new Exception($"Unsupported {nameof(SnowflakeGenerator)}");

    private readonly IServiceProvider _serviceProvider;
    private readonly IOptions<IdGeneratorFactoryOptions> _idGeneratorFactoryOptions;
    private readonly IdGeneratorOptions? _defaultIdGeneratorOptions;

    public IdGeneratorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _idGeneratorFactoryOptions = serviceProvider.GetRequiredService<IOptions<IdGeneratorFactoryOptions>>();
        _defaultIdGeneratorOptions =
            _idGeneratorFactoryOptions.Value.IdGenerators.FirstOrDefault(generator => generator.Name == string.Empty) ??
            _idGeneratorFactoryOptions.Value.IdGenerators.FirstOrDefault();
    }

    public IIdGenerator<TOut> Create<TOut>() where TOut : notnull
    {
        var idGenerator = Create();
        return idGenerator as IIdGenerator<TOut> ?? throw new Exception($"Unsupported {nameof(IIdGenerator<TOut>)}");
    }

    public IIdGenerator<TOut> Create<TOut>(string name) where TOut : notnull
    {
        var idGenerator = Create(name);
        return idGenerator as IIdGenerator<TOut> ?? throw new Exception($"Unsupported {nameof(IIdGenerator<TOut>)}");
    }

    public IIdGenerator Create()
    {
        if (_defaultIdGeneratorOptions == null)
            throw new NotImplementedException("No default IdGenerator found, you may need service.AddSimpleGuidGenerator()");

        return _defaultIdGeneratorOptions.Func.Invoke(_serviceProvider);
    }

    public IIdGenerator Create(string name)
    {
        var idGeneratorOptions = _idGeneratorFactoryOptions.Value.IdGenerators.FirstOrDefault(generator => generator.Name == name);
        if (idGeneratorOptions == null)
            throw new NotImplementedException($"No IdGenerator found for name {name}");

        return idGeneratorOptions.Func.Invoke(_serviceProvider);
    }
}
