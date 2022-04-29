// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.BuildingBlocks.ReadWriteSpliting.Cqrs.Queries;

public interface IQuery<TResult> : IEvent<TResult>
    where TResult : notnull
{
}
