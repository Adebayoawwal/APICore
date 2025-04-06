

using APICore.Repos.Models;
using APICore.Modal;
using APICore.Helper;
using Refit;

namespace APICore.Service
{
    public interface IUserRoleServices
    {
        Task<APIResponse> AssignRolePermission(List<TblRolepermission> _data);
        Task<List<TblRole>> GetAllRoles();
        Task<List<TblMenu>> GetAllMenus();
        Task<List<Appmenu>> GetAllMenubyrole(string userrole);
        Task<Menupermission> GetMenupermissionbyrole(string userrole,string menucode);
        Task<IApiResponse> AssPermission(List<TblRolepermission> _data);
    }
}
