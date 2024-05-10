using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VTPAdmin.DAL;
using VTPAdmin.Extensions;
using VTPAdmin.Models;
using VTPAdmin.Repositories.Abstraction;
using VTPAdmin.ViewModels.Members;

namespace VTPAdmin.Repositories.Concrete
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal user;

        public MemberRepository(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            user = httpContextAccessor.HttpContext.User;
        }

        public async Task<IEnumerable<MemberVM>> GetAllNonDeletedMembers()
        {
            var members = await _dbContext.Members.Where(m => !m.IsDeleted).ToListAsync();
            var map = members.Select(m => _mapper.Map<MemberVM>(m)).ToList();

            return map;
        }

        public async Task<MemberVM?> GetNonDeletedMemberById(int memberId)
        {
            var member = await _dbContext.Members.FirstOrDefaultAsync(m => m.Id == memberId && !m.IsDeleted);

            if (member == null)
                return null;

            var memberVM = _mapper.Map<MemberVM>(member);

            return memberVM;
        }

        public async Task CreateMemberAsync(CreateMemberVM createMemberVM)
        {
            var userEmail = user.GetLoggedInUserExtension();

            var member = _mapper.Map<Member>(createMemberVM);

            member.CreatedBy = userEmail;

            await _dbContext.Members.AddAsync(member);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<UpdateMemberVM?> UpdateMemberAsync(int memberId, UpdateMemberVM updateMemberVM)
        {
            var member = await _dbContext.Members.FindAsync(memberId);

            if (member == null)
                return null;

            var userEmail = user.GetLoggedInUserExtension();

            _mapper.Map(updateMemberVM, member);

            member.ModifiedAt = DateTime.UtcNow;
            member.ModifiedBy = userEmail;

            _dbContext.Members.Update(member);
            await _dbContext.SaveChangesAsync();

            return updateMemberVM;
        }

        public async Task<Member?> SafeDeleteAsync(int memberId)
        {
            var member = await _dbContext.Members.FirstOrDefaultAsync(x => x.Id == memberId && !x.IsDeleted);

            if (member == null) return null;

            member.IsDeleted = true;
            _dbContext.Members.Update(member);
            await _dbContext.SaveChangesAsync();

            return member;
        }
    }
}
