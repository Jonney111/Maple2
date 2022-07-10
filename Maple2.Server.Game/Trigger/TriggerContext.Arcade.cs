﻿namespace Maple2.Server.Game.Trigger;

public partial class TriggerContext {
    #region BoomBoomOcean
    public void ArcadeBoomBoomOceanSetSkillScore(int skillId, int score) { }

    public void ArcadeBoomBoomOceanStartGame(byte lifeCount) { }

    public void ArcadeBoomBoomOceanEndGame() { }

    public void ArcadeBoomBoomOceanStartRound(byte round, int roundDuration, int timeScoreRate) { }

    public void ArcadeBoomBoomOceanClearRound(byte round) { }
    #endregion

    #region SpringFarm
    public void ArcadeSpringFarmSetInteractScore(int interactId, int score) { }

    public void ArcadeSpringFarmSpawnMonster(int[] spawnIds, int score) { }

    public void ArcadeSpringFarmStartGame(byte lifeCount) { }

    public void ArcadeSpringFarmEndGame() { }

    public void ArcadeSpringFarmStartRound(byte round, int uiDuration, string timeScoreType, int timeScoreRate, int roundDuration) { }

    public void ArcadeSpringFarmClearRound(byte round) { }
    #endregion

    #region ThreeTwoOne
    public void ArcadeThreeTwoOneStartGame(byte lifeCount, int initScore) { }

    public void ArcadeThreeTwoOneEndGame() { }

    public void ArcadeThreeTwoOneStartRound(byte round, int uiDuration) { }

    public void ArcadeThreeTwoOneResultRound(byte resultDirection) { }

    public void ArcadeThreeTwoOneResultRound2(byte round) { }

    public void ArcadeThreeTwoOneClearRound(byte round) { }
    #endregion
}
