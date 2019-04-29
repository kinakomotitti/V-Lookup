dotnet publish -c Release --self-contained true -r linux-x64
dotnet publish -c Release --self-contained true -r linux-arm
dotnet publish -c Release --self-contained true -r win-x64
dotnet publish -c Release --self-contained true -r win-x86

cd ./bin/Release/netcoreapp3.0

powershell compress-archive ./linux-x64 linux-x64.zip
powershell compress-archive ./linux-arm linux-arm.zip
powershell compress-archive ./win-x64 win-x64.zip
powershell compress-archive ./win-x86 win-x86.zip