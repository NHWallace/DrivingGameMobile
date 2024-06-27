using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class NotificationManager : MonoBehaviour
{
#if UNITY_ANDROID
    private const string ChannelId = "notification_channel";

    public void ScheduleNotification(DateTime time)
    {
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel()
        {
            Id = ChannelId,
            Name = "Notification Channel",
            Description = "Android notification channel for game alerts",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Energy Recharged!",
            Text = "Your energy has recharged, come play!",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = time
        };

        AndroidNotificationCenter.SendNotification(notification, ChannelId);
    }
#endif
}
