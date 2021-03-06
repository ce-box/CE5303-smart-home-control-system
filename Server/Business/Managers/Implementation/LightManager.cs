using Business.Managers.Contracts;
using Business.Models;
using Data.Accessors.Contracts;
using Models;
using Models.Exceptions;
using Services.Constants;
using Services.Contracts;
using System.Runtime.CompilerServices;
using Persistence = Data.Models;

namespace Business.Managers.Implementation
{
    public class LightManager : ILightManager
    {
        private readonly IHardwareService _hardwareService;
        private readonly ILightAccessor _lightAccessor;

        public LightManager(IHardwareService hardwareService, ILightAccessor lightAccessor)
        {
            _hardwareService = hardwareService;
            _lightAccessor = lightAccessor;
        }

        public async Task<Light> FindAsync(Guid id)
        {
            Persistence.Light item = await _lightAccessor.FindAsync(i => i.Id == id);

            if (item == null)
                throw new NotFoundException(id);

            Boolean isOpen = await _hardwareService.IsLightOn(item.Pin);

            return new Light().LoadFrom(item, isOpen);
        }

        public async IAsyncEnumerable<Light> FindStreamAsync(Guid id, [EnumeratorCancellation] CancellationToken cancellationToken, int delay)
        {
            Persistence.Light item = await _lightAccessor.FindAsync(i => i.Id == id);
            if (item == null)
                throw new NotFoundException(id);

            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Boolean isOpen = await _hardwareService.IsDoorOpen(item.Pin);
                yield return new Light().LoadFrom(item);

                await Task.Delay(delay, cancellationToken);
            }
        }

        public async Task<IList<Light>> GetAsync()
        {
            IList<Persistence.Light> items = await _lightAccessor.GetAsync();

            return items.Select(async item => new Light()
                .LoadFrom(item, await _hardwareService.IsLightOn(item.Pin)))
                .Select(item => item.Result).ToList();
        }

        public async IAsyncEnumerable<IList<Light>> GetStreamAsync([EnumeratorCancellation] CancellationToken cancellationToken, int delay)
        {
            IList<Persistence.Light> items = await _lightAccessor.GetAsync();

            while (!cancellationToken.IsCancellationRequested)
            {
                cancellationToken.ThrowIfCancellationRequested();

                yield return items.Select(async item => new Light()
                    .LoadFrom(item, await _hardwareService.IsDoorOpen(item.Pin)))
                    .Select(item => item.Result).ToList();

                await Task.Delay(delay, cancellationToken);
            }
        }

        public async Task UpdateAsync(Guid id, Light item)
        {
            Persistence.Light existingValue = await _lightAccessor.FindAsync(i => i.Id == id);

            if (existingValue == null)
                throw new NotFoundException(id);

            await _hardwareService.SwitchLight(existingValue.Pin, item.IsOn? 
                HardwareStatus.ON : 
                HardwareStatus.OFF);
        }
    }
}
