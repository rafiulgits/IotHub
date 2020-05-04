using IotHub.DataTransferObjects.Profile;
using IotHub.Services.Profile;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotHub.API.Controllers
{
    [Route("api/profiles")]
    public class ProfileController : IotHubBaseController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileDto>> GetAsync([FromRoute] string id)
        {
            var profile = await profileService.GetProfileAsync(id);
            return Ok(profile);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileDto>>> GetAllAsync()
        {
            var profiles = await profileService.GetAllAsync();
            return Ok(profiles);
        }

        [HttpPost]
        public async Task<ActionResult<ProfileDto>> CreateAsync([FromBody] ProfileUpsertDto profile)
        {
            var createdProfile = await profileService.CreateProfileAsync(profile);
            return Created("", createdProfile);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProfileDto>> UpdateAsync([FromRoute]string id, [FromBody]ProfileUpsertDto profile)
        {
            if (id != profile.Id)
            {
                return BadRequest("Request id and profile id must be same");
            }
            var updatedProfile = await profileService.UpdateProfileAsync(profile);
            return Ok(updatedProfile);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute]string id)
        {
            var isDeleted = await profileService.DeleteProfileAsync(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPatch("{id}/subscriptions")]
        public async Task<ActionResult> AddSubscription([FromRoute]string id, [FromBody] ProfileSubscriptionDto profileSubscription)
        {
            var isAdded = await profileService.AddSubscription(id, profileSubscription);
            if (isAdded)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}/subscriptions")]
        public async Task<ActionResult> RemoveSubscription([FromRoute]string id, [FromBody] ProfileSubscriptionDto profileSubscription)
        {
            var isRemoved = await profileService.RemoveSubscription(id, profileSubscription);
            if (isRemoved)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpGet("{id}/subscriptions")]
        public async Task<ActionResult<IEnumerable<ProfileSubscriptionDto>>> GetSubscriptions([FromRoute]string id)
        {
            var subscriptions = await profileService.GetSubscriptionsAsync(id);
            return Ok(subscriptions);
        }
    }
}
