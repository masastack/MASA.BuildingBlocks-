// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.BuildingBlocks.BasicAbility.Auth.Service;

public interface IUserService
{
    Task<List<StaffModel>> GetListByTeamAsync(Guid teamId);

    Task<List<StaffModel>> GetListByRoleAsync(Guid roleId);

    Task<List<StaffModel>> GetListByDepartmentAsync(Guid departmentId);

    Task<UserModel?> AddAsync(AddUserModel user);

    Task<bool> ValidateCredentialsByAccountAsync(string account, string password);

    Task<UserModel> FindByAccountAsync(string account);

    Task<UserModel> GetCurrentUserAsync();

    Task VisitedAsync(string url);

    Task<List<UserVisitedModel>> GetUserVisitedListAsync();

    Task UpdateUserPasswordAsync(UpdateUserPasswordModel user);

    Task UpdateUserBaseInfoAsync(UpdateUserBaseInfoModel user);
}

