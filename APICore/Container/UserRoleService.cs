using APICore.Helper;
using APICore.Modal;
using APICore.Repos.Data;
using APICore.Repos.Models;
using APICore.Service;
using Microsoft.EntityFrameworkCore;
using Octokit.Internal;
using Refit;

namespace APICore.Container
{
    public class UserRoleService : IUserRoleServices
    {
        private readonly ApplicationDbcontext context;
        public UserRoleService(ApplicationDbcontext learndata) {
            this.context = learndata;
        }
        public async Task<IApiResponse> AssignRolePermission(List<TblRolepermission> _data)
        {
            APIResponse response = new APIResponse();
            int processcount = 0;
            try
            {
                using(var dbtransaction=await this.context.Database.BeginTransactionAsync())
                {
                    if (_data.Count > 0)
                    {
                        _data.ForEach(item =>
                        {
                            var userdata = this.context.tblRolepermissions.FirstOrDefault(item1 => item1.Userrole == item.Userrole &&
                            item1.Menucode == item.Menucode);
                            if(userdata != null )
                            {
                                userdata.Haveview = item.Haveview;
                                userdata.Haveadd = item.Haveadd;
                                userdata.Havedelete= item.Havedelete;
                                userdata.Haveedit= item.Haveedit;
                                processcount++;
                            }
                            else
                            {
                                this.context.tblRolepermissions.Add(item);
                                processcount++;

                            }

                        });

                        if (_data.Count == processcount)
                        {
                            await this.context.SaveChangesAsync();
                            await dbtransaction.CommitAsync();
                            response.Result = "pass";
                            response.Message = "Saved successfully.";
                        }
                        else
                        {
                            await dbtransaction.RollbackAsync();
                        }

                    }
                    else
                    {
                        response.Result = "fail";
                        response.Message = "Failed";
                    }
                }
                
            }
            catch(Exception ex)
            {
                response = new APIResponse();
            }
            
            return (IApiResponse)response;
        }

        public async Task<List<TblMenu>> GetAllMenus()
        {
           return await this.context.tblMenus.ToListAsync();
        }

        public async Task<List<TblRole>> GetAllRoles()
        {
            return await this.context.tblRoles.ToListAsync();
        }

        public async Task<List<Appmenu>> GetAllMenubyrole(string userrole)
        {
           List<Appmenu> appmenus = new List<Appmenu>();

            var accessdata = (from menu in this.context.tblRolepermissions.Where(o => o.Userrole == userrole && o.Haveview)
                              join m in this.context.tblMenus on menu.Menucode equals m.Code into _jointable
                              from p in _jointable.DefaultIfEmpty()
                              select new { code = menu.Menucode, name = p.Name }).ToList();
            if (accessdata.Any())
            {
                accessdata.ForEach(item =>
                {
                    appmenus.Add(new Appmenu()
                    {
                        code = item.code,
                        Name = item.name
                    });
                });
            }

            return appmenus;
        }

       public async Task<Menupermission> GetMenupermissionbyrole(string userrole, string menucode)
        {
            Menupermission menupermission =new Menupermission();
            var _data = await this.context.tblRolepermissions.FirstOrDefaultAsync(o => o.Userrole == userrole && o.Haveview
            && o.Menucode == menucode);
            if (_data != null)
            {
                menupermission.code = _data.Menucode;
                menupermission.Haveview = _data.Haveview;
                menupermission.Haveadd = _data.Haveadd;
                menupermission.Haveedit = _data.Haveedit;
                menupermission.Havedelete = _data.Havedelete;
            }
            return menupermission;
        }

        Task<IApiResponse> IUserRoleServices.AssPermission(List<TblRolepermission> _data)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> AssignRole(List<TblRolepermission> _data)
        {
            throw new NotImplementedException();
        }

        Task<List<TblRole>> IUserRoleServices.GetAllRoles()
        {
            throw new NotImplementedException();
        }

        Task<List<TblMenu>> IUserRoleServices.GetAllMenus()
        {
            throw new NotImplementedException();
        }

        Task<List<Appmenu>> IUserRoleServices.GetAllMenubyrole(string userrole)
        {
            throw new NotImplementedException();
        }

        Task<Menupermission> IUserRoleServices.GetMenupermissionbyrole(string userrole, string menucode)
        {
            throw new NotImplementedException();
        }

        Task<APIResponse> IUserRoleServices.AssignRolePermission(List<TblRolepermission> _data)
        {
            throw new NotImplementedException();
        }
    }
}
