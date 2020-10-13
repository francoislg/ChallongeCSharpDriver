using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    public interface ChallongeQuery<ReturnType> {
        Task<ReturnType> call(ChallongeAPICaller caller);
    }
}
