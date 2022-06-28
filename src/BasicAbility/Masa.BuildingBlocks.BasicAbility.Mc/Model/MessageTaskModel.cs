// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.BuildingBlocks.BasicAbility.Mc.Model;

public class MessageTaskModel : AuditEntity<Guid, Guid>
{
    public string DisplayName { get; set; } = string.Empty;

    public Guid ChannelId { get; set; }

    public ChannelModel Channel { get; set; } = new();

    public MessageEntityTypes EntityType { get; set; }

    public Guid EntityId { get; set; }

    public bool IsDraft { get; set; }

    public bool IsEnabled { get; set; }

    public ReceiverTypes ReceiverType { get; set; }

    public MessageTaskSelectReceiverTypes SelectReceiverType { get; set; }

    public DateTimeOffset? SendTime { get; set; }

    public string Sign { get; set; } = string.Empty;

    public MessageInfoModel MessageInfo { get; set; } = new();

    public List<MessageTaskReceiverModel> Receivers { get; set; } = new();

    public SendRuleModel SendRules { get; set; } = new();

    public ExtraPropertyDictionary Variables { get; set; } = new();

    public string Content { get; set; } = string.Empty;

    public MessageTaskStatuses Status { get; set; }
}
