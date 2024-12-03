using AutoMapper;
using LibraryManageModel.BusinessModel;
using LibraryManageModel.Entities;

namespace LibraryManage.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //for VM   CerateMap<source, Destinaiton>();
            CreateMap<Book, BookVM>();
            CreateMap<BookVM, Book>();

            //for audit trial
            //CreateMap<Book, BookAuditTrial>();
            //CreateMap<BookAuditTrial, BaseAuditTrialVM>();


        }
    }
}
