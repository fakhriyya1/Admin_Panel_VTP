using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VTPAdmin.Repositories.Abstraction;
using VTPAdmin.ViewModels.Members;

namespace VTPAdmin.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberController(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var members = await _memberRepository.GetAllNonDeletedMembers();

            return View(members);
        }

        [HttpGet("/Member/View/{memberId}")]
        public async Task<IActionResult> Info(int memberId)
        {
            var member = await _memberRepository.GetNonDeletedMemberById(memberId);

            if (member == null)
                return NotFound();

            return View(member);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CreateMemberVM createMemberVM)
        {
            if (!ModelState.IsValid)
            {
                return View(createMemberVM);
            }

            await _memberRepository.CreateMemberAsync(createMemberVM);

            return RedirectToAction(nameof(Index), "Member");
        }

        [HttpGet("/Member/Update/{memberId}")]
        public async Task<IActionResult> Update(int memberId)
        {
            var member = await _memberRepository.GetNonDeletedMemberById(memberId);

            if (member == null)
                return NotFound();

            var updateMemberVM = _mapper.Map<UpdateMemberVM>(member);

            return View(updateMemberVM);
        }

        [HttpPost("/Member/Update/{memberId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int memberId, UpdateMemberVM updateMemberVM)
        {
            if (!ModelState.IsValid)
            {
                return View(updateMemberVM);
            }

            var member = await _memberRepository.UpdateMemberAsync(memberId, updateMemberVM);

            if (member == null)
                return NotFound();

            return RedirectToAction(nameof(Index), "Member");
        }

        [HttpGet("/Member/Delete/{memberId}")]
        public async Task<IActionResult> SafeDelete(int memberId)
        {
            var member = await _memberRepository.SafeDeleteAsync(memberId);

            if (member == null)
                return NotFound();

            return RedirectToAction(nameof(Index), "Member");
        }
    }
}
