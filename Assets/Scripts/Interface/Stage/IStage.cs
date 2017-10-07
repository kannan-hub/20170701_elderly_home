using System.Collections.Generic;
using Interface.Character;

namespace Interface.Stage
{
    /// <summary>
    /// ステージが持つべきInterface
    /// </summary>
    public interface IStage
    {
        /// <summary>
        /// このステージのもつ目標リスト
        /// </summary>
        List<IObjective> Objectives { get; }

        /// <summary>
        /// ステージ中のポイント一覧
        /// </summary>
        List<IPoint> Points { get; }

        /// <summary>
        /// このステージ中に出現するキャラクター一覧（プレイヤー以外）
        /// </summary>
        List<ICharacter> Characters { get; }
    }
}