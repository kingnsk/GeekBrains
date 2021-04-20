using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.Models;
using MetricsManager.Responses;


namespace MetricsManager
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // добавлять сопоставления в таком стиле нужно для всех объектов
            CreateMap<CpuMetricFromAgent, CpuMetricApiDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<DotNetMetricFromAgent, DotNetMetricApiDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<HddMetricFromAgent, HddMetricApiDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<NetworkMetricFromAgent, NetworkMetricApiDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<RamMetricFromAgent, RamMetricApiDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
        }
    }
}