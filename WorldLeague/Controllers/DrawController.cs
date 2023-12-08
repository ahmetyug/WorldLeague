using Core;
using Microsoft.AspNetCore.Mvc;
using Services.DrawLoggers;
using Services.GroupBuilders;
using Services.TeamProviders;

namespace WorldLeague.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly IGroupBuilderFactory groupBuilderFactory;
        private readonly ITeamsProvider teamsProvider;
        private readonly IDrawLogger drawLogger;

        public DrawController(IGroupBuilderFactory groupBuilderFactory, ITeamsProvider teamsProvider, IDrawLogger drawLogger)
        {
            this.groupBuilderFactory = groupBuilderFactory;
            this.teamsProvider = teamsProvider;
            this.drawLogger = drawLogger;
        }

        [HttpGet(Name = "GenerateDraw")]
        public async Task<ApiResponse<IReadOnlyList<IGroup>>> GenerateDraw(string drawerName, int groupCount)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(drawerName))
                {
                    throw new ArgumentException("drawerName cannot be empty", nameof(drawerName));
                }

                IGroupBuilderFactory groupBuilderFactory = this.groupBuilderFactory;
                var groupBuilder = groupBuilderFactory.GetGroupBuilder(GroupBuildingStrategies.NoSameCountryInTheGroup);

                var teams = await this.teamsProvider.GetTeamsAsync();

                var groups = groupBuilder.GenerateGroups(teams, groupCount);

                await this.drawLogger.LogAsync(drawerName, groups);

                return ApiResponse<IReadOnlyList<IGroup>>.OfSuccess(groups);
            }
            catch (Exception ex)
            {
                return ApiResponse<IReadOnlyList<IGroup>>.OfFail(ApiResult.Fail, ex.Message);
            }
        }

        [HttpGet(Name = "GetStoredDraws")]
        public async Task<ApiResponse<IReadOnlyList<IStoredDraw>>> GetStoredDraws(string drawerName)
        {
            try
            {
                var draws = await this.drawLogger.GetStoredDrawsByNameAsync(drawerName);

                return ApiResponse<IReadOnlyList<IStoredDraw>>.OfSuccess(draws);
            }
            catch (Exception ex)
            {
                return ApiResponse<IReadOnlyList<IStoredDraw>>.OfFail(ApiResult.Fail, ex.Message);
            }
        }
    }
}
