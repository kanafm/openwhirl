{
  description = "openwhirl dev env";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixos-25.11";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs { inherit system; };
      in
      {
        devShells.default = pkgs.mkShell {
          packages = with pkgs; [
            dotnet-sdk_8
            git
            ctags
          ];
        };

        apps.default = {
          type = "app";
          program = toString (pkgs.writeShellScript "ci-build-run" ''
            set -euo pipefail

            : "''${UNITY_PATH:?UNITY_PATH is not set}"

            UNITY="''${UNITY_PATH}"

            echo "==> Building procedural core"
            dotnet build core/Core.csproj -c Release

            CORE_DLL="core/bin/Release/netstandard2.1/Core.dll"
            UNITY_PLUGIN_DIR="unity/VoxelWorld/Assets/Plugins"

            test -f "$CORE_DLL"

            mkdir -p "$UNITY_PLUGIN_DIR"
            cp -f "$CORE_DLL" "$UNITY_PLUGIN_DIR/Core.dll"

            echo "==> Running Unity headless build"
            "$UNITY" \
              -batchmode \
              -nographics \
              -quit \
              -projectPath unity/VoxelWorld \
              -executeMethod BuildScript.BuildMacOS \
              -logFile unity-build.log

            unity/VoxelWorld/Build/VoxelWorld.app/Contents/MacOS/VoxelWorld || true
          '');
        };
      });
}
