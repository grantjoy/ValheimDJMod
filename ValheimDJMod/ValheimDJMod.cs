using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace ValheimMod
{
    [BepInPlugin("grantjoy.ValheimDJMod", "Valheim DJ Mod", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class ValheimMod : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("grantjoy.ValheimMod");

        private void Awake()
        {
            PrefabManager.Instance.PrefabRegister += registerPrefabs;
            PieceManager.Instance.PieceRegister += registerPieces;
        }

        public class TestCubePrefab : PrefabConfig
        {
            // Create a prefab called "TestCube" with no base
            public TestCubePrefab() : base("TestCube")
            {
                // Nothing to  do here
            }

            private void registerPrefabs(object sender, EventArgs e)
            {
                PrefabManager.Instance.RegisterPrefab(new TestCubePrefab());
            }

            // Register new pieces
            private void registerPieces(object sender, EventArgs e)
            {
                // Register our piece in the "Hammer", using the "TestCube" prefab
                PieceManager.Instance.RegisterPiece("Hammer", "TestCube");
            }

            public override void Register()
            {
                // Add piece component so that we can register this as a piece
                // This function is just a util function that will add a piece, and help setup some of the basic requirements of it
                Piece piece = AddPiece(new PieceConfig()
                {
                    // The name that shows up in game
                    Name = "Test cube",

                    // The description that shows up in game
                    Description = "A nice test cube",

                    // What items we'll need to build it
                    Requirements = new PieceRequirementConfig[]
                    {
                        new PieceRequirementConfig()
                        {
                            // Name of item prefab we need
                            Item = "Wood",

                            // Amount we need
                            Amount = 1
                        }
                    }
                });

                // Additional piece config if you need here...
            }
        }
    }


}