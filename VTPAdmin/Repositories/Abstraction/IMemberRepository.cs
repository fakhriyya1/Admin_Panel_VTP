using VTPAdmin.Models;
using VTPAdmin.ViewModels.Members;

namespace VTPAdmin.Repositories.Abstraction
{
    public interface IMemberRepository
    {
        Task<IEnumerable<MemberVM>> GetAllNonDeletedMembers();
        Task<MemberVM?> GetNonDeletedMemberById(int memberId);
        Task CreateMemberAsync(CreateMemberVM createMemberVM);
        Task<UpdateMemberVM?> UpdateMemberAsync(int memberId, UpdateMemberVM updateMemberVM);
        Task<Member?> SafeDeleteAsync(int memberId);
    }
}
