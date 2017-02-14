using Spring.Objects.Factory.Attributes;

namespace HoldkassenAPI.Modules.Team.TeamViewModels
{
    public class CreateTeam
    {
        [Required]
        public string Name { get; set; }
    }
}