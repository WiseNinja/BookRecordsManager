using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookRecordsManager.Application.Queries.ReadInputData;
using BookRecordsManager.Domain.Entities;

namespace BookRecordsManager.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookRecord, BookRecordVm>().ReverseMap();
        }
    }
}
