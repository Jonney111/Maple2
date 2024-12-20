﻿using Maple2.Model.Enum;
using Maple2.Model.Game;
using Maple2.Model.Metadata;
using Maple2.Server.Game.Manager.Field;
using Maple2.Server.Game.Packets;

namespace Maple2.Server.Game.Model;

public class FieldFunctionInteract : FieldEntity<FunctionCubeMetadata> {
    public PlotCube Cube { get; }

    private long NextUpdateTick { get; set; }

    public FieldFunctionInteract(FieldManager field, int objectId, FunctionCubeMetadata value, PlotCube cube) : base(field, objectId, value) {
        if (cube.Interact is null) {
            throw new InvalidOperationException("Cube.Interact is null");
        }

        Cube = cube;
        NextUpdateTick = Field.FieldTick + Value.AutoStateChangeTime;
    }

    public override void Update(long tickCount) {
        if (Cube.Interact!.State is InteractCubeState.Available or InteractCubeState.None) {
            return;
        }

        if (tickCount < NextUpdateTick) {
            return;
        }

        Cube.Interact.State = InteractCubeState.Available;
        Field.Broadcast(FunctionCubePacket.UpdateFunctionCube(Cube.Interact));
    }

    public bool Use() {
        lock (Cube.Interact!) {
            if (Cube.Interact.State is not InteractCubeState.Available) {
                return false;
            }

            Cube.Interact.State = InteractCubeState.InUse;
            NextUpdateTick = Field.FieldTick + Value.AutoStateChangeTime;
            return true;
        }
    }
}
