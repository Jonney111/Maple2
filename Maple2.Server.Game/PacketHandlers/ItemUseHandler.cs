﻿using Maple2.Model.Game;
using Maple2.PacketLib.Tools;
using Maple2.Server.Core.Constants;
using Maple2.Server.Core.PacketHandlers;
using Maple2.Server.Game.Session;

namespace Maple2.Server.Game.PacketHandlers;

public class ItemUseHandler : PacketHandler<GameSession> {
    public override RecvOp OpCode => RecvOp.RequestItemUse;

    public override void Handle(GameSession session, IByteReader packet) {
        long itemUid = packet.ReadLong();
        string unknown = packet.ReadUnicodeString();

        Item? item = session.Item.Inventory.Get(itemUid);
        if (item == null) {
            Logger.Warning("RequestItemUse for invalid item:{ItemUid}", itemUid);
            return;
        }
    }
}