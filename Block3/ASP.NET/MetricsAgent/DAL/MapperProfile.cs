using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.Models;
using MetricsAgent.Responses;

//using MetricsAgent.DAL;
//using MetricsAgent.Models;
//using MetricsAgent.Requests;
//using MetricsAgent.Responses;
//using MetricsLibrary;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;


namespace MetricsAgent
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // добавлять сопоставления в таком стиле нужно для всех объектов
            CreateMap<CpuMetric, CpuMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<DotNetMetric, DotNetMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<HddMetric, HddMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<NetworkMetric, NetworkMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<RamMetric, RamMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
        }
    }
}