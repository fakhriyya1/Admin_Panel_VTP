using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using VTPAdmin.Models;
using VTPAdmin.ViewModels.Members;

namespace VTPAdmin.AutoMapper.Members
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<CreateMemberVM, Member>();
            CreateMap<UpdateMemberVM, Member>();
            CreateMap<MemberVM, UpdateMemberVM>();
            CreateMap<MemberVM, Member>().ReverseMap();
        }
    }
}
