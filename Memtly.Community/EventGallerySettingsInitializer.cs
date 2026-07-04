using Memtly.Core.Constants;
using Memtly.Core.Helpers;
using Memtly.Core.Helpers.Database;

namespace Memtly.Community
{
    public sealed class EventGallerySettingsInitializer : IHostedService
    {
        private readonly IConfigHelper _config;
        private readonly ISettingsHelper _settings;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<EventGallerySettingsInitializer> _logger;

        public EventGallerySettingsInitializer(
            IConfigHelper config,
            ISettingsHelper settings,
            IServiceScopeFactory scopeFactory,
            ILogger<EventGallerySettingsInitializer> logger)
        {
            _config = config;
            _settings = settings;
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await ApplySetting(MemtlyConfiguration.Gallery.AllowViewing, true, cancellationToken: cancellationToken);
            await ApplySetting(MemtlyConfiguration.Gallery.RequireReview, false, cancellationToken: cancellationToken);

            using var scope = _scopeFactory.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<IDatabaseHelper>();
            var galleries = await database.GetGalleries();

            foreach (var gallery in galleries.Where(gallery => !gallery.Identifier.Equals(SystemGalleries.AllGallery, StringComparison.OrdinalIgnoreCase)))
            {
                cancellationToken.ThrowIfCancellationRequested();

                await ApplySetting(MemtlyConfiguration.Gallery.AllowViewing, true, gallery.Id, cancellationToken);
                await ApplySetting(MemtlyConfiguration.Gallery.RequireReview, false, gallery.Id, cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task ApplySetting(string key, bool fallbackValue, int? galleryId = null, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var desiredValue = _config.GetOrDefault(key, fallbackValue).ToString();
            var currentValue = (await _settings.Get(key, galleryId))?.Value;
            if (string.Equals(currentValue, desiredValue, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            await _settings.SetSetting(key, desiredValue, galleryId);
            _logger.LogInformation("Set event gallery setting {SettingKey} to {SettingValue} for {GalleryScope}.", key, desiredValue, galleryId?.ToString() ?? "global");
        }
    }
}
