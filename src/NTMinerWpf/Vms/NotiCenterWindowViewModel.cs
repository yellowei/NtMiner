﻿using NTMiner.Notifications;
using NTMiner.Out;

namespace NTMiner.Vms {
    public class NotiCenterWindowViewModel : ViewModelBase, IOut {
        public static readonly NotiCenterWindowViewModel Instance = new NotiCenterWindowViewModel();
        public static bool IsHotKeyEnabled = false;

        private NotiCenterWindowViewModel() { }

        private INotificationMessageManager _manager;
        public INotificationMessageManager Manager {
            get {
                if (_manager == null) {
                    _manager = new NotificationMessageManager();
                }
                return _manager;
            }
        }
        public void ShowError(string message, string header, int autoHideSeconds) {
            UIThread.Execute(() => () => {
                var builder = NotificationMessageBuilder.CreateMessage(Manager);
                builder.Error(header, message ?? string.Empty);
                if (autoHideSeconds > 0) {
                    builder
                        .Dismiss()
                        .WithDelay(autoHideSeconds)
                        .Queue();
                }
                else {
                    builder
                        .Dismiss().WithButton("知道了", null)
                        .Queue();
                }
            });
        }

        public void ShowWarn(string message, string header, int autoHideSeconds) {
            UIThread.Execute(() => () => {
                var builder = NotificationMessageBuilder.CreateMessage(Manager);
                builder.Warning(header, message ?? string.Empty);
                if (autoHideSeconds > 0) {
                    builder
                        .Dismiss()
                        .WithDelay(autoHideSeconds)
                        .Queue();
                }
                else {
                    builder
                        .Dismiss().WithButton("知道了", null)
                        .Queue();
                }
            });
        }

        public void ShowInfo(string message, string header, int autoHideSeconds) {
            UIThread.Execute(() => () => {
                var builder = NotificationMessageBuilder.CreateMessage(Manager);
                builder.Info(header, message ?? string.Empty);
                if (autoHideSeconds > 0) {
                    builder
                    .Dismiss()
                    .WithDelay(autoHideSeconds)
                    .Queue();
                }
                else {
                    builder
                        .Dismiss().WithButton("知道了", null)
                        .Queue();
                }
            });
        }

        public void ShowSuccess(string message, string header, int autoHideSeconds) {
            UIThread.Execute(() => () => {
                var builder = NotificationMessageBuilder.CreateMessage(Manager);
                builder.Success(header, message);
                if (autoHideSeconds > 0) {
                    builder
                    .Dismiss()
                    .WithDelay(autoHideSeconds)
                    .Queue();
                }
                else {
                    builder
                        .Dismiss().WithButton("知道了", null)
                        .Queue();
                }
            });
        }
    }
}
