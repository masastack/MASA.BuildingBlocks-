namespace Masa.BuildingBlocks.BasicAbility.Pm.Service
{
    public interface IAppService
    {
        Task<List<AppDetailModel>> GetListAsync();

        Task<List<AppDetailModel>> GetListByProjectIdsAsync(List<int> projectIds);

        Task<AppDetailModel> GetWithEnvironmentClusterAsync(int Id);

        Task<AppDetailModel> GetAsync(int Id);
    }
}
