// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

using Masa.BuildingBlocks.Oidc.Models.Models;

namespace Masa.BuildingBlocks.Oidc.Storage.Stores
{
    public interface IClientStore
    {
        /// <summary>
        /// Finds a client by id
        /// </summary>
        /// <param name="clientId">The client id</param>
        /// <returns>The client</returns>
        Task<ClientModel?> FindClientByIdAsync(string clientId);
    }
}
