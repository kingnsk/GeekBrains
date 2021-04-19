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
            CreateMap<CpuMetric, CpuMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<DotNetMetric, DotNetMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<HddMetric, HddMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<NetworkMetric, NetworkMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
            CreateMap<RamMetric, RamMetricDto>().ForMember(dbModel => dbModel.Time, _ => _.MapFrom((src, dst) => DateTimeOffset.FromUnixTimeSeconds(src.Time)));
        }
    }
}