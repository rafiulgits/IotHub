using IotHub.Common.Values;
using IotHub.DataTransferObjects.Profile;
using IotHub.DataTransferObjects.Subscription;
using IotHub.Services.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IotHub.API.Controllers
{
    [Authorize(Policy = PolicyName.AdminOrAgent)]
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

        [Authorize(Policy = PolicyName.Admin)]
        [HttpPost]
        public async Task<ActionResult<ProfileDto>> CreateAsync([FromBody] ProfileUpsertDto profile)
        {
            var createdProfile = await profileService.CreateProfileAsync(profile);
            return Created("", createdProfile);
        }

        [Authorize(Policy = PolicyName.Admin)]
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

        [Authorize(Policy = PolicyName.Admin)]
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

        [Authorize(Policy = PolicyName.Admin)]
        [HttpPatch("{id}/subscriptions")]
        public async Task<ActionResult> AddSubscription([FromRoute]string id, [FromBody] SubscriptionUpsertDto subscription)
        {
            var isAdded = await profileService.AddSubscription(id, subscription);
            if (isAdded)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [Authorize(Policy = PolicyName.Admin)]
        [HttpDelete("{id}/subscriptions")]
        public async Task<ActionResult> RemoveSubscription([FromRoute]string id, [FromBody] SubscriptionUpsertDto subscription)
        {
            var isRemoved = await profileService.RemoveSubscription(id, subscription);
            if (isRemoved)
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpGet("{id}/subscriptions")]
        public ActionResult<IEnumerable<SubscriptionDto>> GetSubscriptions([FromRoute]string id)
        {
            var subscriptions = profileService.GetSubscriptions(id);
            return Ok(subscriptions);
        }
    }
}
