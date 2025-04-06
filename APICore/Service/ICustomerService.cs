

using APICore.Container;
using APICore.Helper;
using APICore.Modal;
using Octokit.Internal;
using Refit;

namespace APICore.Service
{
    public interface ICustomerService
    {
        Task<List<Customermodal>> Getall();
        Task<Customermodal> Getbycode(string code);
        Task<APIResponse> Remove(string code);
        Task<APIResponse> Create(Customermodal data);

        Task<APIResponse> Update(Customermodal data,string code);
        Task<APIResponse> Update(Customermodal data, Customermodal code);
        Task<APIResponse> Remove(Customermodal code);
        Task<APIResponse> Create(string data);
        Task<APIResponse> Remove(CustomerService code);
    }
}
