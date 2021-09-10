﻿namespace MASA.BuildingBlocks.Dispatcher.InMemory;
public interface IEvent
{
    Guid Id { get; }

    DateTime CreationTime { get; }
}

public interface IEvent<TResult> : IEvent
{
    TResult Result { get; set; }
}
